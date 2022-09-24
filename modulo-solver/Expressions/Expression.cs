namespace modulo_solver.Expressions;

public abstract class Expression
{
    public abstract int Evaluate(int mod);

    public virtual void GetVariables(HashSet<Variable> variables) {}

    public HashSet<Variable> GetVariables()
    {
        var variables = new HashSet<Variable>();
        GetVariables(variables);
        return variables;
    }
}