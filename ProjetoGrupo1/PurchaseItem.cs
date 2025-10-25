using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProjetoGrupo1
{
    public class PurchaseItem
    {
        public int IdCompra { get; private set; }
        public string Ingrediente { get; private set; }
        public int Quantidade { get; private set; }
        public double ValorUnitario { get; private set; }
        public double TotaItem { get; private set; }
        public PurchaseItem(int idCompra, string ingrediente, int quantidade,
            double valorUnitario, double totaItem)
        {
            IdCompra = idCompra;
            Ingrediente = ingrediente;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            TotaItem = totaItem;
        }
        public void setValorUnitario(double valorUnitario)
        {
            this.ValorUnitario = valorUnitario;
        }
        public void setQuantidade(int quantidade)
        {
            this.Quantidade = quantidade;
        }
        public void setTotaItem(double totaItem)
        {
            this.TotaItem = totaItem;
        }
        public override string ToString()
        {
            return $"Id da Compra: {IdCompra}, Ingrediente: {Ingrediente}," +
                $"Quantidade: {Quantidade}, Valor Unitário: {ValorUnitario}, " +
                $"Total do Item: {TotaItem}";
        }

        public static List<PurchaseItem> LerArquivoPurchasesItem(string diretorio, string nomeArquivo)
        {
            var fullPath = Arquivo.CarregarArquivo(diretorio, nomeArquivo);
            StreamReader purchaseItensSR = new StreamReader(fullPath);
            using (purchaseItensSR)
            {
                if (purchaseItensSR.ReadToEnd() is "")
                {
                    return new List<PurchaseItem>();
                }
                else
                {
                    List<PurchaseItem> purchaseItens = new List<PurchaseItem>();
                    string line;
                    while ((line = purchaseItensSR.ReadLine()) is not null)
                    {
                        //var idCompra = line.Substring(0, 5);
                        //var ingredient = line.Substring(5, 6);
                        //var quantity = line.Substring(15, 14);
                        //var TotalItem = line.Substring(29, 8);
                        //PurchaseItem purchaseItem = new PurchaseItem(int.Parse(idCompra),
                        //    int.Parse(ingredient), int.Parse(quantity),
                        //    double.Parse(TotalItem));
                        //purchaseItens.Add(purchaseItem);
                    }
                    purchaseItensSR.Close();
                    return purchaseItens;
                }
            }
        }

        public static void GravarPurchaseItem(List<PurchaseItem> lista, string fullPath)
        {
            StreamWriter writer = new StreamWriter(fullPath);
            using (writer)
            {
                foreach (var purchaseItem in lista)
                {
                    writer.WriteLine(purchaseItem.ToFile());
                }
                writer.Close();
            }
        }
      
        public string ToFile()
        {
            return $"{IdCompra}{Ingrediente}{Quantidade}" +
                $"{ValorUnitario}{TotaItem}";
        }
    }
}





