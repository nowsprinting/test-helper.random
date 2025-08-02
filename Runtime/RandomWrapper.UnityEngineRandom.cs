// Copyright (c) 2023-2025 Koji Hasegawa.
// This software is released under the MIT License.

using System;
using UnityEngine;

namespace TestHelper.Random
{
    /// <summary>
    /// Wrapper implementation for <c>IRandom</c> using <c>System.Random</c> instance.
    /// </summary>
    public partial class RandomWrapper : IRandom
    {
        /// <inheritdoc />
        public virtual void InitState(int seed)
        {
            _random = new System.Random(seed);
            Seed = seed;
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
    }
}
