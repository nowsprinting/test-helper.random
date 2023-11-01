// Copyright (c) 2023 Koji Hasegawa.
// This software is released under the MIT License.

using System;
using NUnit.Framework;

namespace TestHelper.Random
{
    [TestFixture]
    public class RandomImplTest
    {
        [Test]
        public void Constructor()
        {
            var sut = new RandomImpl(1);
            var actual = sut.Next();

            Assert.That(actual, Is.EqualTo(534011718));
        }

        [Test]
        public void Constructor_NegativeSeedValue_UsingAbsoluteValue()
        {
            var sut = new RandomImpl(-1);
            var actual = sut.Next();

            Assert.That(actual, Is.EqualTo(534011718)); // Same as seed=1
        }

        [Test]
        public void DefaultConstructor_UsingTickCount()
        {
            var usingTickCount = new RandomImpl(Environment.TickCount);
            var expected = usingTickCount.Next();

            var sut = new RandomImpl();
            var actual = sut.Next();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
