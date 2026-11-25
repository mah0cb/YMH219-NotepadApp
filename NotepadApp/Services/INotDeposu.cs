using NotepadApp.Models;

namespace NotepadApp.Services;

/// <summary>Notların kalıcı olarak saklandığı yeri soyutlar.</summary>
public interface INotDeposu
{
    string DosyaYolu { get; }

    /// <exception cref="NotDeposuException">Notlar okunamadığında fırlatılır.</exception>
    YuklemeSonucu Yukle();

    /// <exception cref="NotDeposuException">Notlar yazılamadığında fırlatılır.</exception>
    void Kaydet(List<Not> notlar);
}
