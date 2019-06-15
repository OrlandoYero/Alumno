using Alumno.BusinessLogic.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Alumno.BusinessLogic.Implementation
{
    public class Manager
    {
        public static Dictionary<string, List<StudentManagement>> SourceDataXls = new Dictionary<string, List<StudentManagement>>();

        /// <summary>
        /// Adicionando hoja para el procesamiento
        /// </summary>
        /// <param name="source">fichero origen</param>
        /// <param name="sheet">hoja xls</param>
        /// <param name="page">posicion de la pagina</param>
        /// <param name="size">tamaño de pagina</param>
        /// <param name="replace">se recargara la informacion</param>
        /// <returns>StudentManagement</returns>
        public static StudentManagement AddSourceData(string source, string sheet, int page = 1, int size = 10, bool replace = false)
        {
            string md5 = CalculateMD5Hash(source);
            SourceDataXls.TryGetValue(md5, out List<StudentManagement> managementList);
            if (managementList == null)
            {
                managementList = new List<StudentManagement>();
                SourceDataXls.Add(md5, managementList);
            }

            StudentManagement management = null;
            managementList?.ForEach(item =>
            {
                if (item.Sheet == sheet)
                {
                    management = item;
                }
            });
            if (replace || management == null)
            {
                if (management != null) managementList.Remove(management);
                management = ReaderXls.ReadFile(source, sheet, page, size, true);
                managementList.Add(management);
            }
            else
            {
                management = ReaderXls.ReadFile(source, sheet, page, size);
            }
            return management;
        }

        /// <summary>
        /// Obtener información a partir del md5
        /// </summary>
        /// <param name="md5Path">md5 de la dirección del fichero</param>
        /// <param name="sheet">hoja</param>
        /// <param name="page">página</param>
        /// <param name="size">tamaño de página</param>
        /// <returns>StudentManagement</returns>
        public static StudentManagement GetPageData(string md5Path, string sheet, int page = 1, int size = 10)
        {
            SourceDataXls.TryGetValue(md5Path, out List<StudentManagement> managementList);
            StudentManagement management = null;
            if (managementList != null)
            {
                managementList?.ForEach(item =>
                {
                    if (item.Sheet == sheet)
                    {
                        management = item;
                        // actualizar pagina activa de estudiantes 
                        var newList = ReaderXls.ReadFile(management.FileName, sheet, page, size);
                        management.Students = newList.Students; 
                    }
                });
            }
            return management;
        }

        /// <summary>
        /// Obtener manager para source y la hoja especificada
        /// </summary>
        /// <param name="source">origen del fichero</param>
        /// <param name="sheet">nombre hoja xls</param>
        /// <param name="page">posicion de la pagina</param>
        /// <param name="size">tamaño de la pagina</param>
        /// <returns>StudentManagement</returns>
        public static StudentManagement GetSourceData(string md5Path, string sheet)
        {
            SourceDataXls.TryGetValue(md5Path, out List<StudentManagement> value);
            StudentManagement management = null;
            if (value != null)
            {
                value.ForEach(item =>
                {
                    if (item.Sheet == sheet)
                    {
                        management = item;
                    }
                });
            }
            return management;
        }

        /// <summary>
        /// Calcular hash string from https://devblogs.microsoft.com/csharpfaq/how-do-i-calculate-a-md5-hash-from-a-string/
        /// </summary>
        /// <param name="input">string</param>
        /// <returns>text md5</returns>
        public static string CalculateMD5Hash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public static List<string> GetSheetList(string path)
        {
            return ReaderXls.GetSheetNames(path);
        }
    }
}
