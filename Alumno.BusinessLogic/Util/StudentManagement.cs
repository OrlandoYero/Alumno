using Alumno.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumno.BusinessLogic.Util
{
    public class StudentManagement
    {
        /// <summary>
        /// Pageable list of student
        /// </summary>
        public List<Student> Students { get; set; }
        /// <summary>
        /// Headers for xls
        /// </summary>
        public List<string> Headers { get; set; }
        /// <summary>
        /// Best student from file
        /// </summary>
        public Student BestStudent
        {
            get { return BestStudent; }
            set
            {
                if (BestStudent.Name == null)
                {
                    BestStudent = value;
                }
                else if (BestStudent.Calification > value.Calification)
                {
                    BestStudent = value;
                }

            }
        }
        /// <summary>
        /// Worst student from file
        /// </summary>
        public Student WorstStudent
        {
            get { return WorstStudent; }
            set
            {
                if (WorstStudent.Name == null)
                {
                    WorstStudent = value;
                }
                else if (WorstStudent.Calification < value.Calification)
                {
                    WorstStudent = value;
                }
            }
        }

        public float StudentAverage { get; set; }
        public StudentManagement()
        {
            Students = new List<Student>();
            Headers = new List<string>();
            BestStudent = new Student();
            WorstStudent = new Student();
        }
        public bool AddStudent(Student student)
        {
            try
            {
                Students.Add(student);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool AddHeaders(params string[] header)
        {
            try
            {
                Headers = header.ToList();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public Student CreateStudent(params object[] st)
        {
            var student = new Student
            {
                Name = (string)st[0],
                MotherLastName = (string)st[1],
                FatherLastName = (string)st[2],
                Birthdate = (DateTime)st[3],
                Grade = (int)st[4],
                Group = (string)st[5],
                Calification = (float)st[6]
            };
            student.Key = GenerateStudentKey(student);
            return student;
        }

        /// <summary>
        /// Generate student key
        /// </summary>
        /// <param name="student">Student obj</param>
        /// <returns>key</returns>
        private string GenerateStudentKey(Student student)
        {
            return GetTwoLetters(student.Name.Trim()) + GetTwoLetters(student.MotherLastName.Trim()) + GetStudentAge(student);
        }

        /// <summary>
        /// Get last two characters
        /// </summary>
        /// <param name="value">string value</param>
        /// <returns>string</returns>
        private string GetTwoLetters(string value)
        {
            var result = "";
            if (value.Length < 2)
            {
                result += "-";
                if (value.Length == 0)
                {
                    result += "-";
                }
                else
                {
                    result += value;
                }
            }
            else {
                result = value.Substring(value.Length - 2);
            }
            return result;
        }

        /// <summary>
        /// Get age
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        private int GetStudentAge(Student student)
        {
            return 12;
        }
    }
}
