namespace Statistics.Tests;

[TestClass]
public sealed class RandomSamplingTests
{
    [TestMethod]
    public void Normal_SameSeed_ReturnsSameValue()
    {
        Assert.AreEqual(RandomSampling.Normal(new Random(42)), RandomSampling.Normal(new Random(42)));
    }

    [TestMethod]
    public void Normal_Samples_MatchStandardNormal()
    {
        const int n = 100000;
        var samples = Enumerable.Range(0, n).Select(_ => RandomSampling.Normal()).ToArray();

        var mean = samples.Average();
        var variance = samples.Sum(x => (x - mean) * (x - mean)) / (n - 1);
        var withinOneSigma = samples.Count(x => Math.Abs(x) < 1.0) / (double)n;

        Assert.IsTrue(samples.All(double.IsFinite));
        // standard error of the mean is 1/sqrt(n) ≈ 0.003, so these bounds are generous
        Assert.AreEqual(0.0, mean, 0.02);
        Assert.AreEqual(1.0, variance, 0.03);
        Assert.AreEqual(0.6827, withinOneSigma, 0.01);
    }

    [TestMethod]
    public void RandPerm_ReturnsPermutationOfZeroToSizeMinusOne()
    {
        int size = 11;
        var perm = RandomSampling.RandPerm(size, new Random(0));
        CollectionAssert.AreEquivalent(Enumerable.Range(0, size).ToArray(), perm);
    }

    [TestMethod]
    public void RandPerm_SameSeed_ReturnsSamePermutation()
    {
        CollectionAssert.AreEqual(RandomSampling.RandPerm(20, new Random(99)), RandomSampling.RandPerm(20, new Random(99)));
    }

    [TestMethod]
    public void RandPerm_AllPermutationsOfThree_AreRoughlyUniform()
    {
        const int trials = 60000;
        var counts = Enumerable.Range(0, trials)
            .GroupBy(_ => string.Join(",", RandomSampling.RandPerm(3)))
            .Select(g => g.Count())
            .ToArray();

        Assert.HasCount(6, counts);
        foreach (var count in counts)
        {
            // expected 10000 each; standard deviation ≈ 91
            Assert.AreEqual(trials / 6.0, count, 500);
        }
    }
}
