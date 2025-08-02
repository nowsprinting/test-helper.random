// Copyright (c) 2023-2025 Koji Hasegawa.
// This software is released under the MIT License.

using NUnit.Framework;
using TestHelper.Statistics;
using UnityEngine;

namespace TestHelper.Random
{
    [TestFixture]
    public partial class RandomWrapperTest
    {
        /// <summary>
        /// Tests to use instead of <c>UnityEngine.Random</c>
        /// </summary>
        [TestFixture]
        public class UnityEngineRandomTest
        {
#if UNITY_INCLUDE_TESTS
            internal IRandom Random { private get; set; } = new RandomWrapper();
            // Similar to the example of DI using UnityEngine.Random.
#endif

            [Test]
            public void InitState_RecreateRandomWithSeed()
            {
                const int Seed = 100;
                Random.InitState(Seed);

                Assert.That(((RandomWrapper)Random).Seed, Is.EqualTo(Seed));
            }

            // TODO: FloatRange

            [Test]
            public void IntRange_GotRandomIntegerWithinSpecifiedRange()
            {
                const int MinValue = 2;
                const int MaxValue = 10;

                var actual = Experiment.Run(
                    () => Random.Range(MinValue, MaxValue),
                    1 << 10);

                var statistics = new DescriptiveStatistics<int>();
                statistics.Calculate(actual);
                Debug.Log(statistics.GetSummary());

                Assert.That(actual.Samples, Is.All.InRange(MinValue, MaxValue - 1)); // max exclusive
            }

            [Test]
            public void Value_GotNumberBetween0to1()
            {
                var actual = Experiment.Run(
                    () => Random.value,
                    1 << 10);

                var statistics = new DescriptiveStatistics<float>();
                statistics.Calculate(actual);
                Debug.Log(statistics.GetSummary());

                Assert.That(actual.Samples, Is.All.InRange(0.0f, 1.0f));
            }

            // TODO: insideUnitSphere
            // TODO: insideUnitCircle
            // TODO: onUnitSphere
            // TODO: rotation
            // TODO: rotationUniform
            // TODO: ColorHSV
        }
    }
}
