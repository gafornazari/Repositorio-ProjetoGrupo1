using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGrupo1
{
    public class Sales
    {
        public int Id { get; private set; }
        public DateOnly DataVenda { get; private set; }
        public string ClienteCPF { get; private set; }
        public decimal ValorTotal { get; private set; }
        public List<SalesItems> ListaSalesItems;
        public void SetId(int id)
        {
            Id = id;
        }

        
        public void SetDataVenda(DateOnly dataVenda)
        {
            DataVenda = dataVenda;
        }
        public void SetCliente(string cliente)
        {
            ClienteCPF = cliente;
        }
        public void SetValorTotal(decimal valorTotal)
        {
            ValorTotal = valorTotal;
        }

        public Sales()
        {
        }

        public Sales(string cliente)
        {
            SetId(new Random().Next(10000, 100000));
            DataVenda = DateOnly.FromDateTime(DateTime.Now);
            ClienteCPF = cliente;
            ValorTotal = 0;
        }

        public override string ToString()
        {
            return $"Id: {this.Id}";
        }

    }
}
