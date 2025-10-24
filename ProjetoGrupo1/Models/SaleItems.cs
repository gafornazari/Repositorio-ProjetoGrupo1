using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGrupo1.Models
{
    public class SaleItems
    {
        public int IdVenda { get; private set; }
        public string Medicamento { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public decimal TotalItem { get; private set; }

        public SaleItems()
        {
        }

        public SaleItems(int idVenda, string medicamento, int quantidade, decimal valorUnitario, decimal totalItem)
        {
            IdVenda = idVenda;
            Medicamento = medicamento;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            TotalItem = totalItem;
        }

        public void SetIdVenda(int idVenda)
        {
            IdVenda = idVenda;
        }
        public void SetMedicamento(string medicamento)
        {
            Medicamento = medicamento;
        }
        public void SetQuantidade(int  quantidade)
        {
            Quantidade = quantidade;
        }
        public void SetvalorUnitario(decimal valorUnitario)
        {
            ValorUnitario = valorUnitario;
        }
        public void SettotalItem(decimal totalItem)
        {
            TotalItem = totalItem;
        }
    }


}
