using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGrupo1
{
    internal class PurchaseItem
    {
        public PurchaseItem(int idCompra, /*int ingrediente*/ int quantidade,
            double valorUnitario, double totaItem)
        {
            IdCompra = idCompra;
            //Ingredient = ingrediente;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            TotaItem = totaItem;
        }

        public int IdCompra { get; private set; }
        //public int Ingrediente { get; private set; }
        public int Quantidade { get; private set; }
        public double ValorUnitario { get; private set; }
        public double TotaItem { get; private set; }

        public override string ToString()
        {
            return $"Id da Compra: {IdCompra}," + /*Ingrediente: {Ingrediente},*/  
                $"Quantidade: {Quantidade}, Valor Unitário: {ValorUnitario}, " +
                $"Total do Item: {TotaItem}";
        }
        public string ToFile()
        {
            return $"{IdCompra}" /*{Ingrediente}*/+$"{Quantidade}" +
                $"{ValorUnitario}{TotaItem}";
        }
    }
}
