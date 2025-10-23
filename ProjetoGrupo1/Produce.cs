using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGrupo1
{
    public class Produce
    {
        public int Id {  get; private set; }
        public DateOnly DataProducao { get; private set; }
        public double IdMedicamento { get; private set; }
        public int Quantidade { get; private set; }


        public Produce(
           int id,
           DateOnly dataProducao,
           double idMedicamento,
           int quantidade
       )
        {
            this.Id = id;
            this.DataProducao = dataProducao;
            this.IdMedicamento = idMedicamento;
            this.Quantidade = quantidade;
        }
        public Produce( 
            int id, 
            double idMedicamento, 
            int quantidade
        )
        {
            this.Id = id;
            this.DataProducao = DateOnly.FromDateTime(DateTime.Now);
            this.IdMedicamento = idMedicamento;
            this.Quantidade = quantidade;
        }

        public void SetQuantidade(int quantidade)
        {
            this.Quantidade = quantidade;
        }

        public void SetMedicamento(double idMedicamento)
        {
            this.IdMedicamento = idMedicamento;
        }

        public override string ToString()
        {
            return $"Id: {this.Id}\n" +
                $"Data de Produção: {this.DataProducao}\n" +
                $"Código de Barras do Medicamento: {this.IdMedicamento}\n" +
                $"Quantidade: {this.Quantidade}\n";
        }

        private string FormatarInt()
        {
            string resultado = this.Quantidade.ToString().PadLeft( 3, '0' );
            return resultado;
        }

        

        public string ToFile()
        {
            return $"{this.Id}{this.DataProducao}{this.IdMedicamento}{FormatarInt()}";
        }
    }
}
