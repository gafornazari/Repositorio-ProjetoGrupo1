using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGrupo1.Models
{
    public class Sales
    {
        public int Id { get; private set; }
        public DateOnly DataVenda { get; private set; }
        public string ClienteCPF { get; private set; }
        public decimal ValorTotal { get; private set; }

        public void SetID (int id)
        {
            this.Id = id;
        }
        public void SetDataVenda(DateOnly dataVenda)
        {
            this.DataVenda = dataVenda;
        }
        public void SetCliente(string cliente)
        {
            this.Cliente = cliente;
        }
        public void SetValorTotal(decimal valorTotal)
        {
            this.ValorTotal = valorTotal;
        }

        public Sales()
        {
        }

        public Sales(int id, string cliente, decimal valorTotal)
        {
            Id = new Random().Next(10000, 100000);
            DataVenda = DateOnly.FromDateTime(DateTime.Now);
            ClienteCPF = cliente;
            ValorTotal = valorTotal;
        }

        public override string ToString()
        {
            return $"Id: {Id}";
        }

    }
}
