using Alumno.BusinessLogic.Util;
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
        /// <summary>
        /// Read xls file
        /// </summary>
        /// <param name="fileName">Name of file</param>
        /// <param name="sheet">Name of sheet</param>
        /// <param name="page">Page to show</param>
        /// <param name="size">Page size</param>
        /// <returns></returns>
        public static StudentManagement ReadFile(string fileName, string sheet, int page, int size)
        {
            StudentManagement management = new StudentManagement();
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    do
                    {
                        if (reader.Name == sheet && reader.Read())
                        {
                            // get header
                            management.AddHeaders(
                                reader.GetString(0), 
                                reader.GetString(1), 
                                reader.GetString(2), 
                                reader.GetString(3), 
                                reader.GetString(4), 
                                reader.GetString(5), 
                                reader.GetString(6)
                                );

                            int pos = 1;
                            int posInit = (page - 1) * size + 1;
                            int posEnd = page * size;
                            
                            while (reader.Read())
                            {
                                if (pos >= posInit && pos <= posEnd)
                                {
                                    management.AddStudent(
                                    reader.GetString(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    Convert.ToDateTime(reader[3].ToString()),
                                    int.Parse(reader[4].ToString()),
                                    reader.GetString(5),
                                    float.Parse(reader[6].ToString())
                                    );
                                }
                                else if (pos>= posInit){
                                    break;
                                }
                                pos++;                                
                            }
                        }

                    } while (reader.NextResult());
                }
            }
            return management;
        }

        /// <summary>
        /// Get all sheet from file 
        /// </summary>
        /// <param name="fileName">Name of file</param>
        /// <returns>List<string></returns>
        public static List<string> GetSheetNames(string fileName)
        {
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
