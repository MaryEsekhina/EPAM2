using NUnit.Framework;

namespace DZ6_Test
{
    public class Tests
    {

        [Test, TestCaseSource("CalcPlusCases")]
        public void TestPlus(int a, int b, int res)
        {
            Assert.AreEqual(Calc.Plus(a,b), res);
        }


        [Test, TestCaseSource("CalcMinusCases")]
        public void TestMinus(int a, int b, int res)
        {
            Assert.AreEqual(Calc.Minus(a, b), res);
        }


        [Test, TestCaseSource("CalcMultiplCases")]
        public void TestMultipl1(int a, int b, int res)
        {
            Assert.AreEqual(Calc.Multipl(a, b), res);
        }

        [Test, TestCaseSource("CalcDivCases")]
        public void TestDiv(int a, int b, int res)
        {
            Assert.AreEqual(Calc.Div(a, b), res);
        }

        static object[] CalcPlusCases =
        {
            new object[] { 1, 2, 3 },
            new object[] { -1073741824, -1073741824, -2147483648 },
            new object[] { 1073741824, 1073741823, 2147483647 },
            new object[] { 1073741824, -1073741824, 0 }
        };

        static object[] CalcMinusCases =
        {
            new object[] { 3, 2, 1 },
            new object[] { -1073741824, -1073741824, 0 },
            new object[] { 1073741824, 1073741824, 0 },
            new object[] { 1073741824, -1073741823, 2147483647 }
        };

        static object[] CalcMultiplCases =
        {
            new object[] { 3, 2, 6 },
            new object[] { -1073741823, 2, -2147483646 },
            new object[] { 1073741823, 2, 2147483646 },
            new object[] { 2147483647, -1, -2147483647 }
        };

        static object[] CalcDivCases =
        {
            new object[] { 6, 2, 3 },
            new object[] { -2147483646, -2, 1073741823 },
            new object[] { -2147483646, 2, -1073741823 },
            new object[] { 2147483646, 2, 1073741823 }
        };
    }
}