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

    public static implicit operator Expression(int a) => new Constant(a);
    public static Expression operator +(Expression a, Expression b) => new Addition(a, b);

    public static Expression operator *(Expression a, Expression b) => new Multiplication(a, b);
    public static Expression operator -(Expression a) => new Negation(a);
    
}