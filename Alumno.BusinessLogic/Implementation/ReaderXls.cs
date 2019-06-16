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
        public static StudentManagement ReadFile(string fileName, string sheet, int page, int size, bool reload = false)
        {
            StudentManagement management = new StudentManagement();
            if (File.Exists(fileName))
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
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

                                management.Sheet = sheet;

                                int pos = 0;
                                int posInit = (page - 1) * size + 1;
                                int posEnd = page * size;

                                while (reader.Read())
                                {
                                    ++pos;
                                    var student = management.CreateStudent(
                                        reader.GetString(0),
                                        reader.GetString(1),
                                        reader.GetString(2),
                                        Convert.ToDateTime(reader[3].ToString()),
                                        int.Parse(reader[4].ToString()),
                                        reader.GetString(5),
                                        float.Parse(reader[6].ToString())
                                        );
                                    student.Id = pos;
                                    if (pos >= posInit && pos <= posEnd)
                                    {
                                        management.AddStudent(
                                            student
                                        );
                                    }
                                    else if (!reload && pos > posInit)
                                    {
                                        break;
                                    }

                                    if (reload)
                                    {
                                        // statistics
                                        management.BestStudent = student;
                                        management.WorstStudent = student;
                                        management.StudentAverage += student.Calification / (reader.RowCount - 1);
                                        management.StudentCount = reader.RowCount - 1;
                                        management.FileName = fileName;
                                        var floorValue = (int)Math.Floor(student.Calification);
                                        if (student.Calification > 5)
                                        {
                                            if (!management.CounterByNote.ContainsKey(floorValue))
                                                management.CounterByNote[floorValue] = 0;
                                            management.CounterByNote[floorValue]++;
                                        }
                                        else
                                        {
                                            if (!management.CounterByNote.ContainsKey(5))
                                                management.CounterByNote[5] = 0;
                                            management.CounterByNote[5]++;
                                        }
                                    }
                                }
                            }

                        } while (reader.NextResult());
                    }
                }
            }
            else
            {
                return null;
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
            if (File.Exists(fileName))
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
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
            }
            else
            {
                return null;
            }

            return SheetNames;
        }
    }
}
