namespace Optimizer;

using LinearAlgebra;
using static LinearAlgebra.Matrix;

///<summary>LM法のパラメータ</summary>
public class LMMethodParameters
{
    private LMMethodParameters() { }

    public static LMMethodParameters Instance { get; } = new();
    public double Tolerance { get; set; } = 1e-6;
    public int MaxIterations { get; set; } = 1000;
    public double IncreaseRatio { get; set; } = 2.0;
    public double DecreaseRatio { get; set; } = 0.8;
    public double TrustLimit { get; set; } = 1e+6;
    // あとで何か追加する
}

///<summary>LM法の結果</summary>
public class LMMethodResults(double[] solution)
{
    public double[] Solution { get; init; } = Copy(solution);
    // あとで何か追加する
    public double[]? Residuals { get; set; }
}

/// <summary>
/// LevenbergMarquardt法（修正ガウス・ニュートン法）
/// </summary>
public static class LMMethod
{
    /// <summary>
    /// LevenbergMarquardt法の実行
    /// </summary>
    /// <param name="func">残差関数: Funcデリゲート，1番目の引数は入力ベクトル，2番目の引数は残差ベクトル</param>
    /// <param name="deriv">残差関数のヤコビ行列: Funcデリゲート，1番目の引数は入力ベクトル，2番目の引数は行が残差ベクトルで列が入力ベクトルのヤコビ行列</param>
    /// <param name="x">解の初期値を入力する</param>
    /// <returns>LevenbergMarquardt法で得られた解</returns>
    public static double[] Solve(Func<double[], double[]> func, Func<double[], double[,]> deriv, double[] x)
    {
        LMMethodParameters param = LMMethodParameters.Instance;
        var res = Solve(func, deriv, x, param);
        return res.Solution;
    }

    /// <summary>
    /// LevenbergMarquardt法の実行
    /// </summary>
    /// <param name="func">残差関数: Funcデリゲート，1番目の引数は入力ベクトル，2番目の引数は残差ベクトル</param>
    /// <param name="deriv">残差関数のヤコビ行列: Funcデリゲート，1番目の引数は入力ベクトル，2番目の引数は行が残差ベクトルで列が入力ベクトルのヤコビ行列</param>
    /// <param name="x">解の初期値を入力する</param>
    /// <param name="param">LevenbergMarquardt法のパラメータ</param>
    /// <returns>LevenbergMarquardt法の結果</returns>
    public static LMMethodResults Solve(Func<double[], double[]> func, Func<double[], double[,]> deriv, double[] x, LMMethodParameters param)
    {
        int n = x.Length;
        double lambda = 1.0;
        double[] current = Copy(x);
         for (int k = 0; k < param.MaxIterations; k++)
        {
            // 現在の点における残差関数とヤコビ行列
            double[] f = func(current);
            double[,] D = deriv(current);
            double[,] DT = Transpose(D);

            // (Df(x)^T Df(x) + lambda I)d = -Df(x)^T f(x)
            double[,] left = Add(Multiply(DT, D), Scalar(Eye(n), lambda));
            double[] right = Scalar(Multiply(DT, f), -1.0);

            double[] d = LinearSystem.Solve(left, right);

            // x(k+1) = x(k) + d
            double[] candidate = Add(current, d);
            double[] candidateResiduals = func(candidate);

            // 2乗残差和が減少した場合は更新を受け入れる
            if (Inner(candidateResiduals, candidateResiduals) < Inner(f, f))
            {
                current = candidate;
                lambda *= param.DecreaseRatio;
            }
            else
            {
                // 減少しなければ更新を棄却し、lambdaを大きくする
                lambda *= param.IncreaseRatio;
            }

            // 現在の点での最適性条件
            double[] currentF = func(current);
            double[,] currentD = deriv(current);

            double[] gradient = Scalar(
                Multiply(Transpose(currentD), currentF), 2.0);

            double gradientNormSquared = Inner(gradient, gradient);

            if (gradientNormSquared < param.Tolerance * param.Tolerance
                || lambda > param.TrustLimit)
            {
                break;
            }
        }

        var result = new LMMethodResults(current);
        result.Residuals = func(current);
        return result;
    }
}

