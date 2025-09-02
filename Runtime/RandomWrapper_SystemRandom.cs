// Copyright (c) 2023-2025 Koji Hasegawa.
// This software is released under the MIT License.

using System;

namespace TestHelper.Random
{
    /// <inheritdoc />
    public partial class RandomWrapper : IRandom
    {
        private System.Random _random;

        /// <summary>
        /// Seed value.
        /// </summary>
        public int Seed { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <c>RandomWrapper</c> class,
        /// using the specified seed value.
        /// </summary>
        /// <param name="seed">A number used to calculate a starting value for the pseudo-random number sequence. If a negative number is specified, the absolute value of the number is used.</param>
        public RandomWrapper(int seed)
        {
            _random = new System.Random(seed);
            Seed = seed;
        }

        /// <summary>
        /// Initializes a new instance of the <c>RandomWrapper</c> class,
        /// using <c>Environment.TickCount</c> to seed value.
        /// </summary>
        public RandomWrapper() : this(Environment.TickCount) { }

        /// <inheritdoc />
        public IRandom Fork()
        {
            return new RandomWrapper(Next());
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"RandomWrapper includes System.Random, seed={Seed}";
        }

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
    }
}
