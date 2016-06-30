using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiffresRomains
{
    using NUnit.Framework;

    [TestFixture]
    public class RomanumChiffrumTesti
    {
        [TestCase(1, "I")]
        [TestCase(5, "V")]
        [TestCase(10, "X")]
        [TestCase(50, "L")]
        [TestCase(100, "C")]
        [TestCase(500, "D")]
        [TestCase(1000, "M")]
        public void UnaDigita(int nombre, string romain)
        {
            var converter = new ChiffresRomains();
            string result = converter.ConvertToRoman(nombre);
            Assert.AreEqual(romain, result);
        }

        [TestCase(6, "VI")]
        [TestCase(11, "XI")]
        [TestCase(16, "XVI")]
        [TestCase(1561, "MDLXI")]
        [TestCase(1666, "MDCLXVI")]
        public void OneForEachLetter(int nombre, string romain)
        {
            var converter = new ChiffresRomains();
            string result = converter.ConvertToRoman(nombre);
            Assert.AreEqual(romain, result);
        }

        [TestCase(2, "II")]
        [TestCase(7, "VII")]
        [TestCase(12, "XII")]
        [TestCase(26, "XXVI")]
        [TestCase(2000, "MM")]
        [TestCase(2666, "MMDCLXVI")]
        public void TwoOrThreeConsecutiveLetters(int nombre, string romain)
        {
            var converter = new ChiffresRomains();
            string result = converter.ConvertToRoman(nombre);
            Assert.AreEqual(romain, result);
        }

        [TestCase(4, "IV")]
        [TestCase(42, "XLII")]
        [TestCase(400, "CD")]
        public void FourConsecutiveLetters(int nombre, string romain)
        {
            var converter = new ChiffresRomains();
            string result = converter.ConvertToRoman(nombre);
            Assert.AreEqual(romain, result);
        }

        [TestCase(900, "CM")]
        [TestCase(1999, "MCMXCIX")]
        public void FourConsecutiveLettersWithJump(int nombre, string romain)
        {
            var converter = new ChiffresRomains();
            string result = converter.ConvertToRoman(nombre);
            Assert.AreEqual(romain, result);
        }

        [TestCase(2888 ,"MMDCCCLXXXVIII")]
        [TestCase(2444, "MMCDXLIV")]
        [TestCase(1977, "MCMLXXVII")]
        [TestCase(496, "CDXCVI")]
        public void Complex(int number, string romanNumber)
        {
            var converter = new ChiffresRomains();
            string result = converter.ConvertToRoman(number);
            Assert.AreEqual(romanNumber, result);
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(3001)]
        public void WrongNumber(int nombre)
        {
            var converter = new ChiffresRomains();
            Assert.Throws<InvalidOperationException>(() => converter.ConvertToRoman(nombre));
        }

        [Test]
        public void CovertToDigits()
        {
            var converter = new ChiffresRomains();
            for (var i = 1; i < 3000; i++)
            {
                Assert.AreEqual(i, converter.ConvertToDigits(converter.ConvertToRoman(i)));
            }
        }
    }
}
