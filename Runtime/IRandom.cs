// Copyright (c) 2023-2025 Koji Hasegawa.
// This software is released under the MIT License.

namespace TestHelper.Random
{
    /// <summary>
    /// Pseudo-random number generator interface similar to <c>System.Random</c> and <c>UnityEngine.Random</c> class.
    /// </summary>
    public partial interface IRandom
    {
        /// <summary>
        /// Create a new instance using the value emitted by <see cref="Next()"/> method as a seed value.
        /// </summary>
        /// <returns>New instance</returns>
        IRandom Fork();
    }
}
