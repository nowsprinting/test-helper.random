// Copyright (c) 2023 Koji Hasegawa.
// This software is released under the MIT License.

using System;
using UnityEngine;

namespace TestHelper.Random
{
    /// <summary>
    /// Wrapper implementation for <c>IRandom</c> Using <c>System.Random</c> instance.
    /// </summary>
    public class RandomWrapper : IRandom
    {
        private System.Random _random;
        private int _seed;

        /// <summary>
        /// Initializes a new instance of the <c>RandomWrapper</c> class,
        /// using the specified seed value.
        /// </summary>
        /// <param name="seed">A number used to calculate a starting value for the pseudo-random number sequence. If a negative number is specified, the absolute value of the number is used.</param>
        public RandomWrapper(int seed)
        {
            _random = new System.Random(seed);
            _seed = seed;
        }

        /// <summary>
        /// Initializes a new instance of the <c>RandomWrapper</c> class,
        /// using <c>Environment.TickCount</c> to seed value.
        /// </summary>
        public RandomWrapper() : this(Environment.TickCount) { }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"RandomWrapper using System.Random, seed={_seed}";
        }


        #region System.Random

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

        #endregion


        #region UnityEngine.Random

        /// <inheritdoc />
        public virtual void InitState(int seed)
        {
            _random = new System.Random(seed);
            _seed = seed;
        }

        /// <inheritdoc />
        public virtual UnityEngine.Random.State state { get; set; }

        /// <inheritdoc />
        public virtual float Range(float minInclusive, float maxInclusive)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public virtual int Range(int minInclusive, int maxExclusive)
        {
            return Next(minInclusive, maxExclusive);
        }

        /// <inheritdoc />
        public virtual float value
        {
            get
            {
                return (float)NextDouble();
            }
        }

        /// <inheritdoc />
        public virtual Vector3 insideUnitSphere
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <inheritdoc />
        public virtual Vector2 insideUnitCircle
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <inheritdoc />
        public virtual Vector3 onUnitSphere
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <inheritdoc />
        public virtual Quaternion rotation
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <inheritdoc />
        public virtual Quaternion rotationUniform
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <inheritdoc />
        public virtual Color ColorHSV(float hueMin, float hueMax, float saturationMin, float saturationMax,
            float valueMin, float valueMax, float alphaMin, float alphaMax)
        {
            var color = Color.HSVToRGB(
                Mathf.Lerp(hueMin, hueMax, this.value),
                Mathf.Lerp(saturationMin, saturationMax, this.value),
                Mathf.Lerp(valueMin, valueMax, this.value),
                true);
            color.a = Mathf.Lerp(alphaMin, alphaMax, this.value);
            return color;
        }

        #endregion
    }
}
