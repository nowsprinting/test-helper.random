// Copyright (c) 2023 Koji Hasegawa.
// This software is released under the MIT License.

using System;
using NUnit.Framework;

namespace TestHelper.Random
{
    /// <summary>
    /// Reference implementation of stub Random class,
    /// Only override methods that return <c>int</c> values.
    /// </summary>
    public class StubRandom : IRandom
    {
        private readonly int[] _returnValues;
        private int _returnValueIndex;

        public StubRandom(params int[] returnValues)
        {
            Assert.That(returnValues, Is.Not.Empty);
            _returnValues = returnValues;
            _returnValueIndex = 0;
        }

        public int Next()
        {
            if (_returnValues.Length <= _returnValueIndex)
            {
                throw new ArgumentException("The number of calls exceeds the length of arguments.");
            }

            return _returnValues[_returnValueIndex++];
        }

        public int Next(int maxValue)
        {
            if (_returnValues.Length <= _returnValueIndex)
            {
                throw new ArgumentException("The number of calls exceeds the length of arguments.");
            }

            return _returnValues[_returnValueIndex++];
        }

        public int Next(int minValue, int maxValue)
        {
            if (_returnValues.Length <= _returnValueIndex)
            {
                throw new ArgumentException("The number of calls exceeds the length of arguments.");
            }

            return _returnValues[_returnValueIndex++];
        }

        public void NextBytes(byte[] buffer)
        {
            throw new NotImplementedException();
        }

#if UNITY_2021_2_OR_NEWER
        public void NextBytes(Span<byte> buffer)
        {
            throw new NotImplementedException();
        }
#endif

        public double NextDouble()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return GetType().FullName;
        }
    }
}
