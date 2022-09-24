// See https://aka.ms/new-console-template for more information

using modulo_solver.Expressions;

var expr = new Multiplication(new Addition(new Constant(3), new Constant(5)), new Constant(2));
const int mod = 6;

Console.WriteLine($"{expr} (mod {mod}) = {expr.Evaluate(mod)}");

var eq = new Equation(new Multiplication(new Variable("x"), new Constant(2)));

Console.WriteLine($"Solutions to {eq} (mod {mod}):");
foreach (var solution in eq.Solve(mod))
{
    foreach (var (variable, value) in solution)
    {
        Console.Write($"{variable} = {value}; ");
    }
    Console.WriteLine("");
}
