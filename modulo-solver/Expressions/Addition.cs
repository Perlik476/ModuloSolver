namespace modulo_solver.Expressions;

public class Addition : BinaryOperation
{
    public Addition(Expression arg1, Expression arg2) : 
        base((x, y, mod) => (x + y) % mod, '+', arg1, arg2) {}
}