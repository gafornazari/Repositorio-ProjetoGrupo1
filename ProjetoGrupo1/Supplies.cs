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


        public Supplies(string cNPJ,
            string razaoSocial,
            string pais,
            DateOnly dataAbertura,
            DateOnly ultimoFornecimento,
            DateOnly dataCadastro,
            char situacao)
        {
            SetCNPJ(cNPJ);
            RazaoSocial = razaoSocial;
            Pais = pais;
            DataAbertura = dataAbertura;
            UltimoFornecimento = ultimoFornecimento;
            DataCadastro = dataCadastro;
            Situacao = situacao;
        }
        public Supplies(string cNPJ)
        {
            SetCNPJ(cNPJ);
        }
        public Supplies()
        {

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
        public string GetCNPJ()
        {
            return CNPJ;
        }
        public void SetCNPJ(string cnpj)
        {
            this.CNPJ = cnpj;
        }

        public override string ToString()
        {
            return $"CNPJ: {this.GetCNPJ()}\n Razão social: {this.RazaoSocial}\n País: {this.Pais}\n " +
                $"Data Abertura: {this.DataAbertura}\n Ultimo fornecimento: {this.UltimoFornecimento}\n " +
                $"Data Cadastro: {this.DataCadastro}\n Situação: {this.Situacao}";
        }



    }
}
