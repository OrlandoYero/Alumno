using System;
using Alumno.BusinessLogic.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alumno.Test.BusinessLogicTest
{
    [TestClass]
    public class KeyGenerateTest
    {
        [TestMethod]
        public void GetPositionInAlphabetTest()
        {
            Console.WriteLine(KeyGenerate.GetCharacterInAlpha('a')); //X
            Console.WriteLine(KeyGenerate.GetCharacterInAlpha('n')); // K
            Console.WriteLine(KeyGenerate.GetCharacterInAlpha('e')); // B
            Console.WriteLine(KeyGenerate.GetCharacterInAlpha('s')); // P
        }

        [TestMethod]
        public void GetStudentAgeTest() {
           var age = KeyGenerate.GetStudentAge(new Domain.Student
            {
                Birthdate = DateTime.Parse("30/04/1991")
            });
            Console.WriteLine(age);
        }

        [TestMethod]
        public void GetTwoLettersTest() {
            Console.WriteLine(KeyGenerate.GetTwoLetters(""));
            Console.WriteLine(KeyGenerate.GetTwoLetters("a"));
            Console.WriteLine(KeyGenerate.GetTwoLetters("abc"));
            Console.WriteLine(KeyGenerate.GetTwoLetters("Angel", true));
            Console.WriteLine(KeyGenerate.GetTwoLetters("Robles"));
        }

        [TestMethod]
        public void GenerateStudentKeyTest() {
            var student = new Domain.Student()
            {
                Name = "Angel",
                MotherLastName = "Robles",
                Birthdate = DateTime.Parse("20/05/1997")
            };
            Console.WriteLine(KeyGenerate.GenerateStudentKey(student));
        }
    }
}
