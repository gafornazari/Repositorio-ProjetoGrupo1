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
        public List<SalesItems> ListaSalesItems { get; private set; }


        public Sales()
        {
        }

        public Sales(string cliente)
        {
            SetId(new Random().Next(10000, 100000));
            DataVenda = DateOnly.FromDateTime(DateTime.Now);
            ClienteCPF = cliente;
            ValorTotal = 0;
            ListaSalesItems = new List<SalesItems>();
        }
        public void SetId (int id)
        {
            Id = id;
        }

        
        public void SetDataVenda(DateOnly dataVenda)
        {
            this.DataVenda = dataVenda;
            CalcularValorTotal();
        }
        public void SetCliente(string cliente)
        {
            this.ClienteCPF = cliente;
            CalcularValorTotal();
        }

        public bool ItemsFull()
        {
            return this.ListaSalesItems.Count == 3;
        }
        private void CalcularValorTotal()
        {
            foreach (SalesItems item in ListaSalesItems)
            {
                this.ValorTotal += item.TotalItem;
            }
        }
        public void SetValorTotal()
        {
            this.ValorTotal = 0;
            CalcularValorTotal();
        }

        public void IncluirListaSalesItems(SalesItems salesItems)
        {
            this.ListaSalesItems.Add(salesItems);
            CalcularValorTotal();
        }
        

        public override string ToString()
        {
            return $"Id: {this.Id}\n" +
                $"Data: {this.DataVenda}\n" +
                $"CPF do Cliente: {this.ClienteCPF}\n" +
                $"Valor Total: {this.ValorTotal}\n";
        }

        public string ToFile()
        {
            return $"{this.Id}{this.DataVenda}{this.ClienteCPF}{this.ValorTotal}";
        }

    }
}
