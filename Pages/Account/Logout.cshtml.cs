using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using aspnetWebApp.Models;

namespace aspnetWebApp.Pages.Account;

public class LogoutModel : PageModel
{
    private readonly SignInManager<ApplicationUser> _signInManager;

    public LogoutModel(SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
    }

    // Выход обрабатывается только через POST-запрос для безопасности
    public async Task<IActionResult> OnPostAsync()
    {
        // Очищаем cookie аутентификации
        await _signInManager.SignOutAsync();

        // Перенаправляем пользователя на главную страницу (как в Register)
        return RedirectToPage("/Index");
    }
}