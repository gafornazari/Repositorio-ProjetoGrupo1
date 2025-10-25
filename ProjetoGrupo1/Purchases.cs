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
                //$"Fornecedor: {Fornecedor}, " +
                $"Valor Total: {ValorTotal}";
        }
        public string ToFile()
        {
            return $"{Id}{DataFormatada()}" +//$"{Fornecedor}" +
                $"{ValorTotal}";
        }

        public void setValorTotal(double valorTotal)
        {
            this.ValorTotal = valorTotal;
        }

      
    }
}
