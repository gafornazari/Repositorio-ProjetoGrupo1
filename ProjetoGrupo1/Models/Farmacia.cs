using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGrupo1.Models
{
    public class Farmacia
    {
        Sales cliente = new Sales();
        List<Sales> ListaSales = new List<Sales>();


        public void IncluirSales()
        {
            int auxid = 0;


            while (auxid == 0)
            {

                Console.WriteLine("Digite um número inteiro com 5 dígitos:");
                string id = Console.ReadLine();
                if (id.Length == 5 && id.All(char.IsDigit))
                {
                    Console.WriteLine("Entrada válida: contém apenas números e tem 5 dígitos.");
                    auxid = 1;
                    int numero = int.Parse(id);
                }
                else
                {
                    Console.WriteLine("Entrada invalida! ");
                    Console.WriteLine("O Id deve conter apenas 5 numeros inteiros!");
                    Console.WriteLine("Tente novamente!");
                }

            }
            int auxcpf = 0;

            while (auxcpf == 0)
            {

                Console.WriteLine("Digite o CPF do cliente: ");
                string cpf = Console.ReadLine();
                foreach(var cliente in ListaClientes)
                {
                    if(cliente.SetId(cpf) == cpf)
                    {
                        Console.WriteLine("Cliente encontrado!");
                        auxcpf = 1;
                    }
                    else
                    {
                        Console.WriteLine("Cliente não encontrado!");
                        Console.WriteLine("Necessario fazer um cadastro ou digite o numero novamente!");
                    }
                }
                foreach(var )

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
