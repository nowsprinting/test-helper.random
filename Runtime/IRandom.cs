// Copyright (c) 2023 Koji Hasegawa.
// This software is released under the MIT License.

using System;
using UnityEngine;

namespace TestHelper.Random
{
    /// <summary>
    /// Random number generator interface similar to <c>System.Random</c> and <c>UnityEngine.Random</c> class.
    /// </summary>
    public interface IRandom
    {
        /// <summary>
        /// Returns a non-negative random integer.
        /// </summary>
        /// <returns>A 32-bit signed integer greater than or equal to zero and less than <c>int.MaxValue</c>.</returns>
        int Next();

        /// <summary>
        /// Returns a non-negative random integer that is less than the specified maximum.
        /// </summary>
        /// <param name="maxValue">The exclusive upper bound of the random number to be generated. maxValue must be greater than or equal to zero.</param>
        /// <returns>A 32-bit signed integer greater than or equal to zero, and less than maxValue; that is, the range of return values ordinarily includes zero but not maxValue. However, if maxValue equals zero, maxValue is returned.</returns>
        int Next(int maxValue);

        /// <summary>
        /// Returns a random integer that is within a specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        /// <returns>A 32-bit signed integer greater than or equal to minValue and less than maxValue; that is, the range of return values includes minValue but not maxValue. If minValue equals maxValue, minValue is returned.</returns>
        int Next(int minValue, int maxValue);

        /// <summary>
        /// Fills the elements of a specified array of bytes with random numbers.
        /// </summary>
        /// <param name="buffer">An array of bytes to contain random numbers.</param>
        void NextBytes(byte[] buffer);

#if UNITY_2021_2_OR_NEWER
        /// <summary>
        /// Fills the elements of a specified array of bytes with random numbers.
        /// </summary>
        /// <param name="buffer">An array of bytes to contain random numbers.</param>
        void NextBytes(Span<byte> buffer);
#endif

        /// <summary>
        /// Returns a random floating-point number between 0.0 and 1.0.
        /// </summary>
        /// <returns>A double-precision floating point number greater than or equal to 0.0, and less than 1.0.</returns>
        double NextDouble();

        /// <summary>
        /// Returns a random float within [minInclusive..maxInclusive] (range is inclusive).
        /// </summary>
        /// <param name="minInclusive"></param>
        /// <param name="maxInclusive"></param>
        float Range(float minInclusive, float maxInclusive);

        /// <summary>
        /// Return a random int within [minInclusive..maxExclusive) (Read Only).
        /// </summary>
        /// <param name="minInclusive"></param>
        /// <param name="maxExclusive"></param>
        int Range(int minInclusive, int maxExclusive) => Next(minInclusive, maxExclusive);

        /// <summary>
        /// Return a random int within [minInclusive..maxExclusive) (Read Only).
        /// </summary>
        /// <param name="minInclusive"></param>
        /// <param name="maxExclusive"></param>
        int RandomRangeInt(int minInclusive, int maxExclusive) => Next(minInclusive, maxExclusive);

        /// <summary>
        /// Returns a random float within [0.0..1.0] (range is inclusive) (Read Only).
        /// </summary>
        // ReSharper disable once InconsistentNaming
        float value();

        /// <summary>
        /// Returns a random point inside or on a sphere with radius 1.0 (Read Only).
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public Vector3 insideUnitSphere();

        /// <summary>
        /// Returns a random point inside or on a circle with radius 1.0 (Read Only).
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public Vector2 insideUnitCircle();

        /// <summary>
        /// Returns a random point on the surface of a sphere with radius 1.0 (Read Only).
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public Vector3 onUnitSphere();

        /// <summary>
        /// Returns a random rotation (Read Only).
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public Quaternion rotation();

        /// <summary>
        /// Returns a random rotation with uniform distribution (Read Only).
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public Quaternion rotationUniform();

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
        public Color ColorHSV(
            float hueMin = 0.0f,
            float hueMax = 1.0f,
            float saturationMin = 0.0f,
            float saturationMax = 1.0f,
            float valueMin = 0.0f,
            float valueMax = 1.0f,
            float alphaMin = 1.0f,
            float alphaMax = 1.0f);
    }
}
