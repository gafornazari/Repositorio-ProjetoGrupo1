using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGrupo1
{
    public class Sales
    {
        public int Id { get; private set; }
        public DateOnly DataVenda { get; private set; }
        public string ClienteCPF { get; private set; }
        public decimal ValorTotal { get; private set; }
        public List<SalesItems> ListaSalesItems { get; private set; }
        public Sales()
        {
        }
        public Sales(string cliente)
        {
            SetId(new Random().Next(10000, 100000));
            DataVenda = DateOnly.FromDateTime(DateTime.Now);
            ClienteCPF = cliente;
            ValorTotal = 0;
            ListaSalesItems = new List<SalesItems>();
        }

        public Sales(int id, DateOnly dataVenda, string clienteCPF, decimal valorTotal)
        {
            Id = id;
            DataVenda = dataVenda;
            ClienteCPF = clienteCPF;
            ValorTotal = valorTotal;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public void SetDataVenda(DateOnly dataVenda)
        {
            this.DataVenda = dataVenda;
            CalcularValorTotal();
        }

        public void SetCliente(string cliente)
        {
            this.ClienteCPF = cliente;
            CalcularValorTotal();
        }

        public bool ItemsFull()
        {
            return this.ListaSalesItems.Count == 3;
        }

        private void CalcularValorTotal()
        {
            this.ValorTotal = 0;
            foreach (SalesItems item in ListaSalesItems)
            {
                this.ValorTotal += item.TotalItem;
            }
        }

        public void SetValorTotal()
        {
            this.ValorTotal = 0;
            CalcularValorTotal();
        }

        public void IncluirListaSalesItems(SalesItems salesItems)
        {
            this.ListaSalesItems.Add(salesItems);
            CalcularValorTotal();
        }

        public override string ToString()
        {
            return $"Id: {this.Id}\n" +
                $"Data: {this.DataVenda}\n" +
                $"CPF do Cliente: {this.ClienteCPF}\n" +
                $"Valor Total: {this.ValorTotal}\n";
        }

        public static List<Sales> LerArquivoSales(string diretorio, string salesArquivo)
        {
            var fullNomeArquivo = Arquivo.CarregarArquivo(diretorio, salesArquivo);
            StreamReader SalesSR = new StreamReader(fullNomeArquivo);
            using (SalesSR)
            {
                if (SalesSR.ReadToEnd() is "")
                {
                    return new List<Sales>();
                }
                else
                {
                    List<Sales> sales = new List<Sales>();
                    string line;
                    while ((line = SalesSR.ReadLine()) is not null)
                    {
                        var id = int.Parse(line.Substring(0, 5));
                        var date = DateOnly.Parse(line.Substring(5, 8));
                        var cpf = line.Substring(13, 11);
                        var totalValue = decimal.Parse(line.Substring(24, 7));
                        Sales sale = new Sales(id, date, cpf, totalValue);
                        sales.Add(sale);
                    }
                    SalesSR.Close();
                    return sales;
                }
            }
        }

        public static void GravarSales(List<Sales> lista, string fullPath)
        {
            StreamWriter writer = new StreamWriter(fullPath);
            using (writer)
            {
                foreach (var sale in lista)
                {
                    writer.WriteLine(sale.ToFile());
                }
                writer.Close();
            }
        }


        public string FormatarData(DateOnly data)
        {
            string dataFormatada = data.ToString("ddMMyyyy");
            return dataFormatada;
        }

        public string ToFile()
        {
            return $"{this.Id}{FormatarData(this.DataVenda)}{this.ClienteCPF}{this.ValorTotal}";
        }
    }
}

