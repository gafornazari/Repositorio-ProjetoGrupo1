using ProjetoGrupo1;
using System.Security.AccessControl;
Farmacia farmacia = new Farmacia();

int menuprincipal = 0, cadastro = 0, cliente, fornecedor, 
    principio, manipulacao, compras;

void CadastrosBasicos()
{
    do
    {
        Console.WriteLine("---- CADASTROS BÁSICOS ----");
        Console.WriteLine("1 - Clientes");
        Console.WriteLine("2 - Fornecedores");
        Console.WriteLine("3 - Princípios ativos");
        Console.WriteLine("4 - Medicamentos");
        Console.WriteLine("5 - Sair");
        cadastro = int.Parse(Console.ReadLine());
        switch (cadastro)
        {
            //Cliente
            case 1:
                do
                {
                    Console.WriteLine("1 - Incluir Cliente");
                    Console.WriteLine("2 - Imprimir Clientes");
                    Console.WriteLine("3 - Alterar Clientes");
                    Console.WriteLine("4 - Localizar Clientes");
                    Console.WriteLine("5 - Sair");
                    cliente = int.Parse(Console.ReadLine());

                    switch (cliente)
                    {
                        case 1:
                            farmacia.AdicionarCliente();
                            break;
                        case 2:

                            farmacia.ExibirClientes();
                            break;
                        case 3:

                            farmacia.AlterarCliente();
                            break;
                        case 4:
                            Console.WriteLine("Qual o cpf do cliente que deseja buscar?");
                            string cpf = Console.ReadLine();
                            farmacia.LocalizarCliente(cpf);
                            break;
                        case 5:
                            Console.WriteLine("Saindo");
                            break;
                        default:
                            Console.WriteLine("Opção Inválida");
                            break;
                    }
                } while (cliente != 5);
                break;
            //Fornecedor
            case 2:
                do
                {
                    Console.WriteLine("1 - Incluir Fornecedor");
                    Console.WriteLine("2 - Imprimir Fornecedos");
                    Console.WriteLine("3 - Alterar Fornecedor");
                    Console.WriteLine("4 - Localizar Fornecedor");
                    Console.WriteLine("5 - Sair");
                    fornecedor = int.Parse(Console.ReadLine());

                    switch (fornecedor)
                    {
                        case 1:
                            farmacia.AdicionarFornecedor();
                            break;
                        case 2:
                            farmacia.ExibirFornecedores();
                            break;
                        case 3:

                            farmacia.AlterarFornecedores();
                            break;
                        case 4:
                            Console.WriteLine("Qual o cnpj da empresa que deseja buscar?");
                            string cnpj = Console.ReadLine();
                            farmacia.LocalizarFornecedor(cnpj);
                            Console.WriteLine(cnpj);
                            break;
                        case 5:
                            Console.WriteLine("Saindo");
                            break;
                        default:
                            Console.WriteLine("Opção Inválida");
                            break;
                    }
                } while (fornecedor != 5);
                break;
            //Princípio Ativo
            case 3:
                do
                {
                    Console.WriteLine("1 - Inserir Princípio Ativo");
                    Console.WriteLine("2 - Localizar Princípio Ativo");
                    Console.WriteLine("3 - Alterar Princípio Ativo");
                    Console.WriteLine("4 - Imprimir Princípio Ativo");
                    Console.WriteLine("5 - Sair");
                    principio = int.Parse(Console.ReadLine());

                    switch (principio)
                    {
                        case 1:
                            farmacia.IncluirIngredient();
                            break;
                        case 2:
                            Console.WriteLine("Qual o Id do ingrediente que deseja localizar?");
                            string idloc = Console.ReadLine();
                            farmacia.LocalizarIngridient(idloc);
                            break;
                        case 3:
                            Console.WriteLine("Qual o Id do ingrediente que deseja alterar?");
                            string idalt = Console.ReadLine();
                            farmacia.AlterarIngridient(idalt);
                            break;
                        case 4:
                            farmacia.ImprimirIngridient();
                            break;
                        case 5:
                            Console.WriteLine("Saindo");
                            break;
                        default:
                            Console.WriteLine("Opção Inválida");
                            break;
                    }
                } while (principio != 5);
                break;
            //Medicamentos
            case 4:
                do
                {
                    Console.WriteLine("1 - Inserir");
                    Console.WriteLine("2 - Localizar");
                    Console.WriteLine("3 - Alterar");
                    Console.WriteLine("4 - Imprimir");
                    Console.WriteLine("5 - Sair");
                    manipulacao = int.Parse(Console.ReadLine());

                    switch (manipulacao)
                    {
                        case 1:
                            farmacia.IncluirMedicine();
                            break;
                        case 2:
                            Console.WriteLine("Qual o CDB do medicamento que deseja localizar?");
                            string idloc = Console.ReadLine();
                            Medicine localizar = farmacia.LocalizarMedicine(idloc);
                            if (localizar != null)
                                Console.WriteLine(localizar.ToString());
                            else
                                Console.WriteLine("CDB não encontrado!");
                            break;
                        case 3:
                            Console.WriteLine("Qual o CDB do medicamento que deseja alterar?");
                            string idalt = Console.ReadLine();
                            Medicine alterar = farmacia.LocalizarMedicine(idalt);
                            if (alterar != null)
                                farmacia.AlterarMedicine(idalt);
                            else
                                Console.WriteLine("CDB não encontrado!");

                            break;
                        case 4:
                            farmacia.ImprimirMedicines();
                            break;
                        case 5:
                            Console.WriteLine("Saindo");
                            break;
                        default:
                            Console.WriteLine("Opção Inválida");
                            break;
                    }
                } while (manipulacao != 5);
                break;
            case 5:
                Console.WriteLine("Saindo");
                break;
            default:
                Console.WriteLine("Opção Inválida");
                break;
        }
    } while (cadastro != 5);
}

void VendasMedicamentos()
{
    do
    {
        
    }
    while (true);
}

void ComprasPrincipiosAtivos()
{
    do
    {
        Console.WriteLine("---- COMPRAS DE PRINCÍPIOS ATIVOS ----");
        Console.WriteLine("1 - Registrar compra");
        Console.WriteLine("2 - Localizar compras");
        Console.WriteLine("3 - Localizar os itens comprados");
        Console.WriteLine("4 - Alterar");
        Console.WriteLine("5 - Exibir compra");
        Console.WriteLine("6 - Exibir itens já comprados");
        Console.WriteLine("7 - Sair");
        compras = int.Parse(Console.ReadLine());

        switch (compras)
        {
            case 1:
                farmacia.IncluirPurchases();
                break;
            case 2:
                Console.WriteLine("Qual o Id da compra que deseja encontrar?");
                int IdCompras = int.Parse(Console.ReadLine());
                farmacia.LocalizarPurchases(IdCompras);
                break;
            case 3:
                Console.WriteLine("Qual o Id do item que deseja encontrar?");
                int IdItem = int.Parse(Console.ReadLine());
                farmacia.LocalizarPurchaseItem(IdItem);
                break;
            case 4:
                Console.WriteLine("Qual o Id da compra que deseja alterar?");
                int IdAlt = int.Parse(Console.ReadLine());
                farmacia.AlterarPurchases(IdAlt);
                break;
            case 5:
                Console.WriteLine("Imprimindo lista de compras");
                farmacia.ImprimirPurchases();
                break;
            case 6:
                Console.WriteLine("Imprimindo lista de itens comprados");
                farmacia.ImprimirPurchaseItens();
                break;
            case 7:
                Console.WriteLine("Saindo");
                break;
            default:
                Console.WriteLine("Opção Inválida");
                break;
        }
    } while (compras != 7);
}

void ManipulacaoMedicamentos()
{
    Console.WriteLine("---- MANIPULAÇÃO DE MEDICAMENTOS ----");
    Console.WriteLine("1 - Clientes");
    Console.WriteLine("2 - Fornecedores");
    Console.WriteLine("3 - Princípios ativos");
    Console.WriteLine("4 - Medicamentos");
    Console.WriteLine("5 - Sair");
}

do
{
    Console.WriteLine("---- MENU PRINCIPAL ----");
    Console.WriteLine("1 - Cadastros básicos");
    Console.WriteLine("2 - Vendas de medicamentos");
    Console.WriteLine("3 - Compras de princípios ativos");
    Console.WriteLine("4 - Manipulação de medicamentos");
    Console.WriteLine("5 - Sair");
    menuprincipal = int.Parse(Console.ReadLine());

    switch (menuprincipal)
    {
        case 1:
            CadastrosBasicos();
            break;
        case 2:
            VendasMedicamentos();
            break;
        case 3:
            ComprasPrincipiosAtivos();
            break;
        case 4:
            ManipulacaoMedicamentos();
            break;
        case 5:
            Console.WriteLine("Saindo");
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }

} while (menuprincipal != 5);