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
                        DateOnly ultimaFornecimento, DateOnly dataCadastro, char situacao)
    {
        CNPJ = cnpj;
        RazaoSocial = razaoSocial;
        Pais = pais;
        DataAbertura = dataAbertura;
        UltimoFornecimento = ultimaFornecimento;
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
        return $"CNPJ: {this.CNPJ}\n Razão social: {this.RazaoSocial}\n País: {this.Pais}\n " +
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

    public string FormatarData(DateOnly data)
    {
        string dataFormatada = data.ToString("ddMMyyyy");
        return dataFormatada;
    }


    public static List<Suppliers> LerArquivoSuppliers(string diretorio, string nomeArquivo)
    {
        var fullSuppliers = Arquivo.CarregarArquivo(diretorio, nomeArquivo);
        StreamReader suppliersSR = new StreamReader(fullSuppliers);
        using (suppliersSR)
        {
            List<Suppliers> suppliers = new List<Suppliers>();
            string line;
            while ((line = suppliersSR.ReadLine()) != null)
            {
                if (line.Length == 109)
                {
                    string cnpj = line.Substring(0, 14);
                    string razaoSocial = line.Substring(14, 50);
                    string pais = line.Substring(64, 20);
                    DateOnly dataAbertura = DateOnly.ParseExact(line.Substring(84, 8), "ddMMyyyy");
                    DateOnly ultimaFornecimento = DateOnly.ParseExact(line.Substring(92, 8), "ddMMyyyy");
                    DateOnly dataCadastro = DateOnly.ParseExact(line.Substring(100, 8), "ddMMyyyy");
                    char situacao = char.Parse(line.Substring(108, 1));
                    Suppliers supplier = new Suppliers(cnpj, razaoSocial, pais, dataAbertura,
                        ultimaFornecimento, dataCadastro, situacao);
                    suppliers.Add(supplier);
                }
            }
            return suppliers;
        }
    }

    public static void GravarSupplier(List<Suppliers> lista, string fullPath)
    {
        StreamWriter writer = new StreamWriter(fullPath);
        using (writer)
        {
            foreach (var supplier in lista)
            {
                writer.WriteLine(supplier.ToFile());
            }
        }
    }

    public string ToFile()
    {
        return $"{this.CNPJ}{FormatString(this.RazaoSocial)}{FormatStringPais(this.Pais)}{FormatarData(this.DataAbertura)}{FormatarData(this.UltimoFornecimento)}{FormatarData(this.DataCadastro)}{this.Situacao}";
    }


    public static List<Suppliers> LerArquivoRestrictecSupplies(string diretorio, string nomeArquivo)
    {
        var fullNomeArquivo = Arquivo.CarregarArquivo(diretorio, nomeArquivo);
        StreamReader suppliersRestrictedSR = new StreamReader(fullNomeArquivo);
        using (suppliersRestrictedSR)
        {
            List<Suppliers> suppliersRest = new List<Suppliers>();
            string line;
            while ((line = suppliersRestrictedSR.ReadLine()) != null)
            {
                if (line.Length == 14)
                {
                    string cnpj = line.Substring(0, 14);
                    suppliersRest.Add(new Suppliers());
                }
            }
            return suppliersRest;
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
        }
    }

    public string ToFileRest()
    {

        return $"{this.CNPJ}";
    }

}