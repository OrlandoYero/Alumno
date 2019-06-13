using Alumno.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumno.BusinessLogic.Util
{
    public class KeyGenerate
    {
        public static char[] alphabet = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ".ToCharArray();
        /// <summary>
        /// Generate student key
        /// </summary>
        /// <param name="student">Student obj</param>
        /// <returns>key</returns>
        public static string GenerateStudentKey(Student student)
        {
            return GetTwoLetters(student.Name.Trim()) + GetTwoLetters(student.MotherLastName.Trim()) + GetStudentAge(student);
        }

        /// <summary>
        /// Get last two characters
        /// </summary>
        /// <param name="value">string value</param>
        /// <returns>string</returns>
        public static string GetTwoLetters(string value)
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
            else
            {
                result = value.Substring(value.Length - 2);
            }
            return result;
        }

        /// <summary>
        /// Get age
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public static int GetStudentAge(Student student)
        {
            var span = DateTime.Now - student.Birthdate;
            return (new DateTime(1, 1, 1) + span).Year - 1;
        }

        public static char GetCharacterInAlpha(char c)
        {
            int position = 0;
            if (char.IsLetter(c))
            {
                char character = char.ToUpper(c);
                if (character == 'Ñ')
                {
                    position = 11;
                }
                else if (character > 'N')
                {
                    position = character - 67;
                }
                else
                {
                    position = character - 68;
                }
            }
            else {
                return '-';
            }

            return position < 0 ? alphabet[alphabet.Count() + position] : alphabet[position];
        }
    }
}
