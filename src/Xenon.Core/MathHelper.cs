/*
* Copyright (c) 2007-2010 SlimDX Group
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in
* all copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
* THE SOFTWARE.
*/

namespace Xenon.Core
{
    /// <summary>
    /// Contains mathmeatical methods and constants that extend the System.Math class.
    /// </summary>
    public static class MathHelper
    {
        /// <summary>
        /// A value specifying the approximation of π which is 180 degrees.
        /// </summary>
        public const float Pi = 3.141592653589793239f;

        /// <summary>
        /// A value specifying the approximation of 2π which is 360 degrees.
        /// </summary>
        public const float TwoPi = 6.283185307179586477f;

        /// <summary>
        /// A value specifying the approximation of π/2 which is 90 degrees.
        /// </summary>
        public const float PiOverTwo = 1.570796326794896619f;

        /// <summary>
        /// A value specifying the approximation of π/4 which is 45 degrees.
        /// </summary>
        public const float PiOverFour = 0.785398163397448310f;

        /// <summary>
        /// Represents the math constant e.
        /// </summary>
        public const float E = 2.718282f;

        /// <summary>
        /// Represents the math constant log base ten of e.
        /// </summary>
        public const float Log10E = 0.4342945f;

        /// <summary>
        /// Represents the log base two of e.
        /// </summary>
        public const float Log2E = 1.442695f;

        /// <summary>
        /// Represents 3Pi/4 (135 degrees).
        /// </summary>
        public const float ThreePiOver4 = TwoPi - PiOverTwo;

        /// <summary>
        /// Value to multiply degrees by to obtain radians.
        /// </summary>
        public const float DegreesToRadians = Pi / 180.0f;

        /// <summary>
        /// Value to multiply radians by to obtain degrees.
        /// </summary>
        public const float RadiansToDegrees = 180.0f / Pi;

        /// <summary>
        /// Represents Pi^2
        /// </summary>
        public const float PiSquared = Pi * Pi;

        /// <summary>
        /// One third constant.
        /// </summary>
        public const float OneThird = 1.0f / 3.0f;

        /// <summary>
        /// Two third constant.
        /// </summary>
        public const float TwoThird = 2.0f / 3.0f;

        /// <summary>
        /// Represents a "close to zero" value.
        /// </summary>
        public const float ZeroTolerance = 0.00000001f;

        /// <summary>
        /// Represents a "close to zero" value, the smallest float value possible.
        /// </summary>
        public const float Epsilon = float.Epsilon;

        /// <summary>
        /// Converts an angle in radians to the corresponding angle in degrees.
        /// </summary>
        /// <param name="radians">Angle in radians</param>
        /// <returns>Angle in degrees</returns>
        public static float ToDegrees(float radians)
        {
            return radians * RadiansToDegrees;
        }

        /// <summary>
        /// Converts an angle in degrees to the corresponding angle in radians.
        /// </summary>
        /// <param name="degrees">Angle in degrees</param>
        /// <returns>Angle in radians</returns>
        public static float ToRadians(float degrees)
        {
            return degrees * DegreesToRadians;
        }

        /// <summary>
        /// Finds the maximum value of two supplied values.
        /// </summary>
        /// <param name="a">First value</param>
        /// <param name="b">Second value</param>
        /// <returns>Maximum of the two</returns>
        public static float Max(float a, float b)
        {
            return System.Math.Max(a, b);
        }

        /// <summary>
        /// Finds the minimum value of two supplied values.
        /// </summary>
        /// <param name="a">First value</param>
        /// <param name="b">Second value</param>
        /// <returns>Minimum of the two</returns>
        public static float Min(float a, float b)
        {
            return System.Math.Min(a, b);
        }

        /// <summary>
        /// Reduces an angle in radians to the range of pi to -pi.
        /// </summary>
        /// <param name="angle">Angle in radians</param>
        /// <returns>Reduced angle</returns>
        public static float WrapAngle(float angle)
        {
            angle = (float)System.Math.IEEERemainder(angle, 6.2831854820251465d);
            if (angle <= -Pi)
            {
                angle += TwoPi;
                return angle;
            }
            if (angle > Pi)
                angle -= TwoPi;
            return angle;
        }

        /// <summary>
        /// Clamps a value within the specified range.
        /// </summary>
        /// <param name="value">Source value</param>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <returns>Clamped value</returns>
        public static float Clamp(float value, float min, float max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }

        /// <summary>
        /// Clamps a value within the specified range.
        /// </summary>
        /// <param name="value">Source value</param>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <returns>Clamped value</returns>
        public static int Clamp(int value, int min, int max)
        {
            value = (value > max) ? max : value;
            value = (value < min) ? min : value;
            return value;
        }

        /// <summary>
        /// Clamps an integer to the byte range 0-255.
        /// </summary>
        /// <param name="value">Integer to be clamped</param>
        /// <returns>Clamped value</returns>
        public static int ClampToByte(int value)
        {
            if (value < 0)
                return 0;
            else if (value > 255)
                return 255;
            return value;
        }

        /// <summary>
        /// Clamps and rounds a value within the specified range.
        /// </summary>
        /// <param name="value">Source value</param>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <returns>Clamped and rounded value in double precision</returns>
        public static double ClampAndRound(float value, float min, float max)
        {
            if (float.IsNaN(value))
                return 0.0;
            if (float.IsInfinity(value))
                return (float.IsNegativeInfinity(value) ? ((double)min) : ((double)max));
            if (value < min)
                return (double)min;
            if (value > max)
                return (double)max;
            return System.Math.Round((double)value);
        }

        /// <summary>
        /// Computes the absolute value between a and b.
        /// </summary>
        /// <param name="a">First value</param>
        /// <param name="b">Second value</param>
        /// <returns>Distance between the two</returns>
        public static float Distance(float a, float b)
        {
            return System.Math.Abs(a - b);
        }

        /// <summary>
        /// Linearly interpolates between two values.
        /// </summary>
        /// <param name="a">Starting value</param>
        /// <param name="b">Ending value</param>
        /// <param name="percent">Amount to interpolate</param>
        /// <returns>Interpolated value</returns>
        public static float Lerp(float a, float b, float percent)
        {
            return a + ((b - a) * percent);
        }

        /// <summary>
        /// Interpolates between two values using a cubic equation.
        /// </summary>
        /// <param name="a">Starting value</param>
        /// <param name="b">Ending value</param>
        /// <param name="percent">Amount to interpolate</param>
        /// <returns>Interpolated value</returns>
        public static float SmoothStep(float a, float b, float percent)
        {
            float clamped = Clamp(percent, 0.0f, 1.0f);
            return Lerp(a, b, (clamped * clamped) * (3.0f - (2.0f * clamped)));
        }

        /// <summary>
        /// Returns the floor, the largest integer less than or equal to the source value.
        /// </summary>
        /// <param name="value">Source value</param>
        /// <returns>Floored value</returns>
        public static float Floor(float value)
        {
            return (float)System.Math.Floor(value);
        }

        /// <summary>
        /// Returns the ceiling, the smallest integer greater than or equal to the source value.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Ceiling value</returns>
        public static float Ceil(float value)
        {
            return (float)System.Math.Ceiling(value);
        }

        /// <summary>
        /// Returns the Square root of the value.
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>Square root of the value</returns>
        public static float Sqrt(float value)
        {
            return (float)System.Math.Sqrt(value);
        }

        /// <summary>
        /// Checks if the values a and b are within float.Epsilon
        /// </summary>
        /// <param name="a">First value</param>
        /// <param name="b">Second value</param>
        /// <returns>True if within range</returns>
        public static bool NearEpsilon(float a, float b)
        {
            float diff = a - b;
            return (float.Epsilon <= diff) && (diff <= float.Epsilon);
        }

        /// <summary>
        /// Checks if the values a and b are just "nearly" equal,
        /// to account for floating-point error. This is abs(a - b)
        /// is less than float.Epsilon.
        /// </summary>
        /// <param name="a">First value</param>
        /// <param name="b">Second value</param>
        /// <returns>True if "nearly" equal</returns>
        public static bool FuzzyEquals(float a, float b)
        {
            float absDiff = System.Math.Abs(a - b);
            return absDiff < float.Epsilon;
        }
    }
}
