// Copyright (c) 2023-2025 Koji Hasegawa.
// This software is released under the MIT License.

using NUnit.Framework;
using TestHelper.Random.TestDoubles;

namespace TestHelper.Random
{
    [TestFixture]
    public class SpyRandomTest
    {
        [Test]
        public void Next_CaptureMaxValue([Values(2, 3, 5)] int expected)
        {
            var sut = new SpyRandom();
            sut.Next(expected);

            Assert.That(sut.CapturedMaxValue, Is.EqualTo(expected));
        }
    }
}
