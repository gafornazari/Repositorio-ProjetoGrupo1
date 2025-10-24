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
        public string Id { get; set; }
        public string Nome { get; set; }
        public DateOnly UltimaCompra { get; set; }
        public DateOnly DataCadastro { get; set; }
        public char Situacao { get; set; }

        public Ingredient()
        {
            
        }
        public Ingredient(string id, string nome)
        {
            Id = id;
            Nome = nome;
            DataCadastro = DateOnly.FromDateTime(DateTime.Now);
            Situacao = 'A';
        }3,


        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Nome}, Última compra: {UltimaCompra}, Data cadastro: {DataCadastro}, Situação: {Situacao}";
        }
    }
}
