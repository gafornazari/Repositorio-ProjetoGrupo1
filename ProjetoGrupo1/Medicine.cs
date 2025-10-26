using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGrupo1
{
    public class Medicine
    {
        public string CDB { get; private set; }
        public string Nome { get; private set; }
        public char Categoria { get; private set; }
        public decimal ValorVenda { get; private set; }
        public DateOnly UltimaVenda { get; private set; }
        public DateOnly DataCadastro { get; private set; }
        public char Situacao { get; private set; }

        public Medicine()
        {
        }
        public Medicine(string cdb, string nome, char categoria, decimal valorVenda)
        {
            CDB = cdb;
            Nome = nome;
            Categoria = categoria;
            ValorVenda = valorVenda;
            DataCadastro = DateOnly.FromDateTime(DateTime.Now);
            string DataFormatada = DataCadastro.ToString("ddMMyyyy");
            Situacao = 'A';
        }

        public Medicine(string cdb, string nome,
            char categoria, decimal valorVenda,
            DateOnly ultimaVenda, DateOnly dataCadastro,
            char situacao)
        {
            CDB = cdb;
            Nome = nome;
            Categoria = categoria;
            ValorVenda = valorVenda;
            UltimaVenda = ultimaVenda;
            DataCadastro = dataCadastro;
            Situacao = situacao;
        }

        public void SetValorVenda(decimal valor)
        {
            ValorVenda = valor;
        }

        public void SetSituacao(char sit)
        {
            Situacao = sit;
        }
        public override string ToString()
        {
            return $"CDB: {CDB}\nNome: {Nome}\nCategoria: {Categoria}\nValor Venda: {ValorVenda}\n" +
                $"Ultima Venda: {UltimaVenda}\nData Cadastro: {DataCadastro}\nSituação: {Situacao}";
        }

        private string FormatarDecimal(decimal valor)
        {
            return valor.ToString("0000.00", CultureInfo.InvariantCulture);
        }

        public static List<Medicine> LerArquivoMedicine(string diretorio, string nomeArquivo)
        {
            var fullMedicine = Arquivo.CarregarArquivo(diretorio, nomeArquivo);
            StreamReader medicineSR = new StreamReader(fullMedicine);
            using (medicineSR)
            {
                List<Medicine> medicines = new List<Medicine>();
                string line;
                while ((line = medicineSR.ReadLine()) != null)
                {
                    if (line.Length == 78)
                    {
                        string cdb = line.Substring(0, 13);
                        string nome = line.Substring(13, 40);
                        char categoria = char.Parse(line.Substring(53, 1));
                        decimal valorVenda = decimal.Parse(line.Substring(54, 7).Trim(), CultureInfo.InvariantCulture);
                        DateOnly ultimaVenda = DateOnly.ParseExact(line.Substring(61, 8), "ddMMyyyy");
                        DateOnly dataCadastro = DateOnly.ParseExact(line.Substring(69, 8), "ddMMyyyy");
                        char situacao = char.Parse(line.Substring(77, 1));
                        Medicine medicine = new Medicine(cdb, nome, categoria, valorVenda, ultimaVenda, dataCadastro, situacao);
                        medicines.Add(medicine);
                    }
                }
                return medicines;
            }

        }

        public static void GravarMedicine(List<Medicine> lista, string fullPath)
        {
            StreamWriter writer = new StreamWriter(fullPath);
            using (writer)
            {
                foreach (var medicine in lista)
                {
                    writer.WriteLine(medicine.ToFile());
                }
            }
        }

        public string ToFile()
        {
            return $"{CDB}{Nome}{Categoria}{FormatarDecimal(this.ValorVenda)}{UltimaVenda.ToString("ddMMyyyy")}{DataCadastro.ToString("ddMMyyyy")}{Situacao}";
        }
    }
}

