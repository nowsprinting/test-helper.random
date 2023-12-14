// Copyright (c) 2023 Koji Hasegawa.
// This software is released under the MIT License.

namespace TestHelper.Random.TestDoubles
{
    /// <summary>
    /// Reference implementation of spy Random class.
    /// </summary>
    public class SpyRandom : RandomWrapper
    {
        public int CapturedMaxValue { get; private set; }

        public override int Next(int maxValue)
        {
            CapturedMaxValue = maxValue;
            return base.Next(maxValue);
        }
    }
}
