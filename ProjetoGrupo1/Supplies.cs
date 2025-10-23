using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGrupo1
{
    public class Supplies
    {
        public string CNPJ { get; private set; }
        public string RazaoSocial { get; private set; }
        public string Pais { get; private set; }
        public DateOnly DataAbertura { get; private set; }
        public DateOnly UltimoFornecimento { get; private set; }
        public DateOnly DataCadastro { get; private set; }
        public char Situacao { get; private set; }

        public Supplies()
        {

        }

        public Supplies(string cNPJ,
            string razaoSocial,
            string pais,
            DateOnly dataAbertura,
            DateOnly ultimoFornecimento,
            DateOnly dataCadastro,
            char situacao)
        {
            CNPJ = cNPJ;
            RazaoSocial = razaoSocial;
            Pais = pais;
            DataAbertura = dataAbertura;
            UltimoFornecimento = ultimoFornecimento;
            DataCadastro = dataCadastro;
            Situacao = situacao;
        }


        public void SetSituacao(char situacao)
        {
            Situacao = situacao;
        }

        public void SetUltimoFornecimento(DateOnly ultimoFornecimento)
        {
            UltimoFornecimento = ultimoFornecimento;
        }

        public void SetPais(string pais)
        {
            Pais = pais;
        }

        public override string ToString()
        {
            return $"CNPJ: {this.CNPJ}\n Razão social: {this.RazaoSocial}\n País: {this.Pais}\n " +
                $"Data Abertura: {this.DataAbertura}\n Ultimo fornecimento: {this.UltimoFornecimento}\n " +
                $"Data Cadastro: {this.DataCadastro}\n Situação: {this.Situacao}";
        }



    }
}
