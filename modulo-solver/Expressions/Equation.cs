using System.Collections;

namespace modulo_solver.Expressions;

public class Equation : Solvable
{
    private Expression _expression;

    public Equation(Expression expression)
    {
        _expression = expression;
    }

    private void Solve(ISet<Dictionary<Variable, int>> solutions, Dictionary<Variable, int> valuation,
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

    public override HashSet<Dictionary<Variable, int>> Solve(int mod)
    {
        var solutions = new HashSet<Dictionary<Variable, int>>();
        var valuation = new Dictionary<Variable, int>();
        var variables = _expression.GetVariables().ToList();

        Solve(solutions, valuation, variables, 0, mod);

        return solutions;
    }

    public override string ToString()
    {
        return $"{_expression} = 0";
    }
}