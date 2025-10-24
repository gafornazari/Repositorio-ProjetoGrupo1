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
        public Ingredient Ingrediente { get; private set; }
        public int Quantidade { get; private set; }
        public double ValorUnitario { get; private set; }
        public double TotaItem { get; private set; }
        public PurchaseItem(int idCompra, string ingrediente, int quantidade,
            double valorUnitario, double totaItem)
        {
            IdCompra = idCompra;
            Ingrediente = new Ingredient(ingrediente);
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
        public string ToFile()
        {
            return $"{IdCompra}{Ingrediente}{Quantidade}" +
                $"{ValorUnitario}{TotaItem}";
        }
    }
}
