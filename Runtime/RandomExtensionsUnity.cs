// Copyright (c) 2023 Koji Hasegawa.
// This software is released under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace TestHelper.Random
{
    /// <summary>
    /// Random number generator extensions similar to <c>UnityEngine.Random</c> class.
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    public static class RandomExtensionsUnity
    {
        /// <summary>
        /// Returns a random float within [minInclusive..maxInclusive] (range is inclusive).
        /// </summary>
        /// <param name="minInclusive"></param>
        /// <param name="maxInclusive"></param>
        public static float Range(this IRandom random, float minInclusive, float maxInclusive)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return a random int within [minInclusive..maxExclusive) (Read Only).
        /// </summary>
        /// <param name="minInclusive"></param>
        /// <param name="maxExclusive"></param>
        public static int Range(this IRandom random, int minInclusive, int maxExclusive)
        {
            return random.Next(minInclusive, maxExclusive);
        }

        /// <summary>
        /// Return a random int within [minInclusive..maxExclusive) (Read Only).
        /// </summary>
        /// <param name="minInclusive"></param>
        /// <param name="maxExclusive"></param>
        public static int RandomRangeInt(this IRandom random, int minInclusive, int maxExclusive)
        {
            return random.Next(minInclusive, maxExclusive);
        }

        /// <summary>
        /// Returns a random float within [0.0..1.0] (range is inclusive) (Read Only).
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static float value(this IRandom random)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a random point inside or on a sphere with radius 1.0 (Read Only).
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static Vector3 insideUnitSphere(this IRandom random)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a random point inside or on a circle with radius 1.0 (Read Only).
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static Vector2 insideUnitCircle(this IRandom random)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a random point on the surface of a sphere with radius 1.0 (Read Only).
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static Vector3 onUnitSphere(this IRandom random)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a random rotation (Read Only).
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static Quaternion rotation(this IRandom random)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a random rotation with uniform distribution (Read Only).
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static Quaternion rotationUniform(this IRandom random)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Generates a random color from HSV and alpha ranges.
        /// </summary>
        /// <param name="hueMin">Minimum hue [0..1].</param>
        /// <param name="hueMax">Maximum hue [0..1].</param>
        /// <param name="saturationMin">Minimum saturation [0..1].</param>
        /// <param name="saturationMax">Maximum saturation [0..1].</param>
        /// <param name="valueMin">Minimum value [0..1].</param>
        /// <param name="valueMax">Maximum value [0..1].</param>
        /// <param name="alphaMin">Minimum alpha [0..1].</param>
        /// <param name="alphaMax">Maximum alpha [0..1].</param>
        /// <returns>
        /// A random color with HSV and alpha values in the (inclusive) input ranges. Values for each component are derived via linear interpolation of value.
        /// </returns>
        public static Color ColorHSV(
            this IRandom random,
            float hueMin = 0.0f,
            float hueMax = 1.0f,
            float saturationMin = 0.0f,
            float saturationMax = 1.0f,
            float valueMin = 0.0f,
            float valueMax = 1.0f,
            float alphaMin = 1.0f,
            float alphaMax = 1.0f)
        {
            throw new NotImplementedException();
        }
    }
}
