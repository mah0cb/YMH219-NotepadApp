using NotepadApp.Models;
using NotepadApp.Services;

namespace NotepadApp.Forms;

/// <summary>Not defterinin ana penceresi; yalnızca arayüz ve olay bağlama işini yapar.</summary>
public partial class AnaForm : Form
{
    private readonly NotYoneticisi _yonetici = new(new JsonNotDeposu());

    /// <summary>Editörde açık olan not; null ise yeni not yazılıyor demektir.</summary>
    private Not? _seciliNot;
    private bool _editorDegisti;

    // Kodun yaptığı değişiklikleri kullanıcınınkinden ayırmak için kullanılır.
    private bool _editorDolduruluyor;
    private bool _listeDolduruluyor;

    public AnaForm()
    {
        InitializeComponent();
        _yonetici.NotlarDegisti += Yonetici_NotlarDegisti;
    }

    private void AnaForm_Load(object? sender, EventArgs e)
    {
        tslDosyaYolu.Text = _yonetici.DosyaYolu;
        EditoruDoldur(null);
        NotlariYukle();
    }

    private void AnaForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        if (!DegisikliklerIcinOnayAl(listeyiDeKontrolEt: true))
        {
            e.Cancel = true;
        }
    }

    private void Yonetici_NotlarDegisti(object? sender, EventArgs e) => ListeyiYenile();

    private void lstNotlar_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_listeDolduruluyor || lstNotlar.SelectedItem is not Not hedef || hedef == _seciliNot)
        {
            return;
        }

        if (DegisikliklerIcinOnayAl(listeyiDeKontrolEt: false))
        {
            EditoruDoldur(hedef);
        }

        ListedeSec(_seciliNot);
    }

    private void Editor_Degisti(object? sender, EventArgs e)
    {
        if (!_editorDolduruluyor)
        {
            _editorDegisti = true;
            DurumCubugunuGuncelle();
        }
    }

    private void btnYeni_Click(object? sender, EventArgs e)
    {
        if (!DegisikliklerIcinOnayAl(listeyiDeKontrolEt: false))
        {
            return;
        }

        EditoruDoldur(null);
        ListedeSec(null);
        txtBaslik.Focus();
    }

    private void btnKaydet_Click(object? sender, EventArgs e) => Kaydet();

    private void btnSil_Click(object? sender, EventArgs e)
    {
        if (_seciliNot is null)
        {
            MessageBox.Show(this, "Önce listeden silinecek notu seçin.", "Not Seçilmedi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        DialogResult cevap = MessageBox.Show(this, $"\"{_seciliNot.Baslik}\" notu silinsin mi?", "Silme Onayı",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        if (cevap != DialogResult.Yes)
        {
            return;
        }

        Guid silinecekId = _seciliNot.Id;
        EditoruDoldur(null);
        _yonetici.Sil(silinecekId);
        tslDurum.Text = "Not silindi (dosyaya yazmak için Kaydet)";
    }

    private void mnuYenidenYukle_Click(object? sender, EventArgs e)
    {
        if (DegisikliklerIcinOnayAl(listeyiDeKontrolEt: true))
        {
            NotlariYukle();
        }
    }

    private void mnuCikis_Click(object? sender, EventArgs e) => Close();

    private void NotlariYukle()
    {
        try
        {
            YuklemeSonucu sonuc = _yonetici.Yukle();
            EditoruDoldur(null);
            ListedeSec(null);
            if (sonuc.UyariMi)
            {
                MessageBox.Show(this, sonuc.Mesaj, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                tslDurum.Text = sonuc.Mesaj;
            }
        }
        catch (NotDeposuException ex)
        {
            HataGoster("Yükleme Hatası", ex);
        }
    }

    /// <summary>Editördeki değişikliği listeye işler ve dosyaya yazar. Başarılıysa true döner.</summary>
    private bool Kaydet()
    {
        if (_editorDegisti && !EditoruListeyeIsle())
        {
            return false;
        }

        if (!_yonetici.KaydedilmemisDegisiklikVar)
        {
            tslDurum.Text = "Kaydedilecek değişiklik yok";
            return true;
        }

        return DosyayaYaz();
    }

    private bool DosyayaYaz()
    {
        try
        {
            _yonetici.Kaydet();
            DurumCubugunuGuncelle();
            return true;
        }
        catch (NotDeposuException ex)
        {
            HataGoster("Kayıt Hatası", ex);
            DurumCubugunuGuncelle();
            return false;
        }
    }

    private bool EditoruListeyeIsle()
    {
        if (string.IsNullOrWhiteSpace(txtBaslik.Text))
        {
            MessageBox.Show(this, "Not başlığı boş olamaz.", "Eksik Bilgi",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtBaslik.Focus();
            return false;
        }

        _editorDegisti = false;
        if (_seciliNot is null)
        {
            DateTime simdi = DateTime.Now;
            _seciliNot = new Not
            {
                Baslik = txtBaslik.Text,
                Icerik = rtbIcerik.Text,
                OlusturmaTarihi = simdi,
                DuzenlemeTarihi = simdi
            };
            _yonetici.Ekle(_seciliNot);
        }
        else
        {
            _yonetici.Guncelle(_seciliNot.Id, txtBaslik.Text, rtbIcerik.Text,
                _seciliNot.IcerikRtf, _seciliNot.Kategori);
        }

        TarihleriGoster();
        return true;
    }

    /// <summary>Kaydedilmemiş değişiklik varsa kullanıcıya sorar. İşleme devam edilebilirse true döner.</summary>
    private bool DegisikliklerIcinOnayAl(bool listeyiDeKontrolEt)
    {
        bool degisiklikVar = _editorDegisti
            || (listeyiDeKontrolEt && _yonetici.KaydedilmemisDegisiklikVar);
        if (!degisiklikVar)
        {
            return true;
        }

        DialogResult cevap = MessageBox.Show(this, "Kaydedilmemiş değişiklikler var. Kaydedilsin mi?",
            "Kaydedilmemiş Değişiklik", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        return cevap switch
        {
            DialogResult.Yes => Kaydet(),
            DialogResult.No => true,
            _ => false
        };
    }

    /// <summary>Notu editörde gösterir; null verilirse editörü yeni not için boşaltır.</summary>
    private void EditoruDoldur(Not? not)
    {
        _editorDolduruluyor = true;
        _seciliNot = not;
        txtBaslik.Text = not?.Baslik ?? string.Empty;
        rtbIcerik.Text = not?.Icerik ?? string.Empty;
        _editorDolduruluyor = false;

        _editorDegisti = false;
        TarihleriGoster();
        DurumCubugunuGuncelle();
    }

    private void TarihleriGoster()
    {
        lblOlusturma.Text = $"Oluşturma: {TarihMetni(_seciliNot?.OlusturmaTarihi)}";
        lblDuzenleme.Text = $"Düzenleme: {TarihMetni(_seciliNot?.DuzenlemeTarihi)}";
    }

    private static string TarihMetni(DateTime? tarih) => tarih?.ToString("dd.MM.yyyy HH:mm:ss") ?? "-";

    private void ListeyiYenile()
    {
        _listeDolduruluyor = true;
        lstNotlar.BeginUpdate();
        lstNotlar.Items.Clear();
        foreach (Not not in _yonetici.Ara(string.Empty, null))
        {
            lstNotlar.Items.Add(not);
        }
        lstNotlar.EndUpdate();
        _listeDolduruluyor = false;

        ListedeSec(_seciliNot);
        DurumCubugunuGuncelle();
    }

    private void ListedeSec(Not? not)
    {
        _listeDolduruluyor = true;
        lstNotlar.SelectedIndex = not is null ? -1 : lstNotlar.Items.IndexOf(not);
        _listeDolduruluyor = false;
    }

    private void DurumCubugunuGuncelle()
    {
        tslNotSayisi.Text = $"Not sayısı: {_yonetici.Tumu().Count}";
        tslSonKayit.Text = $"Son kayıt: {_yonetici.SonKayitZamani?.ToString("HH:mm:ss") ?? "-"}";
        tslDurum.Text = _editorDegisti || _yonetici.KaydedilmemisDegisiklikVar
            ? "Kaydedilmemiş değişiklik var"
            : "Hazır";
    }

    private void HataGoster(string baslik, Exception hata) =>
        MessageBox.Show(this, hata.Message, baslik, MessageBoxButtons.OK, MessageBoxIcon.Error);
}
