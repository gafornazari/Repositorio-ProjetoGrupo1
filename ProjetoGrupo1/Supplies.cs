using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGrupo1;

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
    public string ToFile()
    {
        return $"{this.CNPJ}{this.RazaoSocial}{this.Pais}{this.DataAbertura.ToString("ddMMyyyy")}{this.UltimoFornecimento.ToString("ddMMyyyy")}{this.DataCadastro.ToString("ddMMyyyy")}{this.Situacao}";
    }


}