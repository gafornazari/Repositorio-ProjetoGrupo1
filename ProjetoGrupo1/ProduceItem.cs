using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGrupo1
{
    public class ProduceItem
    {
        public int IdProduceItem { get; private set; }
        public int IdProducao { get; private set; }
        public string IdPrincipio { get; private set; }
        public int QuantidadePrincipio { get; private set; }

        public ProduceItem
        (
            int idProduceItem,
            int idProducao,
            string idPrincipio,
            int quantidadePrincipio
        )
        {
            this.IdProduceItem = idProduceItem;
            this.IdProducao = idProducao;
            this.IdPrincipio = idPrincipio;
            this.QuantidadePrincipio = quantidadePrincipio;
        }

        public void SetIdPrincipio(string id)
        {
            this.IdPrincipio = id;
        }

        public void SetQuantidadePrincipio(int quantidade)
        {
            this.QuantidadePrincipio = quantidade;
        }

        public override string ToString()
        {
            return $"Id Item de produção: {this.IdProduceItem}\n" +
                   $"Id da produção: {this.IdProducao}\n" +
                   $"Princípio Ativo: {this.IdPrincipio}\n" +
                   $"Quantidade do Princípio Ativo: {this.QuantidadePrincipio}\n";
        }

        private string FormatarInt()
        {
            string resultado = this.QuantidadePrincipio.ToString().PadLeft(4, '0');
            return resultado;
        }

        public static List<ProduceItem> LerArquivoProduceItem(string diretorio, string nomeArquivo)
        {
            var fullNomeArquivo = Arquivo.CarregarArquivo(diretorio, nomeArquivo);
            StreamReader produceItemSR = new StreamReader(fullNomeArquivo);
            using (produceItemSR)
            {
                if (produceItemSR.ReadToEnd() is "")
                {
                    return new List<ProduceItem>();
                }
                else
                {
                    List<ProduceItem> produceItems = new List<ProduceItem>();
                    string line;
                    while ((line = produceItemSR.ReadLine()) is not null)
                    {
                        int idProduceItem = int.Parse(line.Substring(0, 5));
                        int idProducao = int.Parse(line.Substring(5, 5));
                        string idPrincipio = line.Substring(10, 6);
                        int quantidade = int.Parse(line.Substring(16, 4));
                        ProduceItem produceItem = new ProduceItem(idProduceItem, idProducao, idPrincipio, quantidade);
                    produceItems.Add(produceItem);
                    }
                    produceItemSR.Close();
                    return produceItems;
                }
            }
        }

        public static void GravarProduceItem(List<ProduceItem> lista, string fullPath)
        {
            StreamWriter writer = new StreamWriter(fullPath);
            using (writer)
            {
                foreach (var produceItem in lista)
                {
                    writer.WriteLine(produceItem.ToFile());
                }
                writer.Close();
            }
        }

        public string ToFile()
        {
            return $"{this.IdProduceItem}{this.IdProducao}{this.IdPrincipio}{FormatarInt()}";
        }

    }



}