using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using aspnetWebApp.Models;
using aspnetWebApp.Data;

namespace aspnetWebApp.Pages;

public class CreateVacancyModel : PageModel
{
    [BindProperty] public string Title { get; set; } = "";
    [BindProperty] public string Description { get; set; } = "";
    [BindProperty] public string City { get; set; } = "";
    [BindProperty] public string Speciality { get; set; } = "";
    [BindProperty] public string Language { get; set; } = "";
    [BindProperty] public string[] Technologies { get; set; } = Array.Empty<string>();

    public void OnGet() { }

    public IActionResult OnPost()
    {
        var vacancy = new Vacancy
        {
            Title = Title,
            Description=Description,
            City = City,
            Speciality = Speciality,
            Language = Language,
            Technologies = Technologies
        };

        VacancyStore.Add(vacancy);
        return new JsonResult(vacancy);
    }

    public IActionResult OnGetVacancy()
    {
        return new JsonResult(VacancyStore.All);
    }

    public IActionResult OnPostDelete(int id)
    {
        var ok = VacancyStore.Delete(id);
        return new JsonResult(new { success = ok });
    }
}