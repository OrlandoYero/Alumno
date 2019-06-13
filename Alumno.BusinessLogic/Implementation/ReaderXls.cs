using Alumno.Domain;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumno.BusinessLogic.Implementation
{
    public class ReaderXls
    {
        public static List<Estudent> ReadFile(string fileName, string page, string size)
        {
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream)) {
                    do
                    {
                        // get header
                        var header = reader.Read();
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetString(0) + " " + reader.GetString(1) + " " + reader.GetString(2) + " " + Convert.ToDateTime(reader[3].ToString()));
                        }
                    } while (reader.NextResult());
                }
            }
            return null;
        }

        public static List<string> GetSheetNames(string fileName) {
            List<string> SheetNames = new List<string>();
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    do
                    {
                        SheetNames.Add(reader.Name);
                        
                    } while (reader.NextResult());
                }
            }
            return SheetNames;
        }
    }
}
