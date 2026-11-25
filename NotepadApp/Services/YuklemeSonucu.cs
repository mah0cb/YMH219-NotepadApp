using NotepadApp.Models;

namespace NotepadApp.Services;

/// <summary>Yükleme sonucu: notlar, kullanıcıya gösterilecek mesaj ve mesajın uyarı olup olmadığı.</summary>
public record YuklemeSonucu(List<Not> Notlar, string Mesaj, bool UyariMi = false);
