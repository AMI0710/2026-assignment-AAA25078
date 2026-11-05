namespace LinearAlgebra;

using static Matrix;

///<summary>CG法のパラメータ．Singletonパターン</summary>
/// <remarks>
/// 許容誤差<see cref="Tolerance"/>と最大反復回数<see cref="MaxIterations"/>を設定できる．
/// </remarks>
public class LinearSystemParameters
{
    private LinearSystemParameters() { }

    // 
    public static LinearSystemParameters Instance { get; } = new();
    public double Tolerance { get; set; } = 1e-8;
    public int MaxIterations { get; set; } = 100;

    // あとで何か追加する
}

///<summary>CG法の結果</summary>
/// <remarks>
/// 解<see cref="Solution"/>を返す． 
/// </remarks>
public class LinearSystemResults(double[] solution)
{
    public double[] Solution { get; init; } = Copy(solution);

    // あとで何か追加する
}

///<summary>線形方程式Ax=bを解く</summary>
public static class LinearSystem
{
    ///<summary>Conjugate Gradient Method</summary>
    ///<param name="A">左辺行列</param>
    ///<param name="b">右辺ベクトル</param>
    ///<returns>方程式Ax=bの解x</returns>
    public static double[] Solve(double[,] A, double[] b)
    {
        LinearSystemParameters param = LinearSystemParameters.Instance;
        var n = A.GetLength(0);
        var x0 = new double[n];
        LinearSystemResults res = Solve(A, b, x0, param);
        return res.Solution;
    }

    ///<summary>Conjugate Gradient Method</summary>
    ///<param name="A">左辺行列</param>
    ///<param name="b">右辺ベクトル</param>
    /// <param name="param">GC法のパラメータ</param>
    ///<returns>CG法の結果</returns>
    public static LinearSystemResults Solve(double[,] A, double[] b, double[] x0, LinearSystemParameters param)
    {
    int n = A.GetLength(0);
    double[] x = Copy(x0);
    double[] r = Add(Multiply(A, x), Scalar(b, -1));
    double[] p = Scalar(r, -1);
    for (int k = 0; k < param.MaxIterations; k++)
 {
        double[] Ap = Multiply(A, p);
        double alpha = Inner(r, r) / Inner(p, Ap);
        x = Add(x, Scalar(p, alpha));
        double[] rNew = Add(r, Scalar(Ap, alpha));
        if (Math.Sqrt(Inner(rNew, rNew)) < param.Tolerance)
        {
            break;
        }
        double beta = Inner(rNew, rNew) / Inner(r, r);
        p = Add(Scalar(rNew, -1), Scalar(p, beta));
        r = rNew;
    }

    LinearSystemResults res = new(x);

    return res;
    }
}
