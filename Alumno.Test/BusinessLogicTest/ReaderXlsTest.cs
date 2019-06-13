using System;
using System.IO;
using Alumno.BusinessLogic.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alumno.Test.BusinessLogicTest
{
    [TestClass]
    public class ReaderXlsTest
    {
        [TestMethod]
        public void ExisteFileCalif()
        {
            Assert.IsTrue(File.Exists(@"Data\Calificaciones.xlsx"));
        }

        [TestMethod]
        public void LoadDataXls() {
            var result = ReaderXls.ReadFile(@"Data\Calificaciones.xlsx", "Sheet1", 1, 6);
            result.Students.ForEach(item => Console.WriteLine(item.ToString()));
            result.Headers.ForEach(item => Console.WriteLine(item));
        }

        [TestMethod]
        public void GetHeadersXls()
        {
            var result = ReaderXls.GetSheetNames(@"Data\Calificaciones.xlsx");
            result.ForEach(item => Console.WriteLine(item));
        }
    }
}
