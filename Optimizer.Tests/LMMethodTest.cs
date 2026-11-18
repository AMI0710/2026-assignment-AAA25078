namespace Optimizer.Tests;

using static LinearAlgebra.Matrix;
using Optimizer;

[TestClass]
public class LMMethodTest
{
    [TestMethod]
    public void Test()
    {
        int m = 4;
        int n = 2;
        double[] a = [1.0, 1.0];
        double[][] X = [[3.0, 0.0], [1.0, 0.5], [-0.5, -0.5], [2.0, -3.0]];
        double[] y = [9.0, 2.25, 1.0, 1.0];

        double[] func(double[] z)
        {
            var f = new double[m];
            for (int i = 0; i < m; i++)
            {
                f[i] = Inner(X[i], z);
                f[i] = f[i] * f[i] - y[i];
            }
            return f;
        }
        double[,] deriv(double[] z)
        {
            var D = new double[m,n];
            for (int i = 0; i < m; i++)
            {
                var v = Inner(X[i], z);
                var d = Scalar(X[i], v*2.0);
                SetRow(D, i, 0, d);
            }
            return D;
        }

        var x = LMMethod.Solve(func, deriv, [-1.0, -3.0]);

    
        bool eq1 = true;
        bool eq2 = true;
        for (int i = 0; i < n; i++)
        {
            eq1 &= Math.Abs(+1.0 - x[i] / a[i]) <= 1e-6;
            eq2 &= Math.Abs(-1.0 - x[i] / a[i]) <= 1e-6;
        }
        Assert.IsTrue(eq1 | eq2);
    }
}