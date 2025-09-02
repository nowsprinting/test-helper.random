// Copyright (c) 2023-2025 Koji Hasegawa.
// This software is released under the MIT License.

using System;
using NUnit.Framework;
using TestHelper.Statistics;
using UnityEngine;

namespace TestHelper.Random
{
    [TestFixture]
    public partial class RandomWrapperTest
    {
        /// <summary>
        /// Tests to use instead of <c>System.Random</c>
        /// </summary>
        [TestFixture]
        public class SystemRandomTest
        {
            [Test]
            public void Constructor_DefaultConstructor_UsingTickCount()
            {
                var tickCount = Environment.TickCount;
                var sut = new RandomWrapper();

                Assert.That(sut.Seed, Is.EqualTo(tickCount));
            }

            [Test]
            public void Constructor_SameSeedValue_GotSameValue()
            {
                const int Seed = 100;
                var random = new RandomWrapper(Seed);
                var sameSeedRandom = new RandomWrapper(Seed);

                Assert.That(random.Next(), Is.EqualTo(sameSeedRandom.Next()));
            }

            [Test]
            public void Constructor_NegativeSeedValue_GotSameValue()
            {
                const int Seed = 100;
                var random = new RandomWrapper(Seed);
                var negativeSeedRandom = new RandomWrapper(-1 * Seed);

                Assert.That(random.Next(), Is.EqualTo(negativeSeedRandom.Next()));
                // Note: Absolute values are used
            }

            [Test]
            public void Fork_CreatedNewInstance()
            {
                var sut = new RandomWrapper();
                var fork = sut.Fork();

                Assert.That(sut, Is.Not.EqualTo(fork));
            }

            [Test]
            public void Fork_CreatedWithSeedValueBasedOnNext()
            {
                const int Seed = 100;
                var sut = new RandomWrapper(Seed);
                var fork = sut.Fork();
                var sameSeedRandom = new RandomWrapper(Seed);
                var sameSeedFork = sameSeedRandom.Fork();

                Assert.That(fork.Next(), Is.EqualTo(sameSeedFork.Next()));
            }

            [Test]
            public void Next_GotNonNegativeRandomInteger()
            {
                var sut = new RandomWrapper();
                var actual = Experiment.Run(
                    () => sut.Next(),
                    1 << 10);

                var statistics = new DescriptiveStatistics<int>();
                statistics.Calculate(actual);
                Debug.Log(statistics.GetSummary());

                Assert.That(actual.Samples, Is.All.InRange(0, int.MaxValue - 1));
            }

            [Test]
            public void Next_WithMaxValue_GotRandomIntegerLessThanSpecifiedMax()
            {
                const int MaxValue = 10;

                var sut = new RandomWrapper();
                var actual = Experiment.Run(
                    () => sut.Next(MaxValue),
                    1 << 10);

                var statistics = new DescriptiveStatistics<int>();
                statistics.Calculate(actual);
                Debug.Log(statistics.GetSummary());

                Assert.That(actual.Samples, Is.All.InRange(0, MaxValue - 1));
            }

            [Test]
            public void Next_WithMinAndMaxValue_GotRandomIntegerWithinSpecifiedRange()
            {
                const int MinValue = 2;
                const int MaxValue = 10;

                var sut = new RandomWrapper();
                var actual = Experiment.Run(
                    () => sut.Next(MinValue, MaxValue),
                    1 << 10);

                var statistics = new DescriptiveStatistics<int>();
                statistics.Calculate(actual);
                Debug.Log(statistics.GetSummary());

                Assert.That(actual.Samples, Is.All.InRange(MinValue, MaxValue - 1));
            }

            [Test]
            public void NextBytes_GotRandomByteValues()
            {
                var sut = new RandomWrapper();
                var actual = new byte[1 << 10];
                sut.NextBytes(actual);

                var statistics = new DescriptiveStatistics<byte>();
                statistics.Calculate(actual);
                Debug.Log(statistics.GetSummary());
                // Note: Max and min are not calculated

                Assert.That(actual, Is.All.InRange(0, byte.MaxValue));
            }

#if UNITY_2021_2_OR_NEWER
            [Test]
            public void NextBytes_WithSpan_GotRandomByteValues()
            {
                var sut = new RandomWrapper();
                var span = new Span<byte>(new byte[1 << 10]);
                sut.NextBytes(span);

                var statistics = new DescriptiveStatistics<byte>();
                var actual = span.ToArray();
                statistics.Calculate(actual);
                Debug.Log(statistics.GetSummary());
                // Note: Max and min are not calculated

                Assert.That(actual, Is.All.InRange(0, byte.MaxValue));
            }
#endif

            [Test]
            public void NextDouble_GotNumberBetween0to1()
            {
                var sut = new RandomWrapper();
                var actual = Experiment.Run(
                    () => sut.NextDouble(),
                    1 << 10);

                var statistics = new DescriptiveStatistics<double>();
                statistics.Calculate(actual);
                Debug.Log(statistics.GetSummary());

                Assert.That(actual.Samples, Is.All.InRange(0.0d, 1.0d));
            }
        }
    }
}
