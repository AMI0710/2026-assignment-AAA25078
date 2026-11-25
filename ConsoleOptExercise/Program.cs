using LinearAlgebra;
using static LinearAlgebra.Matrix;
using Optimizer;

using ScottPlot;
using System.CommandLine;
using System.CommandLine.Parsing;

internal class Program
{
    static double[,] A = { { 1.0, -0.1 }, { -0.1, 3.0 } };
    static double[,] B = { { 0.0, 1.0 }, { 1.0, 0.0 } };

    static double[] func(double[] z)
    {
        var x = GetSubvector(z, 0, 2);
        var lam = z[2];
        var f1 = Add(Multiply(A, x), Scalar(Multiply(B, x), lam));
        var f2 = Inner(x, Multiply(B, x)) - 1.0;
        double[] f = new double[3];
        SetSubvector(f, 0, f1);
        f[2] = f2;
        return f;
    }

    static double[,] deriv(double[] z)
    {
        var x = GetSubvector(z, 0, 2);
        var lam = z[2];
        var AB = Add(A, Scalar(B, lam));
        var Bx = Multiply(B, x);
        var D = new double[3, 3];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                D[i, j] = AB[i, j];
            }
        }
        SetColumn(D, 2, 0, Bx);
        SetRow(D, 2, 0, Scalar(Bx, 2.0));
        return D;
    }
        
    private static int Main(string[] args)
    {
        RootCommand rootCommand = new("Exercise for console app");

        Option<string> outputOption = new("--output")
        {
            Description = "output file name",
            DefaultValueFactory = _ => "a",
            Required = false,
            Arity = ArgumentArity.ExactlyOne
        };
        rootCommand.Options.Add(outputOption);
        
        Option<double> decreaseRatioOption = new("--decratio")
        {
            Description = "decrease ratio for LMMethod",
            DefaultValueFactory = _ => 0.8,
            Required = false,
            Arity = ArgumentArity.ExactlyOne            
        };
        rootCommand.Options.Add(decreaseRatioOption);

        ParseResult parseResult = rootCommand.Parse(args);

        if (parseResult.Errors.Count > 0)
        {
            foreach (ParseError parseError in parseResult.Errors)
            {
                Console.Error.WriteLine(parseError.Message);
            }
            return 1;
        }

        var output = parseResult.GetValue(outputOption);
        // var output = "a";
        var decreaseRatio = parseResult.GetValue(decreaseRatioOption);
        // var decreaseRatio = 0.8;

        LMMethodParameters param = LMMethodParameters.Instance;
        param.MaxIterations = 1000;
        param.Tolerance = 1e-3;
        param.DecreaseRatio = decreaseRatio;
        double[] init = [1.0, 1.0, -1.0];
        LMMethodResults res = LMMethod.Solve(Program.func, Program.deriv, init, param);

        var sol = res.Solution;
        for (int i = 0; i < 3; i++)
        {
            Console.Write($"{sol[i]},");
        }
        Console.WriteLine();

        var residuals = res.Residuals;
        if (residuals is not null)
        {
            var plt = new Plot();
            var logResiduals = residuals.Select(r => Math.Log10(r)).ToArray();
            plt.Add.Signal(logResiduals);
            plt.SavePng(output + ".png", 400, 300);
        }

        return 0;
    }
}