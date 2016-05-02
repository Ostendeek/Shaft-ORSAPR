using System;
using NUnit.Framework;
using Val;

namespace UnitTestProject1
{
    [TestFixture]
    public class ValPropertiesTests
    {
        [Test]
        [TestCase("hello", TestName = "Вводимое значение параметра ")]
        public void PositiveTest(string testValue)
        {
            Assert.DoesNotThrow(() => new ValProperties().SetCaption(ParameterType.ShaftDiameter5Stage,
                NumberOfStage.Stage5, OrientationParameterType.Horizontal, testValue));
        }

        [Test]
        [TestCase(NumberOfStage.Stage5, ParameterType.ShaftLength5Stage, 0.0, TestName = "Проверка корректности при построении пятой ступени")]
        [TestCase(NumberOfStage.Stage4, ParameterType.ShaftLength4Stage, -4.25, TestName = "Проверка корректности при построении четвертой ступени")]
        [TestCase(NumberOfStage.Stage3, ParameterType.ShaftLength3Stage, -8.5, TestName = "Проверка корректности при построении третьей ступени")]
        [TestCase(NumberOfStage.Stage2, ParameterType.ShaftLength2Stage, -18.5, TestName = "Проверка корректности при построении второй ступени")]
        [TestCase(NumberOfStage.Stage1, ParameterType.ShaftLength1Stage, -31.5, TestName = "Проверка корректности при построении первой ступени")]
        public void StageXTest(NumberOfStage numberOfStage, ParameterType parameterType, double idealValue)
        {
            var tmp = new ValProperties();
            tmp.SetCaption(parameterType, numberOfStage, OrientationParameterType.Horizontal, "hell");
            var result = tmp.GetPointX();
            Assert.AreEqual(idealValue, result);
        }

        [Test]
        [TestCase(NumberOfStage.Stage5, ParameterType.ShaftDiameter5Stage, 36, TestName = "Проверка корректности при построении пятой ступени")]
        [TestCase(NumberOfStage.Stage4, ParameterType.ShaftDiameter4Stage, 42.5, TestName = "Проверка корректности при построении четвертой ступени")]
        [TestCase(NumberOfStage.Stage3, ParameterType.ShaftDiameter3Stage, 40.0, TestName = "Проверка корректности при построении третьей ступени")]
        [TestCase(NumberOfStage.Stage2, ParameterType.ShaftDiameter2Stage, 36.0, TestName = "Проверка корректности при построении второй ступени")]
        [TestCase(NumberOfStage.Stage1, ParameterType.ShaftDiameter1Stage, 33.5, TestName = "Проверка корректности при построении первой ступени")]
        public void StageZTest(NumberOfStage numberOfStage, ParameterType parameterType, double idealValue)
        {
            var tmp = new ValProperties();
            tmp.SetCaption(parameterType, numberOfStage, OrientationParameterType.Horizontal, "hell");
            var result = tmp.GetPointZ();
            Assert.AreEqual(idealValue, result);
        }
    }
}
