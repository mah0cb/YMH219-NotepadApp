namespace NotepadApp.Services;

/// <summary>RichTextBox'ta seçili metnin kalın, italik ve altı çizili biçimini açıp kapatır.</summary>
public class MetinBicimleyici
{
    /// <summary>Seçimin tamamında biçim varsa kaldırır, yoksa tamamına uygular; diğer biçimlere dokunmaz.</summary>
    public void BicimDegistir(RichTextBox kutu, FontStyle bicim)
    {
        if (kutu.SelectionLength > 0)
        {
            SecimiBicimle(kutu, bicim);
            return;
        }

        Font imlecFontu = kutu.SelectionFont ?? kutu.Font;
        kutu.SelectionFont = new Font(imlecFontu, imlecFontu.Style ^ bicim);
    }

    // SelectionFont, farklı biçimler içeren seçimde tek tek biçimleri vermez; bu yüzden karakter karakter ilerlenir.
    // Çok uzun seçimlerde yavaştır, gerekirse EM_SETCHARFORMAT kullanılabilir.
    private static void SecimiBicimle(RichTextBox kutu, FontStyle bicim)
    {
        int baslangic = kutu.SelectionStart;
        int uzunluk = kutu.SelectionLength;

        bool tamaminda = true;
        for (int i = baslangic; i < baslangic + uzunluk && tamaminda; i++)
        {
            kutu.Select(i, 1);
            tamaminda = kutu.SelectionFont?.Style.HasFlag(bicim) ?? true;
        }

        for (int i = baslangic; i < baslangic + uzunluk; i++)
        {
            kutu.Select(i, 1);
            if (kutu.SelectionFont is Font font)
            {
                FontStyle yeniBicim = tamaminda ? font.Style & ~bicim : font.Style | bicim;
                kutu.SelectionFont = new Font(font, yeniBicim);
            }
        }

        kutu.Select(baslangic, uzunluk);
    }

    /// <summary>Notun biçimli halini gösterir; RTF yoksa veya bozuksa düz metni kullanır.</summary>
    public void IcerigiGoster(RichTextBox kutu, string rtf, string duzMetin)
    {
        kutu.Clear();
        kutu.SelectionFont = kutu.Font;
        if (rtf.Length > 0)
        {
            try
            {
                kutu.Rtf = rtf;
                return;
            }
            catch (ArgumentException)
            {
                // Biçim okunamadı; aşağıda düz metin gösterilir.
            }
        }

        kutu.Text = duzMetin;
    }
}
