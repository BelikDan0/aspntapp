using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using aspnetWebApp.Models;
using aspnetWebApp.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace aspnetWebApp.Pages;
[Authorize]



public class CreateResumeModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public CreateResumeModel(ApplicationDbContext context)
    {
        _context=context;
    }
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

   public async Task<IActionResult> OnPostAsync()
    {
        // Хорошая практика: проверяем, что данные валидны, перед сохранением
        if (!ModelState.IsValid)
        {
            return Page(); // Если есть ошибки, остаемся на той же странице и показываем их
        }
        var userId=User.FindFirstValue(ClaimTypes.NameIdentifier);

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
            Technologies = Technologies,
            UserId=userId,
        };

        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Index"); 
        
        
    }

    public IActionResult OnGetStudents()
    {
        var students=_context.Students.ToListAsync();
        return new JsonResult(students);
    }

    public async Task<IActionResult> OnPostDelete(int id)
    {
        var student= await _context.Students.FindAsync(id);
        if (student == null)
        {
            return new JsonResult(new { success = false, message = "Не найдено" });
        }
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (student.UserId != currentUserId)
        {
            return new JsonResult(new { success = false, message = "Нет прав на удаление" });
        }

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();

        return new JsonResult(new { success = true });
    }
}