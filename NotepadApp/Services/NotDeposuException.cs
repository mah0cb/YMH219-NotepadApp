namespace NotepadApp.Services;

/// <summary>Not dosyası okunamadığında veya yazılamadığında Türkçe açıklamayla fırlatılır.</summary>
public class NotDeposuException : Exception
{
    public NotDeposuException(string mesaj, Exception? icHata = null) : base(mesaj, icHata)
    {
    }
}
