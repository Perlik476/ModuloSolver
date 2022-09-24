namespace modulo_solver.Expressions;

public interface ISolvable
{
    public HashSet<Dictionary<Variable, int>> Solve(int mod);
}