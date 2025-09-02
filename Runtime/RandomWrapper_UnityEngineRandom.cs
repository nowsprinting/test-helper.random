// Copyright (c) 2023-2025 Koji Hasegawa.
// This software is released under the MIT License.

using System;
using UnityEngine;

namespace TestHelper.Random
{
    /// <inheritdoc />
    public partial class RandomWrapper : IRandom
    {
        /// <inheritdoc />
        public virtual void InitState(int seed)
        {
            _random = new System.Random(seed);
            Seed = seed;
        }

        /// <inheritdoc />
        public virtual UnityEngine.Random.State state
        {
            get
            {
                throw new NotSupportedException();
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        /// <inheritdoc />
        public virtual float Range(float minInclusive, float maxInclusive)
        {
            var d = NextDouble();
            return (float)(minInclusive + (maxInclusive - minInclusive) * d);
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
                var u = this.value;
                var v = this.value;
                var theta = 2 * Mathf.PI * u;
                var phi = Mathf.Acos(2 * v - 1);
                var r = Mathf.Pow(this.value, 1f / 3f);

                var sinPhi = Mathf.Sin(phi);
                var x = r * sinPhi * Mathf.Cos(theta);
                var y = r * sinPhi * Mathf.Sin(theta);
                var z = r * Mathf.Cos(phi);

                return new Vector3(x, y, z);
            }
        }

        /// <inheritdoc />
        public virtual Vector2 insideUnitCircle
        {
            get
            {
                var u = this.value;
                var v = this.value;
                var theta = 2 * Mathf.PI * u;
                var r = Mathf.Sqrt(v);

                var x = r * Mathf.Cos(theta);
                var y = r * Mathf.Sin(theta);

                return new Vector2(x, y);
            }
        }

        /// <inheritdoc />
        public virtual Vector3 onUnitSphere
        {
            get
            {
                var u = this.value;
                var v = this.value;
                var theta = 2 * Mathf.PI * u;
                var phi = Mathf.Acos(2 * v - 1);

                var sinPhi = Mathf.Sin(phi);
                var x = sinPhi * Mathf.Cos(theta);
                var y = sinPhi * Mathf.Sin(theta);
                var z = Mathf.Cos(phi);

                return new Vector3(x, y, z);
            }
        }

        /// <inheritdoc />
        public virtual Quaternion rotation
        {
            get
            {
                // Ken Shoemake's method for uniform random quaternion
                var u1 = this.value;
                var u2 = this.value;
                var u3 = this.value;

                var sqrt1MinusU1 = Mathf.Sqrt(1 - u1);
                var sqrtU1 = Mathf.Sqrt(u1);
                var theta1 = 2 * Mathf.PI * u2;
                var theta2 = 2 * Mathf.PI * u3;

                var x = sqrt1MinusU1 * Mathf.Sin(theta1);
                var y = sqrt1MinusU1 * Mathf.Cos(theta1);
                var z = sqrtU1 * Mathf.Sin(theta2);
                var w = sqrtU1 * Mathf.Cos(theta2);

                return new Quaternion(x, y, z, w);
            }
        }

        /// <inheritdoc />
        public virtual Quaternion rotationUniform
        {
            get
            {
                var u = this.value;
                var v = this.value;
                var w = this.value;

                // Convert to spherical coordinates
                var theta = 2 * Mathf.PI * u;    // azimuthal angle
                var phi = Mathf.Acos(2 * v - 1); // polar angle

                // Convert to Cartesian coordinates
                var sinPhi = Mathf.Sin(phi);
                var x = sinPhi * Mathf.Cos(theta);
                var y = sinPhi * Mathf.Sin(theta);
                var z = Mathf.Cos(phi);

                return new Quaternion(x, y, z, w).normalized;
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
