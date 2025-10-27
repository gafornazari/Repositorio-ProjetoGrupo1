using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGrupo1
{
    public static class Arquivo
    {
        public static string CarregarArquivo(string directoryPath, string filePath)
        {
            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
            }

            try
            {
                if (!File.Exists(Path.Combine(directoryPath, filePath)))
                {
                    File.Create(Path.Combine(directoryPath, filePath));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
            }

            return Path.Combine(directoryPath, filePath);
        }

    }
}
