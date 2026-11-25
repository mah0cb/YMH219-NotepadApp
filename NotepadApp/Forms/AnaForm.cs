using NotepadApp.Services;

namespace NotepadApp.Forms;

/// <summary>Not defterinin ana penceresi.</summary>
public partial class AnaForm : Form
{
    private readonly NotYoneticisi _yonetici = new(new JsonNotDeposu());

    public AnaForm()
    {
        InitializeComponent();
    }

    private void AnaForm_Load(object? sender, EventArgs e)
    {
        NotlariYukle();
    }

    private void NotlariYukle()
    {
        try
        {
            YuklemeSonucu sonuc = _yonetici.Yukle();
            if (sonuc.UyariMi)
            {
                MessageBox.Show(this, sonuc.Mesaj, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (NotDeposuException ex)
        {
            MessageBox.Show(this, ex.Message, "Yükleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
