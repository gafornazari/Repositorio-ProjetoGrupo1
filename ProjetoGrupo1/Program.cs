
using ProjetoGrupo1.Models;

List<Farmacia> farmacia = new List<Farmacia>();

string option;

do
{
    Console.Clear();
    Console.WriteLine("1 - Cadastrar Cliente");
    Console.WriteLine("2 - Exibir Clientes");
    Console.WriteLine("3 - Atualizar Clientes");
    Console.WriteLine("4 - Buscar Cliente");
    Console.WriteLine("0 - Sair");
    option = Console.ReadLine()!;
    switch (option)
    {
        case "1":
            Farmacia.EqualsAdicionarClientes();
            break;
        case "2":
            ExibirProduces();
            break;
        case "3":
            RemoverProduce();
            break;
        case "4":
            AtualizarProduce();
            break;
        case "0":
            Console.WriteLine("Saindo...");
            break;
        default:
            Console.WriteLine("Escolha uma opção válida");
            break;
    }
} while (option != "0");