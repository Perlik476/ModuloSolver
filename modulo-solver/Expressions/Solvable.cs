namespace modulo_solver.Expressions;

public abstract class Solvable
{
    public abstract HashSet<Dictionary<Variable, int>> Solve(int mod);
}