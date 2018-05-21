using System;

using Xunit;

using Zool.Pray.Maths;


namespace Zool.Pray.Tests
{
    public class AngleMathTests
    {
        [Fact(DisplayName = "Test fix angle -420 to +300.")]
        public void TestFixNegative420DegreesAngle()
        {
            Assert.Equal(300.0, AngleMath.FixDegreesAngle(-420.0), 5);
        }

        [Fact(DisplayName = "Test fix angle -150 to +210.")]
        public void TestFixNegative150DegreesAngle()
        {
            Assert.Equal(210.0, AngleMath.FixDegreesAngle(-150.0), 5);
        }

        [Fact(DisplayName = "Test fix angle +150 should return same value.")]
        public void TestFixPositive150DegreesAngle()
        {
            Assert.Equal(150.0, AngleMath.FixDegreesAngle(150.0), 5);
        }

        [Fact(DisplayName = "Test fix angle +450 to +90.")]
        public void TestFixPositive450DegreesAngle()
        {
            Assert.Equal(90.0, AngleMath.FixDegreesAngle(450.0), 5);
        }

        [Fact(DisplayName = "Test convert 90 degrees angle to pi/2 radian.")]
        public void TestConvert90DegreesAngleToRadian()
        {
            Assert.Equal(Math.PI / 2.0, AngleMath.DegreeToRadian(90.0), 5);
        }

        [Fact(DisplayName = "Test convert 180 degrees angle to pi radian.")]
        public void TestConvert180DegreesAngleToRadian()
        {
            Assert.Equal(Math.PI, AngleMath.DegreeToRadian(180.0), 5);
        }

        [Fact(DisplayName = "Test convert 270 degrees angle to 3pi/2 radian.")]
        public void TestConvert270DegreesAngleToRadian()
        {
            Assert.Equal((3.0 * Math.PI) / 2.0, AngleMath.DegreeToRadian(270.0), 5);
        }

        [Fact(DisplayName = "Test convert 360 degrees angle to 2pi radian.")]
        public void TestConvert360DegreesAngleToRadian()
        {
            Assert.Equal(2.0 * Math.PI, AngleMath.DegreeToRadian(360.0), 5);
        }

        [Fact(DisplayName = "Test convert pi/2 radian angle to 90 degrees.")]
        public void TestConvertPiOver2RadianAngleToDegree()
        {
            Assert.Equal(90.0, AngleMath.RadianToDegree(Math.PI / 2.0), 5);
        }

        [Fact(DisplayName = "Test convert pi radian angle to 180 degrees.")]
        public void TestConvertPiRadianAngleToDegree()
        {
            Assert.Equal(180.0, AngleMath.RadianToDegree(Math.PI), 5);
        }

        [Fact(DisplayName = "Test convert 3pi/2 radian angle to 270 degrees.")]
        public void TestConvert3PiOver2RadianAngleToDegree()
        {
            Assert.Equal(270.0, AngleMath.RadianToDegree((3.0 * Math.PI) / 2.0), 5);
        }

        [Fact(DisplayName = "Test convert 2pi radian angle to 360 degrees.")]
        public void TestConvert2PiRadianAngleToDegree()
        {
            Assert.Equal(360.0, AngleMath.RadianToDegree(2.0 * Math.PI), 5);
        }

        [Fact(DisplayName = "Test compute cos(0 degree) should equals 1.")]
        public void TestComputeCosineOf0Degree()
        {
            Assert.Equal(1.0, AngleMath.CosineOfDegree(0.0), 5);
        }

        [Fact(DisplayName = "Test compute cos(90 degree) should equals 0.")]
        public void TestComputeCosineOf90Degree()
        {
            Assert.Equal(0.0, AngleMath.CosineOfDegree(90.0), 5);
        }

        [Fact(DisplayName = "Test compute cos(180 degree) should equals -1.")]
        public void TestComputeCosineOf180Degree()
        {
            Assert.Equal(-1.0, AngleMath.CosineOfDegree(180.0), 5);
        }

        [Fact(DisplayName = "Test compute cos(270 degree) should equals 0.")]
        public void TestComputeCosineOf270Degree()
        {
            Assert.Equal(0.0, AngleMath.CosineOfDegree(270.0), 5);
        }

        [Fact(DisplayName = "Test compute acos(0) should equals 90 degree.")]
        public void TestComputeInverseOfCosineOf0()
        {
            Assert.Equal(90.0, AngleMath.InverseCosineInDegree(0.0), 5);
        }

        [Fact(DisplayName = "Test compute acos(1) should equals 0 degree.")]
        public void TestComputeInverseOfCosineOf1()
        {
            Assert.Equal(0.0, AngleMath.InverseCosineInDegree(1.0), 5);
        }

        [Fact(DisplayName = "Test compute acos(-1) should equals 180 degree.")]
        public void TestComputeInverseOfCosineOfNegative1()
        {
            Assert.Equal(180.0, AngleMath.InverseCosineInDegree(-1.0), 5);
        }

        [Fact(DisplayName = "Test compute sin(0 degree) should equals 0.")]
        public void TestComputeSineOf0Degree()
        {
            Assert.Equal(0.0, AngleMath.SineOfDegree(0.0), 5);
        }

        [Fact(DisplayName = "Test compute sin(90 degree) should equals 1.")]
        public void TestComputeSineOf90Degree()
        {
            Assert.Equal(1.0, AngleMath.SineOfDegree(90.0), 5);
        }

        [Fact(DisplayName = "Test compute sin(180 degree) should equals 0.")]
        public void TestComputeSineOf180Degree()
        {
            Assert.Equal(0.0, AngleMath.SineOfDegree(180.0), 5);
        }

        [Fact(DisplayName = "Test compute sin(270 degree) should equals -1.")]
        public void TestComputeSineOf270Degree()
        {
            Assert.Equal(-1.0, AngleMath.SineOfDegree(270.0), 5);
        }

        [Fact(DisplayName = "Test compute asin(0) should equals 0 degree.")]
        public void TestComputeInverseOfSineOf0()
        {
            Assert.Equal(0.0, AngleMath.InverseSineInDegree(0.0), 5);
        }

        [Fact(DisplayName = "Test compute asin(1) should equals 90 degree.")]
        public void TestComputeInverseOfSineOf1()
        {
            Assert.Equal(90.0, AngleMath.InverseSineInDegree(1.0), 5);
        }

        [Fact(DisplayName = "Test compute asin(-1) should equals -90 degree.")]
        public void TestComputeInverseOfSineOfNegative1()
        {
            Assert.Equal(-90.0, AngleMath.InverseSineInDegree(-1.0), 5);
        }

        [Fact(DisplayName = "Test compute tan(0 degree) should equals 0.")]
        public void TestComputeTangentOf0Degree()
        {
            Assert.Equal(0.0, AngleMath.TangentOfDegree(0.0), 5);
        }

        [Fact(DisplayName = "Test compute tan(45 degree) should equals 1.")]
        public void TestComputeTangentOf45Degree()
        {
            Assert.Equal(1.0, AngleMath.TangentOfDegree(45.0), 5);
        }

        [Fact(DisplayName = "Test compute tan(90 degree) should equals infinity.")]
        public void TestComputeTangentOf90Degree()
        {
            Assert.Equal(16331239353195370, AngleMath.TangentOfDegree(90.0), 5);
        }

        [Fact(DisplayName = "Test compute atan2(1,1) should equals 45 degree.")]
        public void TestComputeInverseTangent2InDegreeOfY1AndX1()
        {
            Assert.Equal(45.0, AngleMath.InverseTangent2InDegree(1.0, 1.0), 5);
        }

        [Fact(DisplayName = "Test compute atan2(1,sqrt(3)) should equals 30 degree.")]
        public void TestComputeInverseTangent2InDegreeOfY1AndXSqrt3()
        {
            Assert.Equal(30.0, AngleMath.InverseTangent2InDegree(1.0, Math.Sqrt(3.0)), 5);
        }

        [Fact(DisplayName = "Test compute atan2(sqrt(3),1) should equals 60 degree.")]
        public void TestComputeInverseTangent2InDegreeOfYSqrt3AndX1()
        {
            Assert.Equal(60.0, AngleMath.InverseTangent2InDegree(Math.Sqrt(3.0), 1.0), 5);
        }

        [Fact(DisplayName = "Test compute acot(1/1) should equals 45 degree.")]
        public void TestComputeInverseCotangent2InDegreeOfY1AndX1()
        {
            Assert.Equal(45.0, AngleMath.InverseCotangentInDegree(1.0 / 1.0), 5);
        }

        [Fact(DisplayName = "Test compute acot(1/sqrt(3)) should equals 60 degree.")]
        public void TestComputeInverseCotangent2InDegreeOfY1AndXSqrt3()
        {
            Assert.Equal(60.0, AngleMath.InverseCotangentInDegree(1.0 / Math.Sqrt(3.0)), 5);
        }

        [Fact(DisplayName = "Test compute acot(sqrt(3)/1) should equals 30 degree.")]
        public void TestComputeInverseCotangent2InDegreeOfYSqrt3AndX1()
        {
            Assert.Equal(30.0, AngleMath.InverseCotangentInDegree(Math.Sqrt(3.0) / 1.0), 5);
        }
    }
}
