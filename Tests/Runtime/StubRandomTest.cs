// Copyright (c) 2023-2025 Koji Hasegawa.
// This software is released under the MIT License.

using NUnit.Framework;
using TestHelper.Random.TestDoubles;
using TestHelper.Statistics;

namespace TestHelper.Random
{
    [TestFixture]
    public class StubRandomTest
    {
        [Test]
        public void Next_ReturnSpecifiedValues()
        {
            IRandom sut = new StubRandom(2, 3, 5);

            var actual = Experiment.Run(
                () => sut.Next(),
                3);

            Assert.That(actual.Samples, Is.EqualTo(new[] { 2, 3, 5 }));
        }
    }
}
