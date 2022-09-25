using System.Runtime.CompilerServices;

namespace modulo_solver.Expressions;

public class Equation : ISolvable
{
    private readonly Expression _expression;

    public Equation(Expression expression)
    {
        _expression = expression;
    }

    private void Solve(ISet<Dictionary<Variable, int>> solutions, IDictionary<Variable, int> valuation,
        IReadOnlyList<Variable> variables, int variableId, int mod)
    {
        for (var value = 0; value < mod; value++)
        {
            var variable = variables[variableId];
            variable.Value = value;
            valuation[variable] = value;
            if (variableId < variables.Count - 1)
            {
                Solve(solutions, valuation, variables, variableId + 1, mod);
            }
            else
            {
                if (_expression.Evaluate(mod) == 0)
                {
                    solutions.Add(new Dictionary<Variable, int>(valuation));
                }
            }
        }
    }
    
    internal HashSet<Dictionary<Variable, int>> Solve(List<Variable> variables, int mod)
    {
        var solutions = new HashSet<Dictionary<Variable, int>>();
        var valuation = new Dictionary<Variable, int>();

        Solve(solutions, valuation, variables, 0, mod);

        return solutions;
    }

    public HashSet<Dictionary<Variable, int>> Solve(int mod) => Solve(_expression.GetVariables().ToList(), mod);

    public HashSet<Dictionary<Variable, int>> Solve(IEnumerable<Dictionary<Variable, int>> possibleValuations, 
        int mod)
    {
        var solutions = new HashSet<Dictionary<Variable, int>>();
        
        foreach (var valuation in possibleValuations)
        {
            foreach (var (variable, value) in valuation)
            {
                variable.Value = value;
            }
            
            if (_expression.Evaluate(mod) == 0)
            {
                solutions.Add(valuation);
            }
        }

        return solutions;
    }

    public HashSet<Variable> Variables => _expression.GetVariables();
    public override string ToString()
    {
        return $"{_expression} = 0";
    }

    public static implicit operator Equation(Expression a) => new(a);
    public static explicit operator Expression(Equation a) => a._expression;
    
    public static Equations operator &(Equation a, Equation b) => new(new List<Equation> { a, b });
    
}