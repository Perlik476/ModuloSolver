namespace modulo_solver.Expressions;

public class Negation : UnaryOperation
{
    private static int Mod(int x, int mod) {
        return (x % mod + mod) % mod;
    }
    
    public Negation(Expression arg) : base((x, mod) => Mod(-x, mod), '-', arg) {}
}