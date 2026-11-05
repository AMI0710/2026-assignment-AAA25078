namespace Statistics;

/// <summary>A class for random sampling.</summary>
public static class RandomSampling
{
    /// <summary>generate a sample from the standard normal distribution.</summary>
    /// <param name="rng">pseudo-random generator</param>
    public static double Normal(Random? rng = null)
    {
        rng ??= Random.Shared;
        var u1 = rng.NextDouble();
        var u2 = rng.NextDouble();
        var z1 = Math.Sqrt(-2 * Math.Log(u1)) * Math.Cos(2 * Math.PI * u2);
        // double z2 = Math.Sqrt(-2 * Math.Log(u1)) * Math.Sin(2 * Math.PI * u2);
        return z1;
    }

    /// <summary> generate a random permutation of size <c>size</c>. </summary>
    /// <param name="size">size of a permutation</param>
    /// <param name="rng">pseudo-random generator</param>
    /// <returns>random permutation</returns>
    public static int[] RandPerm(int size, Random? rng = null)
    {
        rng ??= Random.Shared;
        var res = Enumerable.Range(0, size).ToArray();
        rng.Shuffle(res);
        return res;
    }
}
