using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumno.Domain
{
    public class Estudent
    {
        public string Name { get; set; }
        public string MotherLastName { get; set; }
        public string FatherLastName { get; set; }
        public DateTime Birthdate { get; set; }
        public int Grade { get; set; }
        public string Group { get; set; }
        public float Calification { get; set; }
    }
}
