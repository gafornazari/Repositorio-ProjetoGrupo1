using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGrupo1;

public class Suppliers
{
    public string CNPJ { get; private set; }
    public string RazaoSocial { get; private set; }
    public string Pais { get; private set; }
    public DateOnly DataAbertura { get; private set; }
    public DateOnly UltimoFornecimento { get; private set; }
    public DateOnly DataCadastro { get; private set; }
    public char Situacao { get; private set; }

    public Suppliers()
    {

    }

    public Suppliers(string cNPJ,
        string razaoSocial,
        string pais,
        DateOnly dataAbertura
     )


    {
        SetCNPJ(cNPJ);
        RazaoSocial = razaoSocial;
        Pais = pais;
        DataAbertura = dataAbertura;
        DataCadastro = DateOnly.FromDateTime(DateTime.Now);
        Situacao = 'A';
    }

    public Suppliers(string cnpj, string razaoSocial, string pais, DateOnly dataAbertura,
                        DateOnly ultimaFornecimento, DateOnly  dataCadastro, char situacao)
    {
        RazaoSocial = razaoSocial;
        Pais = pais;
        DataAbertura = dataAbertura;
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

    public string FormatString(string razaoSocial)
    {
        return razaoSocial.PadRight(50, ' ');
    }

    public string FormatStringPais(string pais)
    {
        return pais.PadRight(20, ' ');
    }

    public static List<Suppliers> LerArquivoSuppliers(string diretorio, string nomeArquivo)
    {
        var fullSuppliers = Arquivo.CarregarArquivo(diretorio, nomeArquivo);
        StreamReader suppliersSR = new StreamReader(fullSuppliers);
        using (suppliersSR)
        {
            if (suppliersSR.ReadToEnd() is "")
            {
                return new List<Suppliers>();
            }
            else
            {
                List<Suppliers> suppliers = new List<Suppliers>();
                string line;
                while ((line = suppliersSR.ReadLine()) is not null)
                {
                    string cnpj = line.Substring(0, 11);
                    string razaoSocial = line.Substring(11, 50);
                    string pais = line.Substring(11, 50);
                    DateOnly dataAbertura = DateOnly.Parse(line.Substring(61, 8));
                    DateOnly ultimaFornecimento = DateOnly.Parse(line.Substring(80, 8));
                    DateOnly dataCadastro = DateOnly.Parse(line.Substring(88, 8));
                    char situacao = char.Parse(line.Substring(96, 1));
                    Suppliers supplier = new Suppliers(cnpj, razaoSocial, pais, dataAbertura,
                        ultimaFornecimento, dataCadastro, situacao);
                    suppliers.Add(supplier);
                }
                suppliersSR.Close();
                return suppliers;
            }
        }
    }

    public static void GravarSupplier(List<Suppliers> lista, string fullPath)
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
        return $"{this.CNPJ}{this.RazaoSocial}{this.Pais}{this.DataAbertura.ToString("ddMMyyyy")}{this.UltimoFornecimento.ToString("ddMMyyyy")}{this.DataCadastro.ToString("ddMMyyyy")}{this.Situacao}";
    }


    public static List<Suppliers> LerArquivoRestrictecSupplies(string diretorio, string nomeArquivo)
    {
        var fullNomeArquivo = Arquivo.CarregarArquivo(diretorio, nomeArquivo);
        StreamReader suppliersRestrictedSR = new StreamReader(fullNomeArquivo);
        using (suppliersRestrictedSR)
        {
            if (suppliersRestrictedSR.ReadToEnd() is "")
            {
                return new List<Suppliers>();
            }
            else
            {
                List<Suppliers> suppliersRest = new List<Suppliers>();
                string line;
                while ((line = suppliersRestrictedSR.ReadLine()) is not null)
                {
                    //lógica para adicionar na lista de suplier restrito
                    suppliersRest.Add(new Suppliers());
                }
                suppliersRestrictedSR.Close();
                return suppliersRest;
            }
        }
    }

    public static void GravarSupplierRestricted(List<Suppliers> lista, string fullPath)
    {
        StreamWriter writer = new StreamWriter(fullPath);
        using (writer)
        {
            foreach (var supplierRest in lista)
            {
                writer.WriteLine(supplierRest.ToFileRest());
            }
            writer.Close();
        }
    }

    public string ToFileRest()
    {
        
        return $"{this.CNPJ}";
    }

}