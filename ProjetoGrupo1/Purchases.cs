using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProjetoGrupo1
{
    public class Purchases
    {
        public int Id { get; private set; }
        public DateOnly DataCompra { get; private set; }
        public string Fornecedor { get; private set; }
        public double ValorTotal { get; private set; }
        public List<PurchaseItem> purchaseItems;
        public Purchases(int id, DateOnly dataCompra,
            string fornecedor, double valorTotal)
        {
            this.Id = id;
            this.DataCompra = dataCompra;
            this.Fornecedor = fornecedor;
            this.ValorTotal = valorTotal;
            this.purchaseItems = new List<PurchaseItem>();
            CalcularTotal();
        }
        public string DataFormatada()
        {
            return DataCompra.ToString("ddMMyyyy");
        }
        public override string ToString()
        {
            return $"Id: {Id}\nData da Compra: {DataFormatada()}\n" +
                $"Fornecedor: {Fornecedor}\n" +
                $"Valor Total: {ValorTotal}";
        }
        public void setValorTotal()
        {
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            this.ValorTotal = 0;
            foreach (var item in this.purchaseItems)
            {
                this.ValorTotal += item.TotalItem;
            }
        }
        public static List<Purchases> LerArquivoPurchases(string diretorio, 
            string nomeArquivo)
        {
            var fullPath = Arquivo.CarregarArquivo(diretorio, nomeArquivo);
            StreamReader purchaseSR = new StreamReader(fullPath);
            using (purchaseSR)
            {
                List<Purchases> purchases = new List<Purchases>();
                string line;
                while ((line = purchaseSR.ReadLine()) != null)
                {
                    if (line.Length == 37)
                    {
                        var id = line.Substring(0, 5);
                        DateOnly dataCompra = DateOnly.ParseExact
                            (line.Substring(5, 10), "ddMMyyyy");
                        var suplierCNPJ = line.Substring(14, 14);
                        double TotalValue = double.Parse(line.Substring(29, 8).Trim(),
                            CultureInfo.InvariantCulture);
                        Purchases purchase = new Purchases(int.Parse(id),
                            dataCompra, suplierCNPJ,
                            TotalValue);
                        purchases.Add(purchase);
                    }
                }
                return purchases;
            }
        }

        public static void GravarPurchases(List<Purchases> lista, string fullPath)
        {
            StreamWriter writer = new StreamWriter(fullPath);
            using (writer)
            {
                foreach (var purchases in lista)
                {
                    writer.WriteLine(purchases.ToFile());
                }
            }
        }

        private string FormatarDouble(double valor)
        {
            return valor.ToString("00000000.00", CultureInfo.InvariantCulture);
        }
        public string ToFile()
        {
            return $"{Id}{DataFormatada()}{Fornecedor}{FormatarDouble(ValorTotal)}";
        }
    }
}





