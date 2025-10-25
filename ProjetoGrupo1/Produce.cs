using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGrupo1
{
    public class Produce
    {
        public int Id { get; private set; }
        public DateOnly DataProducao { get; private set; }
        public string CdbMedicamento { get; private set; }
        public int Quantidade { get; private set; }


        public Produce(
           int id,
           DateOnly dataProducao,
           string cdbMedicamento,
           int quantidade
       )
        {
            this.Id = id;
            this.DataProducao = dataProducao;
            this.CdbMedicamento = cdbMedicamento;
            this.Quantidade = quantidade;
        }
        public Produce(
            int id,
            string cdbMedicamento,
            int quantidade
        )
        {
            this.Id = id;
            this.DataProducao = DateOnly.FromDateTime(DateTime.Now);
            this.CdbMedicamento = cdbMedicamento;
            this.Quantidade = quantidade;
        }

        public void SetQuantidade(int quantidade)
        {
            this.Quantidade = quantidade;
        }

        public void SetMedicamento(string cdbMedicamento)
        {
            this.CdbMedicamento = cdbMedicamento;
        }

        public override string ToString()
        {
            return $"Id: {this.Id}\n" +
                $"Data de Produção: {this.DataProducao}\n" +
                $"Código de Barras do Medicamento: {this.CdbMedicamento}\n" +
                $"Quantidade: {this.Quantidade}\n";
        }

        private string FormatarInt()
        {
            string resultado = this.Quantidade.ToString().PadLeft(3, '0');
            return resultado;
        }


        public void GravarProduce(List<Produce> lista)
        {
            string fullPath = @"";
            StreamWriter writer = new StreamWriter(fullPath);
            using (writer)
            {
                foreach (var produce in lista)
                {
                    writer.WriteLine(produce.ToFile());
                }
                writer.Close();
            }
        }

        public string ToFile()
        {
            return $"{this.Id}{FormatarData(this.DataProducao)}{this.CdbMedicamento}{FormatarInt()}";
        }
    }
}