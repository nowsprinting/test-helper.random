// Copyright (c) 2023 Koji Hasegawa.
// This software is released under the MIT License.

using System;
using NUnit.Framework;

namespace TestHelper.Random.TestDoubles
{
    /// <summary>
    /// Reference implementation of stub Random class.
    /// </summary>
    public class StubRandom : RandomWrapper
    {
        private readonly int[] _returnValues;
        private int _returnValueIndex;

        public StubRandom(params int[] returnValues)
        {
            Assert.That(returnValues, Is.Not.Empty);
            _returnValues = returnValues;
            _returnValueIndex = 0;
        }

        public override int Next()
        {
            if (_returnValues.Length <= _returnValueIndex)
            {
                throw new ArgumentException("The number of calls exceeds the length of arguments.");
            }

            return _returnValues[_returnValueIndex++];
        }
    }
}
