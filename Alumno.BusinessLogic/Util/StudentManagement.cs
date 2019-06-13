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
        public List<Student> Students { get; set; }
        public List<string> Headers { get; set; }
        public StudentManagement()
        {
            Students = new List<Student>();
            Headers = new List<string>();
        }
        public bool AddStudent(params object[] st)
        {
            try
            {
                Students.Add(new Student
                {
                    Name = (string)st[0],
                    MotherLastName = (string) st[1],
                    FatherLastName = (string) st[2],
                    Birthdate = (DateTime) st[3],
                    Grade = (int)st[4],
                    Group = (string)st[5],
                    Calification = (float)st[6]
                });
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool AddHeaders(params string[] header) {
            try
            {
                Headers = header.ToList();
            }
            catch {
                return false;
            }
            return true;
        }
    }
}
