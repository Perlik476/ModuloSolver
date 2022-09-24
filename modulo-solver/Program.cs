// See https://aka.ms/new-console-template for more information

using modulo_solver.Expressions;

var expr = new Multiplication(new Addition(new Constant(3), new Constant(5)), new Constant(2));
const int mod = 6;

Console.WriteLine($"{expr} (mod {mod}) = {expr.Evaluate(mod)}");