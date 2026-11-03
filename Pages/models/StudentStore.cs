using aspnetWebApp.Models;

namespace aspnetWebApp.Data;

public static class StudentStore
{
    private static readonly List<Student> _students = new();
    private static int _nextId = 1;

    public static IReadOnlyList<Student> All => _students;

    public static Student? GetById(int id) => _students.FirstOrDefault(s => s.Id == id);

    public static Student Add(Student student)
    {
        student.Id = _nextId++;
        _students.Add(student);
        return student;
    }

    public static bool Update(Student updated)
    {
        var existing = _students.FirstOrDefault(s => s.Id == updated.Id);
        if (existing == null) return false;

        existing.Name = updated.Name;
        existing.Phone = updated.Phone;
        existing.Email = updated.Email;
        existing.City = updated.City;
        existing.Speciality = updated.Speciality;
        existing.Language = updated.Language;
        existing.Format = updated.Format;
        existing.Course = updated.Course;
        existing.BirthDate = updated.BirthDate;
        existing.Technologies = updated.Technologies;

        return true;
    }

    public static bool Delete(int id)
    {
        var s = _students.FirstOrDefault(x => x.Id == id);
        if (s == null) return false;
        _students.Remove(s);
        return true;
    }
}