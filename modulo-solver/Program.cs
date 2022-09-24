// See https://aka.ms/new-console-template for more information

using modulo_solver.Expressions;

var expr = new Multiplication(new Addition(new Constant(3), new Constant(5)), new Constant(2));
const int mod = 6;

Console.WriteLine($"{expr} (mod {mod}) = {expr.Evaluate(mod)}");

var eq = new Equation(new Multiplication(new Variable("x"), new Constant(2)));

Console.WriteLine($"Solutions to {eq} in Z/{mod}Z:");
foreach (var solution in eq.Solve(mod))
{
    foreach (var (variable, value) in solution)
    {
        Console.Write($"{variable} = {value}; ");
    }
    Console.WriteLine("");
}

var eqs = new Equations();
eqs.Add(eq);
eqs.Add(new Equation(new Addition(new Variable("y"), new Constant(1))));

Console.WriteLine($"Solutions to {eqs} in Z/{mod}Z:");
foreach (var solution in eqs.Solve(mod))
{
    foreach (var (variable, value) in solution)
    {
        Console.Write($"{variable} = {value}; ");
    }
    Console.WriteLine("");
}

var x = new Variable("x");
var y = new Variable("y");
// var z = new Variable("z");

var eqs2 = new Equations(new List<Equation>() {
        new Equation(new Addition(x, new Addition(y, new Constant(1)))),
        new Equation(new Multiplication(x, y)),
        // new Equation(new Multiplication(x, new Multiplication(y, z))),
        // new Equation(new Addition(y, new Negation(z))),
        // new Equation(new Multiplication(x, new Constant(0))),
    });

Console.WriteLine($"Solutions to {eqs2} in Z/{mod}Z:");
foreach (var solution in eqs2.Solve(mod))
{
    foreach (var (variable, value) in solution)
    {
        Console.Write($"{variable} = {value}; ");
    }
    Console.WriteLine("");
}

// Console.WriteLine($"Solutions to (...) in Z/{mod}Z:");
// foreach (var solution in new Equations() {new Equation(new Addition(x, new Addition(y, new Constant(1))))}.Solve(mod))
// {
//     foreach (var (variable, value) in solution)
//     {
//         Console.Write($"{variable} = {value}; ");
//     }
//     Console.WriteLine("");
// }