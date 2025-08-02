// Copyright (c) 2023-2025 Koji Hasegawa.
// This software is released under the MIT License.

using NUnit.Framework;
using TestHelper.Statistics;
using UnityEngine;

namespace TestHelper.Random
{
    [TestFixture]
    public partial class RandomWrapperTest
    {
        /// <summary>
        /// Tests to use instead of <c>UnityEngine.Random</c>
        /// </summary>
        [TestFixture]
        public class UnityEngineRandomTest
        {
#if UNITY_INCLUDE_TESTS
            internal IRandom Random { private get; set; } = new RandomWrapper();
            // Similar to the example of DI using UnityEngine.Random.
#endif

            [Test]
            public void InitState_RecreateRandomWithSeed()
            {
                const int Seed = 100;
                Random.InitState(Seed);

                Assert.That(((RandomWrapper)Random).Seed, Is.EqualTo(Seed));
            }

            [Test]
            public void FloatRange_GotRandomFloatWithinSpecifiedRange()
            {
                const float MinValue = 2.2f;
                const float MaxValue = 12.3f;

                var actual = Experiment.Run(
                    () => Random.Range(MinValue, MaxValue),
                    1 << 10);

                var statistics = new DescriptiveStatistics<float>();
                statistics.Calculate(actual);
                Debug.Log(statistics.GetSummary());

                Assert.That(actual.Samples, Is.All.InRange(MinValue, MaxValue)); // max includes
            }

            [Test]
            public void IntRange_GotRandomIntegerWithinSpecifiedRange()
            {
                const int MinValue = 2;
                const int MaxValue = 10;

                var actual = Experiment.Run(
                    () => Random.Range(MinValue, MaxValue),
                    1 << 10);

                var statistics = new DescriptiveStatistics<int>();
                statistics.Calculate(actual);
                Debug.Log(statistics.GetSummary());

                Assert.That(actual.Samples, Is.All.InRange(MinValue, MaxValue - 1)); // max exclusive
            }

            [Test]
            public void Value_GotNumberBetween0to1()
            {
                var actual = Experiment.Run(
                    () => Random.value,
                    1 << 10);

                var statistics = new DescriptiveStatistics<float>();
                statistics.Calculate(actual);
                Debug.Log(statistics.GetSummary());

                Assert.That(actual.Samples, Is.All.InRange(0.0f, 1.0f));
            }

            [Test]
            [Repeat(1 << 10)]
            public void InsideUnitSphere_GotRandomVector3InsideUnitSphere()
            {
                var actual = Random.insideUnitSphere;

                var distance = actual.magnitude;
                Assert.That(distance, Is.InRange(0.0f, 1.0f), $"Vector3 {actual} is not inside the unit sphere");
            }

            [Test]
            [Repeat(1 << 10)]
            public void InsideUnitCircle_GotRandomVector2InsideUnitCircle()
            {
                var actual = Random.insideUnitCircle;

                var distance = actual.magnitude;
                Assert.That(distance, Is.InRange(0.0f, 1.0f), $"Vector2 {actual} is not inside the unit circle");
            }

            [Test]
            [Repeat(1 << 10)]
            public void OnUnitSphere_GotRandomVector3OnUnitSphereSurface()
            {
                var actual = Random.onUnitSphere;

                var distance = actual.magnitude;
                Assert.That(distance, Is.EqualTo(1.0f).Within(0.001f),
                    $"Vector3 {actual} is not on the unit sphere surface");
            }

            [Test]
            [Repeat(1 << 10)]
            public void Rotation_GeneratesNormalizedQuaternionWithComponentsInRange()
            {
                var q = Random.rotation;

                Assert.That(q.x, Is.InRange(-1.0f, 1.0f));
                Assert.That(q.y, Is.InRange(-1.0f, 1.0f));
                Assert.That(q.z, Is.InRange(-1.0f, 1.0f));
                Assert.That(q.w, Is.InRange(-1.0f, 1.0f));

                var magnitude = Mathf.Sqrt(q.x * q.x + q.y * q.y + q.z * q.z + q.w * q.w);
                Assert.That(magnitude, Is.EqualTo(1.0f).Within(0.5f), $"Quaternion {q} is not normalized");
            }

            [Test]
            [Repeat(1 << 10)]
            public void RotationUniform_GeneratesNormalizedQuaternionWithComponentsInRange()
            {
                var q = Random.rotationUniform;

                Assert.That(q.x, Is.InRange(-1.0f, 1.0f));
                Assert.That(q.y, Is.InRange(-1.0f, 1.0f));
                Assert.That(q.z, Is.InRange(-1.0f, 1.0f));
                Assert.That(q.w, Is.InRange(-1.0f, 1.0f));

                var magnitude = Mathf.Sqrt(q.x * q.x + q.y * q.y + q.z * q.z + q.w * q.w);
                Assert.That(magnitude, Is.EqualTo(1.0f).Within(0.001f), $"Quaternion {q} is not normalized");
            }

            [Test]
            [Repeat(1 << 10)]
            public void ColorHSV_ReturnsColorWithinSpecifiedRanges()
            {
                float hMin = 0.2f, hMax = 0.8f;
                float sMin = 0.3f, sMax = 0.9f;
                float vMin = 0.1f, vMax = 0.7f;
                float aMin = 0.5f, aMax = 1.0f;

                var color = UnityEngine.Random.ColorHSV(hMin, hMax, sMin, sMax, vMin, vMax, aMin, aMax);

                Color.RGBToHSV(color, out float h, out float s, out float v);

                Assert.That(h, Is.InRange(hMin, hMax));
                Assert.That(s, Is.InRange(sMin, sMax));
                Assert.That(v, Is.InRange(vMin, vMax));
                Assert.That(color.a, Is.InRange(aMin, aMax));
            }
        }
    }
}
