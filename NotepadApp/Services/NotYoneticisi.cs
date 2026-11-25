using System.Globalization;
using NotepadApp.Models;

namespace NotepadApp.Services;

/// <summary>Notların listesini tutar; ekleme, güncelleme, silme ve arama işlemlerini yapar.</summary>
public class NotYoneticisi
{
    private static readonly CompareInfo TurkceKarsilastirma = new CultureInfo("tr-TR").CompareInfo;

    private readonly List<Not> _notlar = new();

    /// <summary>Not listesi her değiştiğinde tetiklenir.</summary>
    public event EventHandler? NotlarDegisti;

    public void Ekle(Not not)
    {
        ArgumentNullException.ThrowIfNull(not);
        _notlar.Add(not);
        DegisikligiBildir();
    }

    /// <summary>Notun alanlarını değiştirir ve düzenleme tarihini günceller. Not bulunamazsa false döner.</summary>
    public bool Guncelle(Guid id, string baslik, string icerik, string icerikRtf, string kategori)
    {
        Not? not = _notlar.Find(n => n.Id == id);
        if (not is null)
        {
            return false;
        }

        not.Baslik = baslik;
        not.Icerik = icerik;
        not.IcerikRtf = icerikRtf;
        not.Kategori = kategori;
        not.DuzenlemeTarihi = DateTime.Now;
        DegisikligiBildir();
        return true;
    }

    public bool Sil(Guid id)
    {
        if (_notlar.RemoveAll(n => n.Id == id) == 0)
        {
            return false;
        }

        DegisikligiBildir();
        return true;
    }

    /// <summary>Başlık veya içerikte metni arar. Boş metin ve null kategori "hepsi" demektir.</summary>
    public List<Not> Ara(string metin, string? kategori)
    {
        string aranan = metin.Trim();
        return _notlar
            .Where(n => kategori is null || MetinEsit(n.Kategori, kategori))
            .Where(n => Icerir(n.Baslik, aranan) || Icerir(n.Icerik, aranan))
            .OrderByDescending(n => n.DuzenlemeTarihi)
            .ToList();
    }

    /// <summary>Listenin kopyasını döndürür; dışarıdan asıl liste değiştirilemez.</summary>
    public List<Not> Tumu() => new(_notlar);

    private static bool Icerir(string kaynak, string aranan) =>
        TurkceKarsilastirma.IndexOf(kaynak, aranan, CompareOptions.IgnoreCase) >= 0;

    private static bool MetinEsit(string a, string b) =>
        TurkceKarsilastirma.Compare(a, b, CompareOptions.IgnoreCase) == 0;

    private void DegisikligiBildir() => NotlarDegisti?.Invoke(this, EventArgs.Empty);
}
