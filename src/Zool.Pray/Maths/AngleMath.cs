using System;


namespace Zool.Pray.Maths
{
    /// <summary>
    ///     Provides methods for angle related computations.
    /// </summary>
    internal static class AngleMath
    {
        #region Static Methods

        /// <summary>
        ///     Fix given angle in degree to a value between 0 to 360 only.
        /// </summary>
        /// <param name="angle">
        ///     Angle in degree to be fixed.
        /// </param>
        /// <returns>
        ///     Angle in degree fixed between 0 to 360.
        /// </returns>
        internal static double FixDegreesAngle(double angle)
        {
            var newAngle = angle - (360.0 * Math.Floor(angle / 360.0));
            if (newAngle >= 0.0)
            {
                return newAngle;
            }

            return newAngle + 360.0;
        }

        /// <summary>
        ///     Convert given angle value in degree to radian.
        /// </summary>
        /// <param name="degree">
        ///     Angle in degree to be converted to radian.
        /// </param>
        /// <returns>
        ///     Angle in radian converted from given angle in degree.
        /// </returns>
        internal static double DegreeToRadian(double degree)
        {
            return 0.017453292519943295 * degree;
        }

        /// <summary>
        ///     Convert given angle value in radian to degree.
        /// </summary>
        /// <param name="radian">
        ///     Angle in radian to be converted to degree.
        /// </param>
        /// <returns>
        ///     Angle in degree converted from given angle in radian.
        /// </returns>
        internal static double RadianToDegree(double radian)
        {
            return 57.29577951308232 * radian;
        }

        /// <summary>
        ///     Compute the cosine value of given angle in degree.
        /// </summary>
        /// <param name="angle">
        ///     Angle in degree.
        /// </param>
        /// <returns>
        ///     Cosine value of given angle.
        /// </returns>
        internal static double CosineOfDegree(double angle)
        {
            return Math.Cos(DegreeToRadian(angle));
        }

        /// <summary>
        ///     Compute the angle in degree from given cosine value.
        /// </summary>
        /// <param name="cosineValue">
        ///     Cosine value.
        /// </param>
        /// <returns>
        ///     Angle in degree computed from given cosine value.
        /// </returns>
        internal static double InverseCosineInDegree(double cosineValue)
        {
            return RadianToDegree(Math.Acos(cosineValue));
        }

        /// <summary>
        ///     Compute the sine value of given angle in degree.
        /// </summary>
        /// <param name="angle">
        ///     Angle in degree.
        /// </param>
        /// <returns>
        ///     Sine value of given angle.
        /// </returns>
        internal static double SineOfDegree(double angle)
        {
            return Math.Sin(DegreeToRadian(angle));
        }

        /// <summary>
        ///     Compute the angle in degree from given sine value.
        /// </summary>
        /// <param name="sineValue">
        ///     Sine value.
        /// </param>
        /// <returns>
        ///     Angle in degree computed from given sine value.
        /// </returns>
        internal static double InverseSineInDegree(double sineValue)
        {
            return RadianToDegree(Math.Asin(sineValue));
        }

        /// <summary>
        ///     Compute the tangent value of given angle in degree.
        /// </summary>
        /// <param name="angle">
        ///     Angle in degree.
        /// </param>
        /// <returns>
        ///     Tangent value of given angle.
        /// </returns>
        internal static double TangentOfDegree(double angle)
        {
            return Math.Tan(DegreeToRadian(angle));
        }

        /// <summary>
        ///     Compute the angle in degree from given tangent value (ratio of y over x).
        /// </summary>
        /// <param name="y">
        ///     Numberator of the ratio.
        /// </param>
        /// <param name="x">
        ///     Denominator of the ratio.
        /// </param>
        /// <returns>
        ///     Angle in degree computed from given tangent value (ratio of y over x).
        /// </returns>
        internal static double InverseTangent2InDegree(double y, double x)
        {
            return RadianToDegree(Math.Atan2(y, x));
        }

        /// <summary>
        ///     Compute the angle in degree from given cotangent value.
        /// </summary>
        /// <param name="cotangentValue">
        ///     Cotangent value.
        /// </param>
        /// <returns>
        ///     Angle in degree computed from given cotangent value.
        /// </returns>
        internal static double InverseCotangentInDegree(double cotangentValue)
        {
            return RadianToDegree(Math.Atan(1 / cotangentValue));
        }

        #endregion
    }
}
