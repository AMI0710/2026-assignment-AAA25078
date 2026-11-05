using Statistics;

namespace LinearAlgebra;

///<summary>基本的な行列計算</summary>
public static class Matrix
{
    ///<summary>単位行列を作成</summary>
    ///<param name="n">行列の大きさ</param>
    ///<returns>(n,n)の単位行列</returns>
    public static double[,] Eye(int n)
    {
        return new double[0, 0];
    }

    ///<summary>要素がすべて1の行列</summary>
    ///<param name="m">行の数</param>
    ///<param name="n">列の数</param>
    ///<returns>要素がすべて1の(m,n)の行列</returns>
    public static double[,] Ones(int m, int n)
    {
        return new double[0, 0];
    }

    ///<summary>要素がすべて1のベクトル</summary>
    ///<param name="n">ベクトル長さ</param>
    ///<returns>要素がすべて1の長さnのベクトル</returns>
    public static double[] Ones(int n)
    {
        return new double[0];
    }

    /// <summary>一様分布で初期化された行列を生成</summary>
    /// <param name="m">列の長さ</param>
    /// <param name="n">行の長さ</param>
    /// <param name="rand">疑似乱数生成器</param>
    /// <returns>生成された行列</returns>
    public static double[,] Uniform(int m, int n, Random rand)
    {
        return new double[0, 0];
    }

    /// <summary>一様分布で初期化されたベクトルを生成</summary>
    /// <param name="n">ベクトルの長さ</param>
    /// <param name="rand">疑似乱数生成器</param>
    /// <returns>生成されたベクトル</returns>
    public static double[] Uniform(int n, Random rand)
    {
        return new double[0];
    }

    /// <summary>正規分布で初期化された行列を生成</summary>
    /// <param name="m">行の長さ</param>
    /// <param name="n">列の長さ</param>
    /// <param name="rand">疑似乱数生成器</param>
    /// <returns>生成された行列</returns>
    public static double[,] Normal(int m, int n, Random rand)
    {
        return new double[0, 0];
    }

    /// <summary>正規分布で初期化されたベクトルを生成</summary>
    /// <param name="n">ベクトルの長さ</param>
    /// <param name="rand">疑似乱数生成器</param>
    /// <returns>生成されたベクトル</returns>
    public static double[] Normal(int n, Random rand)
    {
        return new double[0];
    }

    ///<summary>行列をコピーする</summary>
    ///<param name="X">コピー元</param>
    ///<returns>コピー先</returns>
    public static double[,] Copy(double[,] X)
    {
        return new double[0, 0];
    }

    ///<summary>ベクトルをコピーする</summary>
    ///<param name="x">コピー元</param>
    ///<returns>コピー先</returns>
    public static double[] Copy(double[] x)
    {
        return new double[0];
    }

    ///<summary>行列をコピーする</summary>
    ///<param name="X">コピー元</param>
    ///<param name="Y"=>コピー先</param>
    public static void Copy(double[,] X, double[,] Y)
    {

    }

    ///<summary>ベクトルをコピーする</summary>
    ///<param name="x">コピー元</param>
    ///<param name="y"=>コピー先</param>
    public static void Copy(double[] x, double[] y)
    {

    }

    ///<summary>転置</summary>
    ///<param name="X">入力行列</param>
    ///<returns>転置された行列</returns>
    public static double[,] Transpose(double[,] X)
    {
        return new double[0, 0];
    }

    ///<summary>行列のスカラー倍: alpha*X</summary>
    ///<param name="X">スカラー倍される行列</param>
    ///<param name="alpha">数値</param>
    ///<returns>スカラー倍された行列</returns>
    public static double[,] Scalar(double[,] X, double alpha)
    {
        return new double[0, 0];
    }

    ///<summary>ベクトルのスカラー倍: alpha*x</summary>
    ///<param name="x">スカラー倍されるベクトル</param>
    ///<param name="alpha">数値</param>
    ///<returns>スカラー倍されたベクトル</returns>
    public static double[] Scalar(double[] x, double alpha)
    {
        return new double[0];
    }

    ///<summary>行列の加算: X + Y</summary>
    ///<param name="X">入力行列</param>
    ///<param name="Y">入力行列</param>
    ///<returns>結果の行列</returns>
    public static double[,] Add(double[,] X, double[,] Y)
    {
        return new double[0, 0];
    }

    ///<summary>ベクトルの加算: x + y</summary>
    ///<param name="x">入力ベクトル</param>
    ///<param name="y">入力ベクトル</param>
    ///<returns>結果のベクトル</returns>
    public static double[] Add(double[] x, double[] y)
    {
        return new double[0];
    }

    /// <summary>行列Xの各成分にaを足す</summary>
    /// <param name="X">入力行列</param>
    /// <param name="a">数値</param>
    /// <returns>結果の行列</returns>
    public static double[,] Add(double[,] X, double a)
    {
        return new double[0, 0];
    }

    /// <summary>ベクトルxの各成分にaを足す</summary>
    /// <param name="x">入力ベクトル</param>
    /// <param name="a">数値</param>
    /// <returns>結果のベクトル</returns>
    public static double[] Add(double[] x, double a)
    {
        return new double[0];
    }

    ///<summary>行列の成分ごとの乗算: Z[i,j] = X[i,j] * Y[i,j]</summary>
    ///<param name="X">入力行列</param>
    ///<param name="Y">入力行列</param>
    ///<returns>結果の行列</returns>
    public static double[,] CwiseMultiply(double[,] X, double[,] Y)
    {
        return new double[0, 0];
    }

    /// <summary>ベクトルの成分ごとの乗算: z[i] = x[i] * y[i]</summary>
    /// <param name="x">入力ベクトル</param>
    /// <param name="y">入力ベクトル</param>
    /// <returns>結果のベクトル</returns>
    public static double[] CwiseMultiply(double[] x, double[] y)
    {
        return new double[0];
    }

    /// <summary>行列の成分ごとの除算: Z[i,j] = X[i,j] / Y[i,j]</summary>
    /// <param name="X">入力行列</param>
    /// <param name="Y">入力行列</param>
    /// <returns>結果の行列</returns>
    public static double[,] CwiseDivide(double[,] X, double[,] Y)
    {
        return new double[0, 0];
    }

    /// <summary>ベクトルの成分ごとの除算: z[i] = x[i] / y[i]</summary>
    /// <param name="x">入力ベクトル</param>
    /// <param name="y">入力ベクトル</param>
    /// <returns>結果のベクトル</returns>
    public static double[] CwiseDivide(double[] x, double[] y)
    {
        return new double[0];
    }

    ///<summary>行列の乗算: X * Y</summary>
    ///<param name="X">左の入力行列</param>
    ///<param name="Y">右の入力行列</param>
    ///<param name="Z">結果の行列</param>
    public static double[,] Multiply(double[,] X, double[,] Y)
    {
        return new double[0, 0];
    }

    ///<summary>行列とベクトルの乗算: X * y</summary>
    ///<param name="X">左の入力行列</param>
    ///<param name="y">右の入力ベクトル（列ベクトル）</param>
    ///<returns>結果のベクトル</returns>
    public static double[] Multiply(double[,] X, double[] y)
    {
        return new double[0];
    }

    ///<summary>ベクトルと行列の乗算: x * Y</summary>
    ///<param name="x">左の入力ベクトル（行ベクトル）</param>
    ///<param name="Y">右の入力行列</param>
    ///<returns>結果のベクトル</returns>
    public static double[] Multiply(double[] x, double[,] Y)
    {
        return new double[0];
    }

    ///<summary>内積</summary>
    ///<param name="x">入力ベクトル</param>
    ///<param name="y">入力ベクトル</param>
    ///<returns>xとyの内積</returns>
    public static double Inner(double[] x, double[] y)
    {
        return 0.0;
    }

    ///<summary>外積</summary>
    ///<param name="x">左の入力ベクトル</param>
    ///<param name="y">右の入力ベクトル</param>
    ///<returns>xとyの外積で得られる行列</returns>
    public static double[,] Outer(double[] x, double[] y)
    {
        return new double[0, 0];
    }

    ///<summary>行列から指定された列ベクトル取り出す: X[pos:pos+len,col]</summary>
    ///<param name="X">入力行列</param>
    ///<param name="col">列の添字</param>
    ///<param name="pos">取り出す開始位置</param>
    ///<param name="len">取り出すベクトルの長さ</param>
    ///<returns>取り出されたベクトル</returns>
    public static double[] GetColumn(double[,] X, int col, int pos, int len)
    {
        return new double[0];
    }

    ///<summary>行列の指定された列にベクトルを代入: X[pos:pos+len,col] = y</summary>
    ///<param name="X">入力行列</param>
    ///<param name="col">列の添字</param>
    ///<param name="pos">代入する開始位置</param>
    ///<param name="y">代入するベクトル</param>
    public static void SetColumn(double[,] X, int col, int pos, double[] y)
    {

    }

    ///<summary>行列から指定された行ベクトル取り出す: X[row,pos:pos+len]</summary>
    ///<param name="X">入力行列</param>
    ///<param name="row">行の添字</param>
    ///<param name="pos">取り出す開始位置</param>
    ///<param name="len">取り出すベクトルの長さ</param>
    ///<returns>取り出されたベクトル</returns>
    public static double[] GetRow(double[,] X, int row, int pos, int len)
    {
        return new double[0];
    }

    ///<summary>行列の指定された行にベクトルを代入: X[row,pos:pos+len] = y</summary>
    ///<param name="X">入力行列</param>
    ///<param name="row">行の添字</param>
    ///<param name="pos">代入する開始位置</param>
    ///<param name="y">代入するベクトル</param>
    public static void SetRow(double[,] X, int row, int pos, double[] y)
    {

    }

    ///<summary>ベクトルから指定された部分ベクトルを取り出す</summary>
    ///<param name="x">入力ベクトル</param>
    ///<param name="pos">取り出す開始位置</param>
    ///<param name="len">取り出すベクトルの長さ</param>
    ///<returns>取り出されたベクトル</returns>
    public static double[] GetSubvector(double[] x, int pos, int len)
    {
        return new double[0];
    }

    ///<summary>ベクトルの指定された部分に別のベクトルを代入</summary>
    ///<param name="x">入力ベクトル<</param>
    ///<param name="pos">代入する開始位置</param>
    ///<param name="y">代入するベクトル</param>
    public static void SetSubvector(double[] x, int pos, double[] y)
    {

    }

    ///<summary>行列の成分ごとに関数を適用: Y[i,j] = f(X[i,j])</summary>
    ///<param name="x">入力行列</param>
    ///<param name="f">適用する関数</param>
    ///<results>結果として得られる行列</results> 
    public static double[,] CwiseFunction(double[,] X, Func<double, double> f)
    {
        return new double[0, 0];
    }

    ///<summary>ベクトルの成分ごとに関数を適用: y[i] = f(x[i])</summary>
    ///<param name="x">入力ベクトル</param>
    ///<param name="f">適用する関数</param>
    ///<results>結果として得られるベクトル</results>
    public static double[] CwiseFunction(double[] x, Func<double, double> f)
    {
        return new double[0];
    }
}
