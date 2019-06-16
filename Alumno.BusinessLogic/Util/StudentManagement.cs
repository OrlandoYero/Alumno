using Alumno.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumno.BusinessLogic.Util
{
    public class StudentManagement
    {
        public string FileName { get; set; }
        public int StudentCount { get; set; }
        public string Sheet { get; set; }
        public Dictionary<int, int> CounterByNote { get; set; }
        /// <summary>
        /// Pageable list of student
        /// </summary>
        public List<StudentData> Students { get; set; }
        /// <summary>
        /// Headers for xls
        /// </summary>
        public List<string> Headers { get; set; }
        private StudentData _bestStudent;
        /// <summary>
        /// Best student from file
        /// </summary>
        public StudentData BestStudent
        {
            get { return _bestStudent; }
            set
            {
                if (_bestStudent.Name == null)
                {
                    _bestStudent = value;
                }
                else if (_bestStudent.Calification < value.Calification)
                {
                    _bestStudent = value;
                }
            }
        }
        private StudentData _worstStudent;
        /// <summary>
        /// Worst student from file
        /// </summary>
        public StudentData WorstStudent
        {
            get { return _worstStudent; }
            set
            {
                if (_worstStudent.Name == null)
                {
                    _worstStudent = value;
                }
                else if (_worstStudent.Calification > value.Calification)
                {
                    _worstStudent = value;
                }
            }
        }

        public float StudentAverage { get; set; }
        public StudentManagement()
        {
            Students = new List<StudentData>();
            Headers = new List<string>();
            _bestStudent = new StudentData();
            _worstStudent = new StudentData();
            CounterByNote = new Dictionary<int, int>
            {
                { 10, 0 },{ 9, 0 },{ 8, 0 },{ 7, 0 },{ 6, 0 },{ 5, 0 }
            };
        }
        public bool AddStudent(StudentData student)
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

        public StudentData CreateStudent(params object[] st)
        {
            var student = new StudentData
            {
                Name = (string)st[0],
                MotherLastName = (string)st[1],
                FatherLastName = (string)st[2],
                Birthdate = (DateTime)st[3],
                Grade = (int)st[4],
                Group = (string)st[5],
                Calification = (float)st[6]
            };
            student.Key = KeyGenerate.GenerateStudentKey(student);
            return student;
        }
    }
}
