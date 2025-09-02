// Copyright (c) 2023-2025 Koji Hasegawa.
// This software is released under the MIT License.

using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace TestHelper.Random
{
    /// <summary>
    /// Pseudo-random number generator interface similar to <c>System.Random</c> and <c>UnityEngine.Random</c> class.
    /// </summary>
    public partial interface IRandom
    {
        /// <summary>
        ///   <para>Initializes the random number generator state with a seed.</para>
        /// </summary>
        /// <param name="seed">Seed used to initialize the random number generator.</param>
        void InitState(int seed);

        /// <summary>
        ///   <para>Gets or sets the full internal state of the random number generator.</para>
        /// </summary>
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        UnityEngine.Random.State state { get; set; }

        /// <summary>
        ///   <para>Returns a random float within [minInclusive..maxInclusive] (range is inclusive).</para>
        /// </summary>
        /// <param name="minInclusive"></param>
        /// <param name="maxInclusive"></param>
        float Range(float minInclusive, float maxInclusive);

        /// <summary>
        ///   <para>Return a random int within [minInclusive..maxExclusive) (Read Only).</para>
        /// </summary>
        /// <param name="minInclusive"></param>
        /// <param name="maxExclusive"></param>
        int Range(int minInclusive, int maxExclusive);

        /// <summary>
        ///   <para>Returns a random float within [0.0..1.0] (range is inclusive) (Read Only).</para>
        /// </summary>
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        float value { get; }

        /// <summary>
        ///   <para>Returns a random point inside or on a sphere with radius 1.0 (Read Only).</para>
        /// </summary>
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        Vector3 insideUnitSphere { get; }

        /// <summary>
        ///   <para>Returns a random point inside or on a circle with radius 1.0 (Read Only).</para>
        /// </summary>
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        Vector2 insideUnitCircle { get; }

        /// <summary>
        ///   <para>Returns a random point on the surface of a sphere with radius 1.0 (Read Only).</para>
        /// </summary>
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        Vector3 onUnitSphere { get; }

        /// <summary>
        ///   <para>Returns a random rotation (Read Only).</para>
        /// </summary>
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        Quaternion rotation { get; }

        /// <summary>
        ///   <para>Returns a random rotation with uniform distribution (Read Only).</para>
        /// </summary>
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        Quaternion rotationUniform { get; }

        /// <summary>
        ///   <para>Generates a random color from HSV and alpha ranges.</para>
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
        ///   <para>A random color with HSV and alpha values in the (inclusive) input ranges. Values for each component are derived via linear interpolation of value.</para>
        /// </returns>
        Color ColorHSV(
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
