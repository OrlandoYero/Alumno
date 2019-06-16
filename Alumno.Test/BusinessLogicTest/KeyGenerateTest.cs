using System;
using Alumno.BusinessLogic.Util;
using Alumno.Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alumno.Test.BusinessLogicTest
{
    [TestClass]
    public class KeyGenerateTest
    {
        [TestMethod]
        public void GetPositionInAlphabetTest()
        {
            Assert.AreEqual("X",KeyGenerate.GetCharacterInAlpha('a'));
            Assert.AreEqual("K",KeyGenerate.GetCharacterInAlpha('n'));
            Assert.AreEqual("B",KeyGenerate.GetCharacterInAlpha('e'));
            Assert.AreEqual("P", KeyGenerate.GetCharacterInAlpha('s'));
        }

        [TestMethod]
        public void GetStudentAgeTest() {
           var age = KeyGenerate.GetStudentAge(new StudentData
            {
                Birthdate = DateTime.Parse("30/04/1991")
            });
            var testCreatedDelay = (new DateTime(1, 1, 1) + (DateTime.Now - Convert.ToDateTime("30/04/2019"))).Year - 1;
            Assert.AreEqual(28 + testCreatedDelay, age);
        }

        [TestMethod]
        public void GetTwoLettersTest() {
            Assert.AreEqual("--", KeyGenerate.GetTwoLetters(""));
            Assert.AreEqual("a-", KeyGenerate.GetTwoLetters("a"));
            Assert.AreEqual("bc", KeyGenerate.GetTwoLetters("abc"));
            Assert.AreEqual("An", KeyGenerate.GetTwoLetters("Angel", true));
            Assert.AreEqual("es", KeyGenerate.GetTwoLetters("Robles"));
        }

        [TestMethod]
        public void GenerateStudentKeyTest() {
            var student = new StudentData()
            {
                Name = "Angel",
                FatherLastName = "Moreno",
                MotherLastName = "Robles",
                Birthdate = DateTime.Parse("20/05/1997")
            };
            Assert.AreEqual("XKBP22", KeyGenerate.GenerateStudentKey(student));
        }
    }
}
