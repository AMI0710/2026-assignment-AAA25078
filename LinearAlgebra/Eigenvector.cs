namespace LinearAlgebra;

using static Matrix;

///<summary>べき乗法のパラメータ．Singletonパターン</summary>
/// <remarks>
/// 許容誤差<see cref="Tolerance"/>と最大反復回数<see cref="MaxIterations"/>を設定できる．
/// </remarks>
public class EigenvectorParameters
{
    private EigenvectorParameters() { }
    public static EigenvectorParameters Instance { get; } = new();
    public double Tolerance { get; set; } = 1e-8;
    public int MaxIterations { get; set; } = 1000;

    // あとで何か追加する
}

///<summary>べき法の結果</summary>
/// <remarks>
/// 固有値<see cref="Eigenvalue"/>と固有ベクトル<see cref="Eigenvector"/>を返す． 
/// </remarks>
public class EigenvectorResults(double eigenvalue, double[] eigenvector)
{
    public double Eigenvalue { get; init; } = eigenvalue;
    public double[] Eigenvector { get; init; } = Copy(eigenvector);
    public double[]? Residuals { get; set; }

    // あとで何か追加する
}

///<summary>固有値と固有ベクトル(Av=λv)を求める</summary>
public static class Eigenvector
{
    ///<summary>Power Iteration</summary>
    ///<param name="A">入力: 行列</param>
    ///<returns>Aの絶対値が最大の固有値 (double), 対応する固有ベクトル (double[])</returns>
    public static (double, double[]) Solve(double[,] A)
    {
        var res = Solve(A, EigenvectorParameters.Instance);
        return (res.Eigenvalue, res.Eigenvector);
    }

    ///<summary>Power Iteration</summary>
    ///<param name="A">入力: 行列</param>
    ///<param name="param">Power Iterationのパラメータ</param>
    ///<returns>Power Iterationの結果</returns>
    public static EigenvectorResults Solve(double[,] A, EigenvectorParameters param)
    {
        int n = A.GetLength(0);
        Random rand = new Random();

        double[] v = new double[n];
        for (int i = 0; i < n; i++)
        {
            v[i] = rand.NextDouble();
        }

        double lam = 0.0;

        for (int iter = 0; iter < param.MaxIterations; iter++)
        {
            var w = Multiply(A, v);

            double norm = Math.Sqrt(Inner(w, w));

            if (norm == 0.0)
            {
                throw new Exception("Eigenvector: zero vector");
            }
            w = Scalar(w, 1.0 / norm);
            lam = Inner(w, Multiply(A, w));
            var Aw = Multiply(A, w);
            double[] r = new double[n];

            for (int i = 0; i < n; i++)
            {
                r[i] = Aw[i] - lam * w[i];
            }
            double residual = Math.Sqrt(Inner(r, r));
            v = w;
            if (residual < param.Tolerance)
            {
                break;
            }
        }
        return new EigenvectorResults(lam, v);
    }
}