using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using aspnetWebApp.Data;

namespace aspnetWebApp.Pages;

public class VacancysModel : PageModel
{
    public void OnGet() { }

    public IActionResult OnGetVacancys()
    {
        return new JsonResult(VacancyStore.All);
    }

    public IActionResult OnPostDelete(int id)
    {
        var ok = VacancyStore.Delete(id);
        return new JsonResult(new { success = ok });
    }
}