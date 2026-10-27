namespace aspnetWebApp.Models;
public class Vacancy
{
    public int Id {get;set;}
    public string Title { get; set; }="";
    public string Description { get; set; }="";
    
    public string City{get;set;}="";
    
    public string Speciality { get; set; }="";
    
    public string Language{get;set;}="";
    
    public string[] Technologies { get; set; } = Array.Empty<string>();
}