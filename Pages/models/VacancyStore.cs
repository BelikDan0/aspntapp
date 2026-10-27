using aspnetWebApp.Models;

namespace aspnetWebApp.Data;

public static class VacancyStore
{
    private static readonly List<Vacancy> _vacancys = new();
    private static int _nextId = 1;

    public static IReadOnlyList<Vacancy> All => _vacancys;

    public static Vacancy Add(Vacancy vacancy)
    {
        vacancy.Id = _nextId++;
        _vacancys.Add(vacancy);
        return vacancy;
    }

    public static bool Delete(int id)
    {
        var s = _vacancys.FirstOrDefault(x => x.Id == id);
        if (s == null) return false;
        _vacancys.Remove(s);
        return true;
    }
}