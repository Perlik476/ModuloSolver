namespace modulo_solver.Expressions;

public class Inverse : UnaryOperation
{
    public Inverse(Expression arg) : 
        base((x, mod) =>
        {
            for (var y = 1; y < mod; y++)
            {
                if ((x * y) % mod == 1)
                {
                    return y;
                }
            }

            throw new Exception("Inverse does not exist.");
        }, arg) {}

    public override string ToString()
    {
        return $"{Arg}^(-1)";
    }
}