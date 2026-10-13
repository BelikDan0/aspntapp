using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using aspnetWebApp.Models;
using aspnetWebApp.Data;

namespace aspnetWebApp.Pages;

public class CreateResumeModel : PageModel
{
    [BindProperty] public string Name { get; set; } = "";
    [BindProperty] public string Phone { get; set; } = "";
    [BindProperty] public string Email { get; set; } = "";
    [BindProperty] public string City { get; set; } = "";
    [BindProperty] public string Speciality { get; set; } = "";
    [BindProperty] public string Language { get; set; } = "";
    [BindProperty] public string Format { get; set; } = "";
    [BindProperty] public string Course { get; set; } = "";
    [BindProperty] public string BirthDate { get; set; } = "";
    [BindProperty] public string[] Technologies { get; set; } = Array.Empty<string>();

    public void OnGet() { }

    public IActionResult OnPost()
    {
        var student = new Student
        {
            Name = Name,
            Phone = Phone,
            Email = Email,
            City = City,
            Speciality = Speciality,
            Language = Language,
            Format = Format,
            Course = Course,
            BirthDate = BirthDate,
            Technologies = Technologies
        };

        StudentStore.Add(student);
        return new JsonResult(student);
    }

    public IActionResult OnGetStudents()
    {
        return new JsonResult(StudentStore.All);
    }

    public IActionResult OnPostDelete(int id)
    {
        var ok = StudentStore.Delete(id);
        return new JsonResult(new { success = ok });
    }
}