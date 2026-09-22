using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetWebApp.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public string Name { get; set; }
    [BindProperty]
    public string Phone { get; set; }
    [BindProperty]
    public string Email { get; set; }
    [BindProperty]
    public string City{get;set;}
    [BindProperty]
    public string Speciality { get; set; }
    [BindProperty]
    public string Language{get;set;}
    [BindProperty]
    public string Format{get;set;}
    [BindProperty]
    public string Course { get; set; }
    [BindProperty]
    public string BirthDate { get; set; }
    [BindProperty]
    public string[] Technologies { get; set; } = Array.Empty<string>();
    public string Message { get; set; }
    public void OnGet()
    {
        // Message = "Привет! Сообщение от C#";
    }
    public IActionResult OnPost() {
        
        string technologies = Technologies.Length > 0
            ? string.Join(", ", Technologies)
            : "Не выбраны";

        // string message = $"Анкета студента\n\n" +
        //         $"Имя: {Name}\n" + 
        //         $"Телефон: {Phone}\n" +
        //         $"Email: {Email}\n" +
        //         $"City: {City}\n"+
        //         $"Специальность: {Speciality}\n" +
        //         $"Язык програмирования: {Language}\n"+
        //         $"Курс: {Course}\n" +
        //         $"Дата рождения: {BirthDate}\n" +
        //         $"Технологии: {technologies}";
        var student = new {
            name = Name,
            phone = Phone,
            email = Email,
            city = City,
            speciality = Speciality,
            language = Language,
            course = Course,
            birthDate = BirthDate,
            technologies = technologies
        };
        return Content(JsonSerializer.Serialize(student),"application/json");
    }

}
