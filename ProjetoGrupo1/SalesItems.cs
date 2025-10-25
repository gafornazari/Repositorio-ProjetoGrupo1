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
        public string ToFile()
        {
            return $"{this.IdVenda}{this.Medicamento}{this.Quantidade}{this.ValorUnitario}{TotalItem}";
        }



    }
}
