// Copyright (c) $CURRENT_YEAR$ Koji Hasegawa.
// This software is released under the MIT License.

using NUnit.Framework;

namespace TestHelper.Random
{
    /// <summary>
    /// Test to use instead of <c>UnityEngine.Random</c>
    /// </summary>
    [TestFixture]
    public class RandomWrapperTestToUseInsteadOfUnityEngineRandom
    {
        // ReSharper disable once MemberCanBePrivate.Global
        internal IRandom Random { private get; set; } = new RandomWrapper(); // SUT

        private const int RepeatCount = 10;

        [Test]
        public void InitState_RecreateRandomWithSeed()
        {
            const int Seed = 100;
            Random.InitState(Seed);

            Assert.That(Random.ToString(), Is.EqualTo($"RandomWrapper using System.Random, seed={Seed}"));
        }

        // TODO: FloatRange

        [Test]
        [Repeat(RepeatCount)]
        public void IntRange_GotRandomIntegerWithinSpecifiedRange()
        {
            const int MinValue = 2;
            const int MaxValue = 10;
            var actual = Random.Range(MinValue, MaxValue);

            Assert.That(actual, Is.InRange(MinValue, MaxValue - 1));
        }

        [Test]
        [Repeat(RepeatCount)]
        public void Value_GotNumberBetween0to1()
        {
            var actual = Random.value;

            Assert.That(actual, Is.InRange(0.0d, 1.0d));
        }

        // TODO: insideUnitSphere
        // TODO: insideUnitCircle
        // TODO: onUnitSphere
        // TODO: rotation
        // TODO: rotationUniform
        // TODO: ColorHSV
    }
}
