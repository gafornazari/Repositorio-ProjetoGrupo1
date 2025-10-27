using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ProjetoGrupo1;


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

    public string GetCPF()
    {
        return CPF;
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

    public string FormatarData(DateOnly data)
    {
        string dataFormatada = data.ToString("ddMMyyyy");
        return dataFormatada;

    }


    public string FormatString(string nome)
    {
        return nome.PadRight(50, ' ');
    }

    public string FormatCpf(string cpf)
    {
        return CPF.Replace(".", "").Replace("/", "").Replace("-", "").Trim();
    }
    public static List<Customer> LerArquivoCustomer(string diretorio, string nomeArquivo)
    {
        var fullNomeArquivo = Arquivo.CarregarArquivo(diretorio, nomeArquivo);
        StreamReader customerSR = new StreamReader(fullNomeArquivo);
        using (customerSR)
        {
            List<Customer> customers = new List<Customer>();
            string line;
            while ((line = customerSR.ReadLine()) != null)
            {
                if (line.Length == 97)
                {
                    string cpf = line.Substring(0, 11);
                    string nome = line.Substring(11, 50);
                    DateOnly dataNascimento = DateOnly.ParseExact(line.Substring(61, 8), "ddMMyyyy");
                    string telefone = line.Substring(69, 11);
                    DateOnly ultimaCompra = DateOnly.ParseExact(line.Substring(80, 8), "ddMMyyyy");
                    DateOnly dataCadastro = DateOnly.ParseExact(line.Substring(88, 8), "ddMMyyyy");
                    char situacao = char.Parse(line.Substring(96, 1));
                    Customer customer = new Customer(cpf, nome, dataNascimento, telefone,
                        ultimaCompra, dataCadastro, situacao);
                    customers.Add(customer);
                }
            }
            return customers;
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
        }
    }


    public string ToFile()
    {
        return $"{this.CPF}{FormatString(this.Nome)}{FormatarData(this.DataNascimento)}{this.Telefone}" +
            $"{FormatarData(this.UltimaCompra)}{FormatarData(this.DataCadastro)}{this.Situacao}";
    }

    public static List<Customer> LerArquivoRestrictedCustomer(string diretorio, string nomeArquivo)
    {
        var fullNomeArquivo = Arquivo.CarregarArquivo(diretorio, nomeArquivo);
        StreamReader customerRestrictedSR = new StreamReader(fullNomeArquivo);
        using (customerRestrictedSR)
        {
                List<Customer> customersRest = new List<Customer>();
                string line;
                while ((line = customerRestrictedSR.ReadLine()) != null)
                {
                    if(line.Length == 11)
                {
                    string cpf = line.Substring(0, 11);
                    customersRest.Add(new Customer());
                }
                }
                return customersRest;
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
        }
    }


    public string ToFileRest()
    {

        return $"{FormatCpf(this.CPF)}";
    }

}