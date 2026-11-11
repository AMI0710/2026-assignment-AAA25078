namespace LinearAlgebra.Tests;

using static LinearAlgebra.Matrix;
using LinearAlgebra;

[TestClass]
public class EigenvectorTest
{
    [TestMethod]
    public void Test()
    {
        int n = 2;
        double[] a1 = [0.5, Math.Sqrt(3) / 2.0];
        double[] a2 = [Math.Sqrt(3) / 2.0, -0.5];
        double lam1 = 2.0;
        double lam2 = 1.0;

        var A1 = Outer(a1, a1);
        A1 = Scalar(A1, lam1);
        var A2 = Outer(a2, a2);
        A2 = Scalar(A2, lam2);
        var B = Add(A1, A2);

        var res = Eigenvector.Solve(B, EigenvectorParameters.Instance);
        var lam = res.Eigenvalue;
        var v = res.Eigenvector;

        if (v[0] < 0)
        {
            v = Scalar(v, -1.0);
        }

        for (int i = 0; i < n; i++)
        {
            Assert.AreEqual(1, v[i] / a1[i], 1e-6);
        }
        Assert.AreEqual(1, lam / lam1, 1e-6);
    }
}