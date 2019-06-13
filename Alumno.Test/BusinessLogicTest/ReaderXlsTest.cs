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
            ReaderXls.ReadFile(@"Data\Calificaciones.xlsx", null, null);
        }

        [TestMethod]
        public void GetHeadersXls()
        {
            ReaderXls.GetHeaders(@"Data\Calificaciones.xlsx");
        }
    }
}
