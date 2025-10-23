using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGrupo1.Models
{
    public class Farmacia
    {
        
        List<Sales> ListaSales = new List<Sales>();


        public void IncluirSales()
        {
            
           
            Console.WriteLine("Digite o CPF do cliente: ");
            string cpf = Console.ReadLine();
            var customer = LocalizarCustomer(cpf);

            if (customer == null)
            {
                Console.WriteLine("Cliente não cadastrado!");

            }
            else if (LocalizarClientesRestritos(cpf))
            {
                Console.WriteLine("Cliente restrito");
            }
            else
            {

            }

        }

        public void LocalizarSales(int id)
        {
            foreach (var venda in ListaSales)
            {
                if (venda.Id == id)
                {
                    Console.WriteLine("Venda encontrada!");
                    Console.WriteLine(venda.ToString());
                }
                else
                {
                    Console.WriteLine("Venda não encontrado!");
                }
            }
        }

        public void VerificarItem()
        {
            int auxid1 = 0;

            Console.WriteLine("Digite um número inteiro com 5 dígitos:");
            string entrada = Console.ReadLine();
            if (entrada.Length == 5 && entrada.All(char.IsDigit))
            {
                Console.WriteLine("Entrada válida: contém apenas números e tem 5 dígitos.");
                auxid1 = 1;
                int numero = int.Parse(entrada);
                Console.WriteLine(entrada);
            }
            else
            {
                Console.WriteLine("Entrada invalida! ");
                Console.WriteLine("O Id deve conter apenas 5 numeros inteiros!");
                Console.WriteLine("Tente novamente!");
            }

        }





    }
}
