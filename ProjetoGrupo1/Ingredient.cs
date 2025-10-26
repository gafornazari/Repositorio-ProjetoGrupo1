using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoGrupo1
{
    public class Ingredient
    {
        public string Id { get; private set; }
        public string Nome { get; private set; }
        public DateOnly UltimaCompra { get; private set; }
        public DateOnly DataCadastro { get; private set; }
        public char Situacao { get; private set; }

        public Ingredient()
        {

        }
        public Ingredient(string id, string nome)
        {
            Id = id;
            Nome = nome;
            DataCadastro = DateOnly.FromDateTime(DateTime.Now);
            Situacao = 'A';
        }

        public Ingredient(string id, string nome, DateOnly ultimaCompra, DateOnly dataCadastro, char situacao)
        {
            Id = id;
            Nome = nome;
            UltimaCompra = ultimaCompra;
            DataCadastro = dataCadastro;
            Situacao = situacao;
        }

        public void SetSituacao(char situacao)
        {
            Situacao = situacao;
        }

        public void SetUltimaCompra(DateOnly ultimacompra)
        {
            UltimaCompra = ultimacompra;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Nome}, Última compra: {UltimaCompra}," +
                $" Data cadastro: {DataCadastro}, Situação: {Situacao}";
        }

        public static List<Ingredient> LerArquivoIngredient(string diretorio, string nomeArquivo)
        {
            var fullIngridient = Arquivo.CarregarArquivo(diretorio, nomeArquivo);
            StreamReader ingridientSR = new StreamReader(fullIngridient);
            using (ingridientSR)
            {
                if (ingridientSR.ReadToEnd() is "")
                {
                    return new List<Ingredient>();
                }
                else
                {
                    List<Ingredient> ingredients = new List<Ingredient>();
                    string line;
                    while ((line = ingridientSR.ReadLine()) is not null)
                    {
                        string id = line.Substring(0, 6);
                        string nome = line.Substring(6, 20);
                        DateOnly ultimaVenda = DateOnly.Parse(line.Substring(26, 8));
                        DateOnly dataCadastro = DateOnly.Parse(line.Substring(34, 8));
                        char situacao = char.Parse(line.Substring(42, 1));
                        Ingredient ingredient = new Ingredient(id, nome, ultimaVenda, dataCadastro, situacao);
                        ingredients.Add(ingredient);
                    }
                    ingridientSR.Close();
                    return ingredients;
                }
            }
        }

        public static void GravarIngredient(List<Ingredient> lista,string fullPath)
        {

            StreamWriter writer = new StreamWriter(fullPath);
            using (writer)
            {
                foreach (var ingredient in lista)
                {
                    writer.WriteLine(ingredient.ToFile());
                }
                writer.Close();
            }
        }

        public string FormatarData(DateOnly data)
        {
            string dataFormatada = data.ToString("ddMMyyyy");
            return dataFormatada;
        }

        public string ToFile()
        {
            return $"{Id}{Nome}{FormatarData(UltimaCompra)}{FormatarData(DataCadastro)}{Situacao}";
        }

    }
}
