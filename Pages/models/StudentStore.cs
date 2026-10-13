using aspnetWebApp.Models;

namespace aspnetWebApp.Data;

public static class StudentStore
{
    private static readonly List<Student> _students = new();
    private static int _nextId = 1;

    public static IReadOnlyList<Student> All => _students;

    public static Student Add(Student student)
    {
        student.Id = _nextId++;
        _students.Add(student);
        return student;
    }

    public static bool Delete(int id)
    {
        var s = _students.FirstOrDefault(x => x.Id == id);
        if (s == null) return false;
        _students.Remove(s);
        return true;
    }
}