using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoGrupo1;


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

    public Customer(string cpf, string nome, DateOnly dataNascimento, string telefone,
                      DateOnly ultimaCompra, DateOnly dataCadastro, char situacao)
    {
        CPF = cpf;
        Nome = nome;
        DataNascimento = dataNascimento;
        Telefone = telefone;
        UltimaCompra = ultimaCompra;
        DataCadastro = dataCadastro;
        Situacao = situacao;
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

    public string RestrictedCustomers(List<Customer> ListaRestrictedCustomers)
    {
        return $"{ListaRestrictedCustomers}";
    }


    public string FormatString(string nome)
    {
        return nome.PadRight(50, ' ');
    }

    public static List<Customer> LerArquivoCustomer(string diretorio, string nomeArquivo)
    {
        var fullNomeArquivo = Arquivo.CarregarArquivo(diretorio, nomeArquivo);
        StreamReader customerSR = new StreamReader(fullNomeArquivo);
        using (customerSR)
        {
            if (customerSR.ReadToEnd() is "")
            {
                return new List<Customer>();
            }
            else
            {
                List<Customer> customers = new List<Customer>();
                string line;
                while ((line = customerSR.ReadLine()) is not null)
                {
                    string cpf = line.Substring(0, 11);
                    string nome = line.Substring(11, 50);
                    DateOnly dataNascimento = DateOnly.Parse(line.Substring(61, 8));
                    string telefone = line.Substring(69, 11);
                    DateOnly ultimaCompra = DateOnly.Parse(line.Substring(80, 8));
                    DateOnly dataCadastro = DateOnly.Parse(line.Substring(88, 8));
                    char situacao = char.Parse(line.Substring(96, 1));
                    Customer customer = new Customer(cpf, nome, dataNascimento, telefone,
                        ultimaCompra, dataCadastro, situacao);
                    //aqui na linha de cima, se algo nn for do tipo string, tem que fazer o Parse
                    customers.Add(customer);
                }
                customerSR.Close();
                return customers;
            }
        }
    }

    public static void GravarCustomer(List<Customer> lista, string fullPath)
    {
        StreamWriter writer = new StreamWriter(fullPath);
        using (writer)
        {
            foreach (var customer in lista)
            {
                writer.WriteLine(customer.ToFile());
            }
            writer.Close();
        }
    }


    public string ToFile()
    {
        return $"{this.CPF}{this.Nome}{this.DataNascimento.ToString("ddMMyyyy")}{this.Telefone}" +
            $"{this.UltimaCompra.ToString("ddMMyyyy")}{this.DataCadastro.ToString("ddMMyyyy")}{this.Situacao}";
    }

    public static List<Customer> LerArquivoRestrictedCustomer(string diretorio, string nomeArquivo)
    {
        var fullNomeArquivo = Arquivo.CarregarArquivo(diretorio, nomeArquivo);
        StreamReader customerRestrictedSR = new StreamReader(fullNomeArquivo);
        using (customerRestrictedSR)
        {
            if (customerRestrictedSR.ReadToEnd() is "")
            {
                return new List<Customer>();
            }
            else
            {
                List<Customer> customersRest = new List<Customer>();
                string line;
                while ((line = customerRestrictedSR.ReadLine()) is not null)
                {
                    //lógica para adicionar na lista de customer restrito
                    //customersRest.Add(customerRest);
                }
                customerRestrictedSR.Close();
                return customersRest;
            }
        }
    }

    public static void GravarCustomerRestricted(List<Customer> lista, string fullPath)
    {
        StreamWriter writer = new StreamWriter(fullPath);
        using (writer)
        {
            foreach (var customerRest in lista)
            {
                writer.WriteLine(customerRest.ToFileRest());
            }
            writer.Close();
        }
    }

    public string ToFileRest()
    {
        //lógica para gravar o cpf
        return $"";
    }

}