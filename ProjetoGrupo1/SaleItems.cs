using System.Globalization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGrupo1
{
    public class SalesItems
    {
        public int IdVenda { get; private set; }
        public int Chave { get; private set; }
        public string Medicamento { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public decimal TotalItem { get; private set; }
        public SalesItems()
        {
        }
        public SalesItems(int idVenda, string medicamento, int quantidade, decimal valorUnitario)
        {
            this.Chave = new Random().Next(10000, 100000);
            this.IdVenda = idVenda;
            this.Medicamento = medicamento;
            this.Quantidade = quantidade;
            this.ValorUnitario = valorUnitario;
            CalcularTotalItem();
        }

        public SalesItems(int idVenda, int chave,
            string medicamento, int quantidade,
            decimal valorUnitario, decimal totalItem)
        {
            IdVenda = idVenda;
            Chave = chave;
            Medicamento = medicamento;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            TotalItem = totalItem;
        }

        public SalesItems(int idVenda, string codigoDeBarras, int quantidade,
                            decimal valorUnitario, decimal totalItem)
        {
            IdVenda = idVenda;
            Medicamento = codigoDeBarras;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            TotalItem = totalItem;
        }
        public void SetQuantidade(int quantidade)
        {
            this.Quantidade = quantidade;
            CalcularTotalItem();
        }
        public void SetValorUnitario(decimal valorUnitario)
        {
            this.ValorUnitario = valorUnitario;
            CalcularTotalItem();
        }
        private void CalcularTotalItem()
        {
            this.TotalItem = this.Quantidade * this.ValorUnitario;
        }
        public override string ToString()
        {
            return $"Id Venda: {this.IdVenda}\n" +
                   $"Id Item: {this.Chave}\n" +
                   $"Código de Barra do medicamento: {this.Medicamento}\n" +
                   $"Quantidade: {this.Quantidade}\n" +
                   $"Valor unitário: {this.ValorUnitario}\n" +
                   $"Total: {this.TotalItem}\n";
        }

        public static List<SalesItems> LerArquivoSalesItems(string diretorio, string salesItemsArquivo)
        {
            var fullNomeArquivo = Arquivo.CarregarArquivo(diretorio, salesItemsArquivo);
            StreamReader SalesItemsSR = new StreamReader(fullNomeArquivo);
            using (SalesItemsSR)
            {

                List<SalesItems> salesItems = new List<SalesItems>();
                string line;
                while ((line = SalesItemsSR.ReadLine()) != null)
                {
                    if (line.Length == 39)
                    {
                        var idVenda = int.Parse(line.Substring(0, 5));
                        var codigoDeBarras = line.Substring(5, 13);
                        var quantidade = int.Parse(line.Substring(18, 3));
                        var valorUnitario = decimal.Parse(line.Substring(21, 7));
                        var totalItem = decimal.Parse(line.Substring(28, 11));
                        SalesItems salesItem = new SalesItems(idVenda, codigoDeBarras, quantidade,
                            valorUnitario, totalItem);
                        salesItems.Add(salesItem);
                    }
                }
                return salesItems;
            }
        }

        public static void GravarSalesItems(List<SalesItems> lista, string fullPath)
        {
            StreamWriter writer = new StreamWriter(fullPath);
            using (writer)
            {
                foreach (var salesItems in lista)
                {
                    writer.WriteLine(salesItems.ToFile());
                }
            }
        }

        private string FormatarDecimalUnitario(decimal valor)
        {
            return valor.ToString("0000.00", CultureInfo.InvariantCulture);
        }

        private string FormatarDecimalTotal(decimal valor)
        {
            return valor.ToString("00000000.00", CultureInfo.InvariantCulture);
        }

        private string FormatarDecimalQuantidade(int valor)
        {
            return valor.ToString("000", CultureInfo.InvariantCulture);
        }

        public string ToFile()
        {
            return $"{this.IdVenda}{this.Medicamento}{FormatarDecimalQuantidade(this.Quantidade)}{FormatarDecimalUnitario(this.ValorUnitario)}{FormatarDecimalTotal(TotalItem)}";
        }



    }
}
