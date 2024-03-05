using Google.OrTools.LinearSolver;

// Create the linear solver with the GLOP backend.
var solver = Solver.CreateSolver("GLOP");
if (solver is null)
{
    return;
}

// Create the variables x and y.
var x = solver.MakeNumVar(0.0, 1.0, "x");
var y = solver.MakeNumVar(0.0, 2.0, "y");

Console.WriteLine("Number of variables = " + solver.NumVariables());

// Create a linear constraint, 0 <= x + y <= 2.
var ct = solver.MakeConstraint(0.0, 2.0, "ct");
ct.SetCoefficient(x, 1);
ct.SetCoefficient(y, 1);

Console.WriteLine("Number of constraints = " + solver.NumConstraints());

// Create the objective function, 3 * x + y.
var objective = solver.Objective();
objective.SetCoefficient(x, 3);
objective.SetCoefficient(y, 1);
objective.SetMaximization();

solver.Solve();
Console.WriteLine("Solution:");
Console.WriteLine("Objective value = " + solver.Objective().Value());
Console.WriteLine("x = " + x.SolutionValue());
Console.WriteLine("y = " + y.SolutionValue());