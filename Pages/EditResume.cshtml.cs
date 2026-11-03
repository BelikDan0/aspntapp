using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using aspnetWebApp.Models;
using aspnetWebApp.Data;

namespace aspnetWebApp.Pages;

public class EditResumeModel : PageModel
{
    [BindProperty] public int Id { get; set; }
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

    public Student? Student { get; set; }

   public IActionResult OnGet(int id)
{
    Student = StudentStore.GetById(id);
    if (Student == null) return NotFound();

    Id = id;                     // ← ВАЖНО
    Name = Student.Name;
    Phone = Student.Phone;
    Email = Student.Email;
    City = Student.City;
    Speciality = Student.Speciality;
    Language = Student.Language;
    Format = Student.Format;
    Course = Student.Course;
    BirthDate = Student.BirthDate;
    Technologies = Student.Technologies;

    return Page();
}

    public IActionResult OnPost()
    {
        var updated = new Student
        {
            Id = Id,
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

        var ok = StudentStore.Update(updated);
        if (!ok) return NotFound();

        return new JsonResult(updated);
    }
}