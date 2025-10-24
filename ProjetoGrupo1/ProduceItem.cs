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

        public string ToFile()
        {
            return $"{this.IdProduceItem}{this.IdProducao}{this.IdPrincipio}{FormatarInt()}";
        }

    }



}
