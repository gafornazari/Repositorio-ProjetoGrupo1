using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGrupo1
{
    public class Medicine
    {
        public string CDB{ get; set; }
        public string Nome{ get; set; }
        public char Categoria{ get; set; }
        public decimal ValorVenda{ get; set; }
        public DateOnly UltimaVenda{ get; set; }
        public DateOnly DataCadastro{ get; set; }
        public char Situacao {  get; set; }

        public Medicine(string cdb, string nome, char categoria, decimal valorVenda)
        {
            CDB = cdb;
            Nome = nome;
            Categoria = categoria;
            ValorVenda = valorVenda;
            DataCadastro = DateOnly.FromDateTime(DateTime.Now);
            Situacao = 'A';
        }

        public override string ToString()
        {
            return $"CDB: {CDB}, Nome: {Nome}, Categoria: {Categoria}, Valor Venda: {ValorVenda}," +
                $" Ultima Venda: {UltimaVenda}, Data Cadastro: {DataCadastro}, Situação: {Situacao}";
        }

    }
}
