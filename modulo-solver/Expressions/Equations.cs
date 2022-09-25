using System.Collections;

namespace modulo_solver.Expressions;

public class Equations : ISolvable, ICollection<Equation>
{
    private List<Equation> _equations;
    public Equations() => _equations = new();
    
    public Equations(IEnumerable<Equation> equations) => _equations = new(equations);

    public HashSet<Dictionary<Variable, int>> Solve(int mod)
    {
        if (Count == 0)
            return new();

        HashSet<Variable> variables = new();
        foreach (var equation in _equations)
        {
            variables.UnionWith(equation.Variables);
        }

        var variablesList = variables.ToList();

        HashSet<Dictionary<Variable, int>> solutions = new();
        foreach (var (equation, i) in _equations.Select((eq, i) => (eq, i)))
        {
            solutions = i == 0 ? equation.Solve(variablesList, mod) : equation.Solve(solutions, mod);
        }

        return solutions;
    }

    public IEnumerator<Equation> GetEnumerator() => _equations.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _equations.GetEnumerator();

    public void Add(Equation item) => _equations.Add(item);

    public void Clear() => _equations.Clear();

    public bool Contains(Equation item) => _equations.Contains(item);

    public void CopyTo(Equation[] array, int arrayIndex) => _equations.CopyTo(array, arrayIndex);

    public bool Remove(Equation item) => _equations.Remove(item);
    public int Count => _equations.Count;

    public bool IsReadOnly => false;

    public override string ToString()
    {
        return _equations.Select(eq => eq.ToString()).Aggregate("", (acc, eq) => acc + $"{eq}; ");
    }

    public static implicit operator Equations(Equation a) => new(new List<Equation>{a});
    
    public static Equations operator &(Equations a, Equations b)
    {
        var equations = new List<Equation>(a);
        equations.AddRange(b);
        return new Equations(equations);
    }
    
    public static Equations operator &(Equations a, Equation b)
    {
        var equations = new List<Equation>(a);
        equations.Add(b);
        return new Equations(equations);
    }

    public static Equations operator &(Equation a, Equations b) => (b & a);
}