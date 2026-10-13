using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using aspnetWebApp.Data;

namespace aspnetWebApp.Pages;

public class ResumesModel : PageModel
{
    public void OnGet() { }

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