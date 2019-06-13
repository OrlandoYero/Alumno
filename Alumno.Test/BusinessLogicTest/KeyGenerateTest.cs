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
    }
}
