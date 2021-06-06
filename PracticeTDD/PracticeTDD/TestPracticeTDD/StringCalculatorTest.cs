using NUnit.Framework;
using PracticeTDD;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestPracticeTDD
{
    class StringCalculatorTest
    {
        private StringCalculator calculator = new StringCalculator();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void StringCalculator_Add_EmptyStringInput()
        {
            string input = "";

            var result = this.calculator.Add(input);

            Assert.AreEqual(0, result, "Wrong result - not 0");
        }

        [Test]
        public void StringCalculator_Add_OneOrMoreElements()
        {
            string input1 = "5";
            string input2 = "7,4,7";

            var result1 = this.calculator.Add(input1);
            var result2 = this.calculator.Add(input2);

            Assert.AreEqual(5, result1, "Wrong logic");
            Assert.AreEqual(18, result2, "Wrong logic");
        }

        [Test]
        public void StringCalculator_Add_InputSeparatedByNewLineSymbol()
        {
            string input = "7\n4,7";

            var result = this.calculator.Add(input);

            Assert.AreEqual(18, result, "Wrong separation operation");
        }

        [Test]
        public void StringCalculator_Add_SetCustomDelimiter()
        {
            string input = "//;\n3;3;3";

            var result = this.calculator.Add(input);

            Assert.AreEqual(9, result, "Delimiter doesnt work");
        }

        [Test]
        public void StringCalculator_Add_ThrowExceptionNegativeDigit()
        {
            string input = "//;\n3;-33;3";

            var ex = Assert.Throws<ArgumentException>( () => this.calculator.Add(input));

            Assert.That(ex.Message, Is.EqualTo("negatives not allowed - -33 "), "No Exception");
        }

        [Test]
        public void StringCalculator_Add_ThrowExceptionNegativeDigitPrintAll()
        {
            string input = "//;\n3;-33;-3";

            var ex = Assert.Throws<ArgumentException>(() => this.calculator.Add(input));

            Assert.That(ex.Message, Is.EqualTo("negatives not allowed - -33 -3 "), "No Exception");
        }

        [Test]
        public void StringCalculator_GetCalledCount_GetMethodAddCalledCount()
        {
            var result = this.calculator.GetCalledCount();

            Assert.AreEqual(10, result, $"Wrong count {result}");  
        }

        [Test]
        public void StringCalculator_Action_AddOccured_InvokingAction()
        {
            StringCalculator calc = new StringCalculator();

            calc.SetAction((x, y) => throw new Exception(x));

            var ex = Assert.Throws<Exception>(() => calc.Add("3"));

            Assert.That(ex.Message, Is.EqualTo("Is working"), "No Exception in action");
        }

        [Test]
        public void StringCalculator_Add_IgnoringNumbersBeggerThan1000()
        {
            var result = this.calculator.Add("2,1001");

            Assert.AreEqual(2, result, $"Wrong sum");
        }

        [Test]
        public void StringCalculator_Add_CustomDelimiterLength()
        {
            var result = this.calculator.Add("//[***]\n2***5***3");

            Assert.AreEqual(10, result, $"Wrong sum");
        }

        [Test]
        public void StringCalculator_Add_CustomDelimiterLengthAndDilimiters()
        {
            var result = this.calculator.Add("//[***][%]\n2***5***3%5");

            Assert.AreEqual(15, result, $"Wrong sum");
        }
    }
}
