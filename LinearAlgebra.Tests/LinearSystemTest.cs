namespace LinearAlgebra.Tests;

using static LinearAlgebra.Matrix;
using LinearAlgebra;

[TestClass]
public class LinearSystemTest
{
    readonly Random rand = new();

    [TestMethod]
    public void Test()
    {
        int n = 5;
        int m = n * 2;

        for (int k = 0; k < 10; k++)
        {
            var A = Uniform(m, n, rand);

            var C = Multiply(Transpose(A), A);

            var z = Uniform(n, rand);

            var b = Multiply(C, z);

            var x0 = new double[n];

            var res = LinearSystem.Solve(C, b, x0, LinearSystemParameters.Instance);
            var x = res.Solution;

            for (int i = 0; i < n; i++)
            {
                Assert.AreEqual(1, z[i] / x[i], 1e-6);
            }
        }
    }
}