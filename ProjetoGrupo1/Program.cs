using ProjetoGrupo1;
Farmacia farmacia = new Farmacia();

int menuprincipal = 0, cadastro = 0, cliente, fornecedor, principio, manipulacao;

void CadastrosBasicos()
{
    Console.WriteLine("---- CADASTROS BÁSICOS ----");
    Console.WriteLine("1 - Clientes");
    Console.WriteLine("2 - Fornecedores");
    Console.WriteLine("3 - Princípios ativos");
    Console.WriteLine("4 - Medicamentos");
    cadastro = int.Parse(Console.ReadLine());
    switch (cadastro)
    {
        //Cliente
        case 1:
            Console.WriteLine("1 - Incluir Cliente");
            Console.WriteLine("2 - Imprimir Clientes");
            Console.WriteLine("3 - Alterar Clientes");
            Console.WriteLine("4 - Localizar Clientes");
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
            }
            break;
        //Fornecedor
        case 2:
            Console.WriteLine("1 - Incluir Fornecedor");
            Console.WriteLine("2 - Imprimir Fornecedos");
            Console.WriteLine("3 - Alterar Fornecedor");
            Console.WriteLine("4 - Localizar Fornecedor");
            Console.WriteLine("0 - Sair");
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
            }
            break;
        //Princípio Ativo
        case 3:
            Console.WriteLine("1 - Inserir Princípio Ativo");
            Console.WriteLine("2 - Localizar Princípio Ativo");
            Console.WriteLine("3 - Alterar Princípio Ativo");
            Console.WriteLine("4 - Imprimir Princípio Ativo");
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
            }
            break;
        //Medicamentos
        case 4:
            Console.WriteLine("1 - Inserir");
            Console.WriteLine("2 - Localizar");
            Console.WriteLine("3 - Alterar");
            Console.WriteLine("4 - Imprimir");
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
            }
            break;


    }
}

void VendasMedicamentos()
{
    Console.WriteLine("---- VENDAS DE MEDICAMENTOS ----");
    Console.WriteLine("1 - Clientes");
    Console.WriteLine("2 - Fornecedores");
    Console.WriteLine("3 - Princípios ativos");
    Console.WriteLine("4 - Medicamentos");

}

void ComprasPrincipiosAtivos()
{
    Console.WriteLine("---- COMPRAS DE PRINCÍPIOS ATIVOS ----");
    Console.WriteLine("1 - Registrar compra");
    Console.WriteLine("2 - Localizar compras");
    Console.WriteLine("3 - Localizar os itens comprados");
    Console.WriteLine("4 - Alterar");
}

void ManipulacaoMedicamentos()
{
    Console.WriteLine("---- MANIPULAÇÃO DE MEDICAMENTOS ----");
    Console.WriteLine("1 - Clientes");
    Console.WriteLine("2 - Fornecedores");
    Console.WriteLine("3 - Princípios ativos");
    Console.WriteLine("4 - Medicamentos");
}

do
{
    Console.WriteLine("---- MENU PRINCIPAL ----");
    Console.WriteLine("1 - Cadastros básicos");
    Console.WriteLine("2 - Vendas de medicamentos");
    Console.WriteLine("3 - Compras de princípios ativos");
    Console.WriteLine("4 - Manipulação de medicamentos");
    Console.WriteLine("0 - Sair");
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
        default:
             Console.WriteLine("Opção inválida!");
            break;
    }

} while (menuprincipal != 0);