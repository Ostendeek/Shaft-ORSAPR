using System;
using NUnit.Framework;
using Val;

namespace UnitTestProject1
{
    [TestFixture]
    public class ParameterTests
    {
        [Test]
        [TestCase(15.0, TestName = "Вводимое значение параметра равно 15")]
        [TestCase(double.MaxValue, TestName = "Максимальное значение параметра")]
        [TestCase(double.MinValue, TestName = "Минимальное значение параметра")]
        public void NotPositiveValueTest(double testValue)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Parameter(0.0, testValue, 10.0));
        }

        [TestCase(5, TestName = "Вводимое значение параметра равно 5")]
        public void PositiveValueTest(double testValue)
        {
            Assert.DoesNotThrow(() => new Parameter(0.0, testValue, 10.0));
           
        }
        
        [TestCase(double.MaxValue, double.MaxValue, TestName = "Максимальные значения пределов параметра")]
        public void MaxLimitTest(double testLimit1, double testLimit2)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Parameter(testLimit1, 15, testLimit2));
        }

        [TestCase(double.MinValue, double.MinValue, TestName = "Минимальные значения пределов параметра")]
        public void MinLimitTest(double testLimit1, double testLimit2)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Parameter(15, testLimit1, testLimit2));
        }

        [TestCase(5, TestName = "Тест того, что невалидное значение не сохраняется")]
        public void ValueIsNotSaved(double testValue)
        {
            Parameter _parameter = new Parameter(0.0, testValue, 10.0);
            try
            {
                _parameter.Value = testValue;
            }
            catch (Exception)
            {
                Assert.AreNotEqual(_parameter.Value, testValue);
            }
        }
    }
}
