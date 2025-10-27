using System;
using System.Collections.Generic;
using System.Globalization;
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
        public double TotalItem { get; private set; }
        public PurchaseItem(int idCompra, string ingrediente, int quantidade,
            double valorUnitario, double totalItem)
        {
            IdCompra = idCompra;
            Ingrediente = ingrediente;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            TotalItem = totalItem;
            CalcularTotalItem();
        }
        public void setValorUnitario(double valorUnitario)
        {
            this.ValorUnitario = valorUnitario;
            CalcularTotalItem();
        }
        public void setQuantidade(int quantidade)
        {
            this.Quantidade = quantidade;
            CalcularTotalItem();

        }

        private void CalcularTotalItem()
        {
            this.TotalItem = this.Quantidade * this.ValorUnitario;
        }

        public override string ToString()
        {
            return $"Id da Compra: {IdCompra}\n" +
                $" Ingrediente: {Ingrediente}\n" +
                $"Quantidade: {Quantidade}\n" +
                $" Valor Unitário: {ValorUnitario}\n" +
                $"Total do Item: {TotalItem}\n";
        }

        public static List<PurchaseItem> LerArquivoPurchasesItem(string 
            diretorio, string nomeArquivo)
        {
            var fullPath = Arquivo.CarregarArquivo(diretorio, nomeArquivo);
            StreamReader purchaseItensSR = new StreamReader(fullPath);
            using (purchaseItensSR)
            {
                List<PurchaseItem> purchaseItens = new List<PurchaseItem>();
                string line;
                while ((line = purchaseItensSR.ReadLine()) != null)
                {
                    if (line.Length == 31)//trocar o 0 pela quantidade de carcateres da linha
                    {

                        var idCompra = line.Substring(0, 5);
                        var ingredient = line.Substring(5, 6);
                        var quantity = line.Substring(11, 4);
                        double ValorUnitario = double.Parse(line.Substring(15, 6).
                            Trim(), CultureInfo.InvariantCulture);
                        double TotalItem = double.Parse(line.Substring(21, 10).Trim(), 
                            CultureInfo.InvariantCulture);
                        PurchaseItem purchaseItem = new PurchaseItem(int.Parse(idCompra),
                            ingredient, int.Parse(quantity),
                            ValorUnitario, TotalItem);
                        purchaseItens.Add(purchaseItem);
                    }
                }
                return purchaseItens;
            }
        }

        public static void GravarPurchaseItem(List<PurchaseItem> lista, 
            string fullPath)
        {
            StreamWriter writer = new StreamWriter(fullPath);
            using (writer)
            {
                foreach (var purchaseItem in lista)
                {
                    writer.WriteLine(purchaseItem.ToFile());
                }
            }
        }
        private string FormatarDoubleTotal(double valor)
        {
            return valor.ToString("00000000.00", CultureInfo.InvariantCulture);
        }

        private string FormatarDoubleUnitario(double valor)
        {
            return valor.ToString("000.00", CultureInfo.InvariantCulture);
        }

        public string ToFile()
        {
            return $"{IdCompra}{Ingrediente}{Quantidade}" +
                $"{FormatarDoubleUnitario(ValorUnitario)}{FormatarDoubleTotal(TotalItem)}";
        }
    }
}





