// Copyright (c) 2023 Koji Hasegawa.
// This software is released under the MIT License.

using NUnit.Framework;
using TestHelper.Random.TestDoubles;

namespace TestHelper.Random
{
    [TestFixture]
    public class StubRandomTest
    {
        [Test]
        public void Next_ReturnSpecifiedValues()
        {
            IRandom sut = new StubRandom(2, 3, 5);

            Assert.That(sut.Next(), Is.EqualTo(2), "1st value");
            Assert.That(sut.Next(), Is.EqualTo(3), "2nd value");
            Assert.That(sut.Next(), Is.EqualTo(5), "3rd value");
        }
    }
}
