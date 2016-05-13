using System;
using NUnit.Framework;
using Val;

namespace UnitTestProject1
{
    [TestFixture]
    public class ParameterTests
    {
        [Test]
        [TestCase(0.0, 15.0, 10.0, TestName = "Вводимое значение параметра равно 15")]
        [TestCase(0.0, double.MaxValue, 10.0, TestName = "Максимальное значение параметра")]
        [TestCase(0.0, double.MinValue, 10.0, TestName = "Минимальное значение параметра")]
        [TestCase(double.MaxValue, 15.0, double.MaxValue, TestName = "Максимальные значения пределов параметра")]
        [TestCase(15, double.MinValue, double.MinValue, TestName = "Минимальные значения пределов параметра")]
        public void NotPositiveValueTest(double testValue1, double testValue2, double testValue3)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Parameter(testValue1, testValue2, testValue3));
        }

        [TestCase(5, TestName = "Вводимое значение параметра равно 5")]
        public void PositiveValueTest(double testValue)
        {
            Assert.DoesNotThrow(() => new Parameter(0.0, testValue, 10.0));
           
        }

        [TestCase(5, TestName = "Тест того, что невалидное значение не сохраняется")]
        public void ValueIsNotSaved(double testValue)
        {
            Parameter parameter = new Parameter(0.0, testValue, 10.0);
            try
            {
                parameter.Value = testValue;
            }
            catch (Exception)
            {
                Assert.AreNotEqual(parameter.Value, testValue);
            }
        }
    }
}
