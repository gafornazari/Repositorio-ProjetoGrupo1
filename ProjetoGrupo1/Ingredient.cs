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
            return $"Id: {Id}\nNome: {Nome}\nÚltima compra: {UltimaCompra}" +
                $"Data cadastro: {DataCadastro}\nSituação: {Situacao}";
        }

        public static List<Ingredient> LerArquivoIngredient(string diretorio, string nomeArquivo)
        {
            var fullIngridient = Arquivo.CarregarArquivo(diretorio, nomeArquivo);
            StreamReader ingridientSR = new StreamReader(fullIngridient);
            using (ingridientSR)
            {
                List<Ingredient> ingredients = new List<Ingredient>();
                string line;
                while ((line = ingridientSR.ReadLine()) != null)
                {
                    if (line.Length == 43)
                    {
                        string id = line.Substring(0, 6);
                        string nome = line.Substring(6, 20);
                        DateOnly ultimaVenda = DateOnly.ParseExact(line.Substring(26, 8), "ddMMyyyy");
                        DateOnly dataCadastro = DateOnly.ParseExact(line.Substring(34, 8), "ddMMyyyy");
                        char situacao = char.Parse(line.Substring(42, 1));
                        Ingredient ingredient = new Ingredient(id, nome, ultimaVenda, dataCadastro, situacao);
                        ingredients.Add(ingredient);
                    }
                }
                return ingredients;
            }
        }

        public static void GravarIngredient(List<Ingredient> lista, string fullPath)
        {

            StreamWriter writer = new StreamWriter(fullPath);
            using (writer)
            {
                foreach (var ingredient in lista)
                {
                    writer.WriteLine(ingredient.ToFile());
                }
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
