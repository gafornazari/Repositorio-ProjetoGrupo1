using System;
using System.Collections.Generic;
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
        public Purchases(int id, DateOnly dataCompra,
            string fornecedor, double valorTotal)
        {
            Id = id;
            DataCompra = dataCompra;
            Fornecedor = fornecedor;
            ValorTotal = valorTotal;
        }
        public string DataFormatada()
        {
            return DataCompra.ToString("ddMMyyyy");
        }
        public override string ToString()
        {
            return $"Id: {Id}, Data da Compra: {DataFormatada()}, " +
                $"Fornecedor: {Fornecedor}, " +
                $"Valor Total: {ValorTotal}";
        }
        public void setValorTotal(double valorTotal)
        {
            this.ValorTotal = valorTotal;
        }

        public static List<Purchases> LerArquivoPurchases(string diretorio, string nomeArquivo)
        {
            var fullPath = Arquivo.CarregarArquivo(diretorio, nomeArquivo);
            StreamReader purchaseSR = new StreamReader(fullPath);
            using (purchaseSR)
            {
                if (purchaseSR.ReadToEnd() is "")
                {
                    return new List<Purchases>();
                }
                else
                {
                    List<Purchases> purchases = new List<Purchases>();
                    string line;
                    while ((line = purchaseSR.ReadLine()) is not null)
                    {
                    //    var id = line.Substring(0, 5);
                    //    var date = line.Substring(5, 10);
                    //    var suplierCNPJ = line.Substring(14, 14);
                    //    var TotalValue = line.Substring(29, 8);
                    //    Purchases purchase = new Purchases(int.Parse(id),
                    //        DateOnly.Parse(date), /*suplierCNPJ,*/
                    //        double.Parse(TotalValue));
                    //    purchases.Add(purchase);
                    }
                    purchaseSR.Close();
                    return purchases;
                }
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
                writer.Close();
            }
        }


        public string ToFile()
        {
            return $"{Id}{DataFormatada()}" +$"{Fornecedor}" +
                $"{ValorTotal}";
        }
    }
}





