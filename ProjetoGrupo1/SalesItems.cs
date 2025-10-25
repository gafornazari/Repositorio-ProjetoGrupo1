using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                if (SalesItemsSR.ReadToEnd() is "")
                {
                    return new List<SalesItems>();
                }
                else
                {
                    List<SalesItems> salesItems = new List<SalesItems>();
                    string line;
                    while ((line = SalesItemsSR.ReadLine()) is not null)
                    {
                        var idVenda = int.Parse(line.Substring(0, 5));
                        var chave = int.Parse(line.Substring(5, 5));
                        var codigoDeBarras = line.Substring(10, 13);
                        var quantidade = int.Parse(line.Substring(23, 3));
                        var valorUnitario = decimal.Parse(line.Substring(26, 6));
                        var totalItem = decimal.Parse(line.Substring(32, 7));
                        SalesItems salesItem = new SalesItems(idVenda, chave, codigoDeBarras, quantidade,
                            valorUnitario, totalItem);
                        salesItems.Add(salesItem);
                    }
                    SalesItemsSR.Close();
                    return salesItems;
                }
            }
        }

        public void GravarSalesItems(List<SalesItems> lista)
        {
            string fullPath = @"";
            StreamWriter writer = new StreamWriter(fullPath);
            using (writer)
            {
                foreach (var salesItems in lista)
                {
                    writer.WriteLine(salesItems.ToFile());
                }
                writer.Close();
            }
        }

        public string ToFile()
        {
            return $"{this.IdVenda}{this.Medicamento}{this.Quantidade}{this.ValorUnitario}{TotalItem}";
        }



    }
}
