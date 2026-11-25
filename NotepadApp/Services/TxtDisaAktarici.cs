using System.Text;
using NotepadApp.Models;

namespace NotepadApp.Services;

/// <summary>Bir notu düz metin (.txt) dosyasına yazar.</summary>
public class TxtDisaAktarici
{
    private const int EnUzunDosyaAdi = 80;

    /// <summary>Notu verilen yola yazar; dosya hataları çağırana iletilir.</summary>
    public void Aktar(Not not, string dosyaYolu)
    {
        using var yazici = new StreamWriter(dosyaYolu, append: false, Encoding.UTF8);
        yazici.WriteLine($"Başlık: {not.Baslik}");
        yazici.WriteLine($"Kategori: {not.Kategori}");
        yazici.WriteLine($"Oluşturma: {not.OlusturmaTarihi:dd.MM.yyyy HH:mm:ss}");
        yazici.WriteLine($"Düzenleme: {not.DuzenlemeTarihi:dd.MM.yyyy HH:mm:ss}");
        yazici.WriteLine(new string('-', 40));
        yazici.WriteLine(not.Icerik.ReplaceLineEndings());
    }

    /// <summary>Başlıktan, Windows'ta geçersiz karakterleri ayıklanmış bir dosya adı üretir.</summary>
    public string OnerilenDosyaAdi(Not not)
    {
        string ad = string.Join("_", not.Baslik.Split(Path.GetInvalidFileNameChars()));
        if (ad.Length > EnUzunDosyaAdi)
        {
            ad = ad[..EnUzunDosyaAdi];
        }

        return ad.Trim(' ', '.') + ".txt";
    }
}
