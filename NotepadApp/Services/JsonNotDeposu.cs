using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using NotepadApp.Models;

namespace NotepadApp.Services;

/// <summary>Notları JSON dosyasında saklar.</summary>
public class JsonNotDeposu : INotDeposu
{
    private static readonly JsonSerializerOptions JsonAyarlari = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
    };

    private readonly string _dosyaYolu;

    public JsonNotDeposu()
        : this(Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "YMH219NotepadApp",
            "notlar.json"))
    {
    }

    public JsonNotDeposu(string dosyaYolu)
    {
        _dosyaYolu = dosyaYolu;
    }

    public string DosyaYolu => _dosyaYolu;

    public YuklemeSonucu Yukle()
    {
        try
        {
            string json;
            using (var okuyucu = new StreamReader(_dosyaYolu, Encoding.UTF8))
            {
                json = okuyucu.ReadToEnd();
            }

            List<Not?> notlar = JsonSerializer.Deserialize<List<Not?>>(json, JsonAyarlari)
                ?? throw new JsonException("Dosyada not listesi yok.");
            List<Not> gecerliNotlar = notlar.OfType<Not>().ToList();
            return new YuklemeSonucu(gecerliNotlar, $"{gecerliNotlar.Count} not yüklendi.");
        }
        catch (Exception ex) when (ex is FileNotFoundException or DirectoryNotFoundException)
        {
            return new YuklemeSonucu(new List<Not>(),
                "Not dosyası bulunamadı, boş liste ile başlandı.");
        }
        catch (JsonException)
        {
            string yedekYolu = BozukDosyayiYedekle();
            return new YuklemeSonucu(new List<Not>(),
                $"Not dosyası bozuk olduğu için okunamadı.\n\nDosya şu adla yedeklendi:\n{yedekYolu}\n\nBoş liste ile devam ediliyor.",
                UyariMi: true);
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            throw new NotDeposuException($"Not dosyası okunamadı:\n{ex.Message}", ex);
        }
    }

    /// <summary>Önce geçici dosyaya yazar, sonra asıl dosyanın yerine taşır; yazma yarıda kalırsa eski dosya korunur.</summary>
    public void Kaydet(List<Not> notlar)
    {
        string geciciYol = _dosyaYolu + ".tmp";
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_dosyaYolu)!);
            using (var yazici = new StreamWriter(geciciYol, append: false, Encoding.UTF8))
            {
                yazici.Write(JsonSerializer.Serialize(notlar, JsonAyarlari));
            }

            File.Move(geciciYol, _dosyaYolu, overwrite: true);
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            throw new NotDeposuException($"Notlar kaydedilemedi:\n{ex.Message}", ex);
        }
    }

    private string BozukDosyayiYedekle()
    {
        string yedekYolu = Path.Combine(
            Path.GetDirectoryName(_dosyaYolu)!,
            $"notlar.bozuk-{DateTime.Now:yyyyMMdd-HHmmss}.json");
        try
        {
            File.Move(_dosyaYolu, yedekYolu);
            return yedekYolu;
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            throw new NotDeposuException($"Not dosyası bozuk ve yedeklenemedi:\n{ex.Message}", ex);
        }
    }
}
