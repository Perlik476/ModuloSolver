namespace modulo_solver.Expressions;

public class UnaryOperation : Expression
{
    protected readonly Expression Arg;
    private readonly Func<int, int, int> _function;
    private readonly char _symbol;

    public UnaryOperation(Func<int, int, int> function, char symbol, Expression arg)
    {
        _function = function;
        _symbol = symbol;
        Arg = arg;
    }
    
    public UnaryOperation(Func<int, int, int> function, Expression arg) : this(function, '?', arg) {}

    public override int Evaluate(int mod)
    {
        return _function(Arg.Evaluate(mod), mod);
    }

    public override string ToString()
    {
        return $"({_symbol} {Arg})";
    }
    
    public override void GetVariables(HashSet<Variable> variables)
    {
        Arg.GetVariables(variables);
    }
}