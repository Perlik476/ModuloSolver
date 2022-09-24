namespace modulo_solver.Expressions;

public class Variable : Expression
{
    public int Value { get; set; }
    public string Name { get; set; }

    public Variable(string name, int value = 0)
    {
        Name = name;
        Value = value;
    }

    public override int Evaluate(int mod)
    {
        return Value % mod;
    }

    public override string ToString()
    {
        return Name;
    }

    public override void GetVariables(HashSet<Variable> variables)
    {
        variables.Add(this);
    }
}