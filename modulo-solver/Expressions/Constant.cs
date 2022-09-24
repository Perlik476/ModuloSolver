namespace modulo_solver.Expressions;

public class Constant : Expression
{
    private readonly int _value;

    public Constant(int value) => _value = value;

    public override int Evaluate(int mod)
    {
        return _value % mod;
    }

    public override string ToString()
    {
        return _value.ToString();
    }
}