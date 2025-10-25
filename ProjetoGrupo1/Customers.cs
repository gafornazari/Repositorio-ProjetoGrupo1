using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoGrupo1
{

    public class Customer
    {
        public string CPF { get; private set; }
        public string Nome { get; private set; }
        public DateOnly DataNascimento { get; private set; }
        public string Telefone { get; private set; }
        public DateOnly UltimaCompra { get; private set; }
        public DateOnly DataCadastro { get; private set; }
        public char Situacao { get; private set; }

        public Customer()
        {

        }

        public Customer(string cpf,
            string nome,
            DateOnly dataNascimento,
            string telefone
            )
        {
            CPF = cpf;
            Nome = nome;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            DataCadastro = DateOnly.FromDateTime(DateTime.Now);
            Situacao = 'A';
        }

        public void SetSituacao(char situacao)
        {
            Situacao = situacao;
        }

        public void SetTelefone(string telefone)
        {
            Telefone = telefone;
        }

        public void SetUltimaCompra(DateOnly ultimaCompra)
        {
            UltimaCompra = ultimaCompra;
        }


        public DateOnly GetDataNascimento()
        {
            return DataNascimento;
        }
        
        public override string ToString()
        {
            return $"CPF: {this.CPF}\n Nome: {this.Nome}\n Data Nascimento: {this.DataNascimento}\n " +
                $"Telefone: {this.Telefone}\n Ultima compra: {this.UltimaCompra}\n " +
                $"Data Cadastro: {this.DataCadastro}\n Situação: {this.Situacao}";
        }

        public string RestrictedCustomers( List<Customer> ListaRestrictedCustomers)
        {
            return $"{ListaRestrictedCustomers}";
        }


        public string FormatString(string nome)
        {
            return nome.PadRight(50, ' ');
        }
        public string ToFile()
        {
            return $"{this.CPF}{this.Nome}{this.DataNascimento.ToString("ddMMyyyy")}{this.Telefone}{this.UltimaCompra.ToString("ddMMyyyy")}{this.DataCadastro.ToString("ddMMyyyy")}{this.Situacao}";
        }

    }
}
