using System;
using System.Collections.Generic;
using System.Globalization;
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
           string cdbMedicamento,
           int quantidade
        )
        {
            this.Id = new Random().Next(10000, 100000);
            this.DataProducao = DateOnly.FromDateTime(DateTime.Now);
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

        public static List<Produce> LerArquivoProduce(string diretorio, string nomeArquivo)
        {
            var fullProduce = Arquivo.CarregarArquivo(diretorio, nomeArquivo);
            StreamReader produceSR = new StreamReader(fullProduce);
            using (produceSR)
            {
                if (produceSR.ReadToEnd() is "")
                {
                    return new List<Produce>();
                }
                else
                {
                    List<Produce> produces = new List<Produce>();
                    string line;
                    while ((line = produceSR.ReadLine()) is not null)
                    {
                        int id = int.Parse(line.Substring(0, 5));
                        DateOnly data = DateOnly.Parse(line.Substring(5, 10));
                        string idMedicamento = line.Substring(15, 13);
                        int quantidade = int.Parse(line.Substring(28, 3));
                        Produce produce = new Produce(id, data, idMedicamento, quantidade);
                        //aqui na linha de cima, se algo nn for do tipo string, tem que fazer o Parse
                        produces.Add(produce);
                    }
                    produceSR.Close();
                    return produces;
                }
            }
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

        public string FormatarData(DateOnly data)
        {
            string dataFormatada = data.ToString("ddmmyyyy");
            return dataFormatada; 
        }

        public string ToFile()
        {
            return $"{this.Id}{FormatarData(this.DataProducao)}{this.CdbMedicamento}{FormatarInt()}";
        }
    }
}