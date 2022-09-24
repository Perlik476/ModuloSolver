namespace modulo_solver.Expressions;

public class Multiplication : BinaryOperation
{
    public Multiplication(Expression arg1, Expression arg2) :
        base((x, y, mod) => (x * y) % mod, '*', arg1, arg2) {}
}