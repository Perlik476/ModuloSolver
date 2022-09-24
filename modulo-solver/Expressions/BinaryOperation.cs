namespace modulo_solver.Expressions;

public class BinaryOperation : Expression
{
    protected readonly Expression Arg1, Arg2;
    private readonly Func<int, int, int, int> _function;
    private readonly char _symbol;

    public BinaryOperation(Func<int, int, int, int> function, char symbol, Expression arg1, Expression arg2)
    {
        _function = function;
        _symbol = symbol;
        Arg1 = arg1;
        Arg2 = arg2;
    }

    public override int Evaluate(int mod)
    {
        return _function(Arg1.Evaluate(mod), Arg2.Evaluate(mod), mod);
    }

    public override string ToString()
    {
        return $"({Arg1} {_symbol} {Arg2})";
    }
    
    public override void GetVariables(HashSet<Variable> variables)
    {
        Arg1.GetVariables(variables);
        Arg2.GetVariables(variables);
    }
}