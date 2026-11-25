namespace NotepadApp.Models;

/// <summary>Kullanıcının kaydettiği tek bir notu temsil eder.</summary>
public class Not
{
    public const string VarsayilanKategori = "Genel";

    private string _baslik = string.Empty;
    private string _icerik = string.Empty;
    private string _icerikRtf = string.Empty;
    private string _kategori = VarsayilanKategori;

    public Guid Id { get; set; } = Guid.NewGuid();

    public string Baslik
    {
        get => _baslik;
        set => _baslik = value?.Trim() ?? string.Empty;
    }

    /// <summary>Notun düz metin hali; arama ve .txt dışa aktarma bunu kullanır.</summary>
    public string Icerik
    {
        get => _icerik;
        set => _icerik = value ?? string.Empty;
    }

    /// <summary>Notun kalın/italik gibi biçimleri içeren RTF hali.</summary>
    public string IcerikRtf
    {
        get => _icerikRtf;
        set => _icerikRtf = value ?? string.Empty;
    }

    public string Kategori
    {
        get => _kategori;
        set => _kategori = string.IsNullOrWhiteSpace(value) ? VarsayilanKategori : value.Trim();
    }

    public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;

    public DateTime DuzenlemeTarihi { get; set; } = DateTime.Now;

    /// <summary>ListBox'ta görünecek metni döndürür.</summary>
    public override string ToString() => $"{Baslik} ({DuzenlemeTarihi:dd.MM.yyyy HH:mm})";
}
