// Copyright (c) 2023-2025 Koji Hasegawa.
// This software is released under the MIT License.

using System;
using NUnit.Framework;

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
            private const int RepeatCount = 10;

            [Test]
            public void Constructor_DefaultConstructor_UsingTickCount()
            {
                var usingTickCount = new RandomWrapper(Environment.TickCount);
                var defaultRandom = new RandomWrapper();

                Assert.That(defaultRandom.Next(), Is.EqualTo(usingTickCount.Next()));
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
            }

            [Test]
            [Repeat(RepeatCount)]
            public void Next_GotNonNegativeRandomInteger()
            {
                IRandom sut = new RandomWrapper();
                var actual = sut.Next();

                Assert.That(actual, Is.InRange(0, int.MaxValue - 1));
            }

            [Test]
            [Repeat(RepeatCount)]
            public void Next_WithMaxValue_GotRandomIntegerLessThanSpecifiedMax()
            {
                const int MaxValue = 10;
                IRandom sut = new RandomWrapper();
                var actual = sut.Next(MaxValue);

                Assert.That(actual, Is.InRange(0, MaxValue - 1));
            }

            [Test]
            [Repeat(RepeatCount)]
            public void Next_WithMinAndMaxValue_GotRandomIntegerWithinSpecifiedRange()
            {
                const int MinValue = 2;
                const int MaxValue = 10;
                IRandom sut = new RandomWrapper();
                var actual = sut.Next(MinValue, MaxValue);

                Assert.That(actual, Is.InRange(MinValue, MaxValue - 1));
            }

            // TODO: NextBytes(byte[])

            // TODO: NextBytes(Span<byte>)

            [Test]
            [Repeat(RepeatCount)]
            public void NextDouble_GotNumberBetween0to1()
            {
                IRandom sut = new RandomWrapper();
                var actual = sut.NextDouble();

                Assert.That(actual, Is.InRange(0.0d, 1.0d));
            }
        }
    }
}
