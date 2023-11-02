﻿// Copyright (c) 2023 Koji Hasegawa.
// This software is released under the MIT License.

using System;
using UnityEngine;

namespace TestHelper.Random
{
    /// <summary>
    /// Reference implementation of <c>IRandom</c>. Using <c>System.Random</c> instance.
    /// </summary>
    /// <seealso cref="System.Random"/>
    public class RandomImpl : IRandom
    {
        private readonly System.Random _random;
        private readonly int _seed;

        /// <summary>
        /// Initializes a new instance of the <c>Random</c> class,
        /// using the specified seed value.
        /// </summary>
        /// <param name="seed">A number used to calculate a starting value for the pseudo-random number sequence. If a negative number is specified, the absolute value of the number is used.</param>
        public RandomImpl(int seed)
        {
            _random = new System.Random(seed);
            _seed = seed;
        }

        /// <summary>
        /// Initializes a new instance of the <c>RandomWrapper</c> class,
        /// using <c>Environment.TickCount</c> to seed value.
        /// </summary>
        public RandomImpl() : this(Environment.TickCount) { }

        /// <inheritdoc />
        public virtual int Next()
        {
            return _random.Next();
        }

        /// <inheritdoc />
        public virtual int Next(int maxValue)
        {
            return _random.Next(maxValue);
        }

        /// <inheritdoc />
        public virtual int Next(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }

        /// <inheritdoc />
        public virtual void NextBytes(byte[] buffer)
        {
            _random.NextBytes(buffer);
        }

#if UNITY_2021_2_OR_NEWER
        /// <inheritdoc />
        public virtual void NextBytes(Span<byte> buffer)
        {
            _random.NextBytes(buffer);
        }
#endif

        /// <inheritdoc />
        public virtual double NextDouble()
        {
            return _random.NextDouble();
        }

        /// <inheritdoc />
        public float Range(float minInclusive, float maxInclusive)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public int Range(int minInclusive, int maxExclusive) => Next(minInclusive, maxExclusive);

        /// <inheritdoc />
        public int RandomRangeInt(int minInclusive, int maxExclusive) => Next(minInclusive, maxExclusive);

        /// <inheritdoc />
        public float value()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Vector3 insideUnitSphere()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Vector2 insideUnitCircle()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Vector3 onUnitSphere()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Quaternion rotation()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Quaternion rotationUniform()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Color ColorHSV(float hueMin = 0, float hueMax = 1, float saturationMin = 0, float saturationMax = 1,
            float valueMin = 0,
            float valueMax = 1, float alphaMin = 1, float alphaMax = 1)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"Random using System.Random, seed={_seed}";
        }
    }
}