using ProjetoGrupo1;
Farmacia farmacia = new Farmacia();

string diretorio = @"C:\SneezePharma\";


////guardando o fullPath de todos
string pathCustomer = "Customers.data";
string pathSuppliers = "Suppliers.data";
string pathIngredient = "Ingredient.data";
string pathMedicine = "Medicine.data";
string pathProduce = "Produce.data";
string pathProduceItem = "ProduceItem.data";
string pathPurchaseItem = "PurchaseItem.data";
string pathPurchases = "Purchases.data";
string pathSales = "Sales.data";
string pathSalesItems = "SalesItems.data";
string pathRestrictedSupplies = "RestrictedSuppliers.data";
string pathRestrictedCustomer = "RestrictedCustomers.data";


//lendo todos os arquivos
farmacia.ListaCustomers = Customer.LerArquivoCustomer(diretorio, pathCustomer);
farmacia.ListaSuppliers = Suppliers.LerArquivoSuppliers(diretorio, pathSuppliers);
farmacia.ListaIngredients = Ingredient.LerArquivoIngredient(diretorio, pathIngredient);
farmacia.ListaMedicines = Medicine.LerArquivoMedicine(diretorio, pathMedicine);
farmacia.ListaProduces = Produce.LerArquivoProduce(diretorio, pathProduce);
farmacia.ListaProducesItems = ProduceItem.LerArquivoProduceItem(diretorio, pathProduceItem);
farmacia.ListaPurchaseItems = PurchaseItem.LerArquivoPurchasesItem(diretorio, pathPurchaseItem);
farmacia.ListaPurchases = Purchases.LerArquivoPurchases(diretorio, pathPurchases);
farmacia.ListaSales = Sales.LerArquivoSales(diretorio, pathSales);
farmacia.ListaSalesItems = SalesItems.LerArquivoSalesItems(diretorio, pathSalesItems);
farmacia.ListaRestrictedSuppliers = Suppliers.LerArquivoRestrictecSupplies(diretorio, pathRestrictedSupplies);
farmacia.ListaRestrictedCustomers = Customer.LerArquivoRestrictedCustomer(diretorio, pathRestrictedCustomer);




int menuprincipal = 0, cadastro = 0, cliente, fornecedor, principio,
    manipulacao, vendas, compras, producoes;

void CadastrosBasicos()
{
    do
    {
        Console.Clear();
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

                    Console.Clear();
                    Console.WriteLine("1 - Incluir Cliente");
                    Console.WriteLine("2 - Imprimir Clientes");
                    Console.WriteLine("3 - Alterar Clientes");
                    Console.WriteLine("4 - Localizar Clientes");
                    Console.WriteLine("5 - Clientes Restritos");
                    Console.WriteLine("0 - Sair");
                    cliente = int.Parse(Console.ReadLine());

                    switch (cliente)
                    {
                        case 1:
                            farmacia.IncluirCliente();
                            Console.ReadKey();
                            break;
                        case 2:

                            farmacia.ImprimirClientes();
                            Console.ReadKey();
                            break;
                        case 3:

                            farmacia.AlterarCliente();
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.WriteLine("Qual o cpf do cliente que deseja buscar?");
                            string cpf = Console.ReadLine();
                            farmacia.LocalizarCliente(cpf);
                            Console.ReadKey();
                            break;

                            case 5:
                           
                            int opcao;
                            do
                            {

                                Console.Clear();
                                Console.WriteLine("-----MENU DE CLIENTES RESTRITOS-----------");
                                Console.WriteLine("1 - Incluir Cliente");
                                Console.WriteLine("2 - Imprimir Clientes");
                                Console.WriteLine("3 - Alterar Clientes");
                                Console.WriteLine("4 - Localizar Clientes");
                                Console.WriteLine("5 - Sair");
                                opcao = int.Parse(Console.ReadLine());

                                switch(opcao)
                                    {
                                case 1:
                                     farmacia.IncluirClientesRestritos();
                                        Console.ReadKey();
                                        break;
                                        case 2:

                                     farmacia.ImprimirClientesRestritos();
                                        Console.ReadKey();
                                        break;
                                         case 3:

                                        farmacia.AlterarClientesRestritos();
                                        Console.ReadKey();
                                        break;
                                        case 4:
                                        Console.WriteLine("Qual o cpf do cliente que deseja localizar?");
                                        string cpfCliente = Console.ReadLine();
                                            farmacia.LocalizarClientesRestritos(cpfCliente);
                                        Console.ReadKey();
                                        break;
                                        case 5:
                                        Customer.GravarCustomerRestricted(farmacia.ListaRestrictedCustomers, Path.Combine(diretorio, pathRestrictedCustomer));
                                        Console.WriteLine("Saindo");
                                        Console.ReadKey();
                                        break;
                                     }
                                } while (opcao != 5);
                            break;

                        case 0:
                            Customer.GravarCustomer(farmacia.ListaCustomers, Path.Combine(diretorio, pathCustomer));
                            Console.WriteLine("Saindo");
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Opção Inválida");
                            Console.ReadKey();
                            break;
                    }
                } while (cliente != 0);
                break;
            //Fornecedor
            case 2:
                do
                {

                    Console.Clear();
                    Console.WriteLine("1 - Incluir Fornecedor");
                    Console.WriteLine("2 - Imprimir Fornecedos");
                    Console.WriteLine("3 - Alterar Fornecedor");
                    Console.WriteLine("4 - Localizar Fornecedor");
                    Console.WriteLine("5 - Fornecedores Restritos");
                    Console.WriteLine("0 - Sair");
                    fornecedor = int.Parse(Console.ReadLine());

                    switch (fornecedor)
                    {
                        case 1:
                            farmacia.IncluirFornecedor();
                            Console.ReadKey();
                            break;
                        case 2:
                            farmacia.ImprimirFornecedores();
                            Console.ReadKey();
                            break;
                        case 3:

                            farmacia.AlterarFornecedores();
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.WriteLine("Qual o cnpj da empresa que deseja buscar?");
                            string cnpj = Console.ReadLine();
                            farmacia.LocalizarFornecedor(cnpj);
                            Console.ReadKey();
                            break;
                            case 5:
                            int opcao;
                            do
                            {

                                Console.Clear();
                                Console.WriteLine("-----MENU DE FORNECEDORES RESTRITOS-----------");
                                Console.WriteLine("1 - Incluir Fornecedores");
                                Console.WriteLine("2 - Imprimir Fornecedores");
                                Console.WriteLine("3 - Alterar Fornecedores");
                                Console.WriteLine("4 - Localizar Fornecedores");
                                Console.WriteLine("5 - Sair");
                                opcao = int.Parse(Console.ReadLine());

                                switch (opcao)
                                {
                                    case 1:
                                        farmacia.IncluirFornecedoresRestritos();
                                        Console.ReadKey();
                                        break;
                                    case 2:

                                        farmacia.ImprimirFornecedoresRestritos();
                                        Console.ReadKey();
                                        break;
                                    case 3:

                                        farmacia.AlterarFornecedoresRestritos();
                                        Console.ReadKey();
                                        break;
                                    case 4:
                                        Console.WriteLine("Qual o cnpj do fornecedor que deseja localizar?");
                                        string cnpjFornecedor = Console.ReadLine();
                                        farmacia.LocalizarFornecedoresRestritos(cnpjFornecedor);
                                        Console.ReadKey();
                                        break;
                                    case 5:
                                        Suppliers.GravarSupplierRestricted(farmacia.ListaRestrictedSuppliers, Path.Combine(diretorio, pathRestrictedSupplies));
                                        Console.WriteLine("Saindo");
                                        Console.ReadKey();
                                        break;
                                }
                            } while (opcao != 5);
                            break;

                        case 0:
                            Suppliers.GravarSupplier(farmacia.ListaSuppliers, Path.Combine(diretorio, pathSuppliers));
                            Console.WriteLine("Saindo");
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Opção Inválida");
                            Console.ReadKey();
                            break;
                    }
                } while (fornecedor != 0);
                break;
            //Princípio Ativo
            case 3:
                do
                {

                    Console.Clear();
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
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.WriteLine("Qual o Id do ingrediente que deseja localizar?");
                            string idloc = Console.ReadLine();
                            farmacia.LocalizarIngridient(idloc);
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.WriteLine("Qual o Id do ingrediente que deseja alterar?");
                            string idalt = Console.ReadLine();
                            farmacia.AlterarIngridient(idalt);
                            Console.ReadKey();
                            break;
                        case 4:
                            farmacia.ImprimirIngridient();
                            Console.ReadKey();
                            break;
                        case 5:
                            Ingredient.GravarIngredient(farmacia.ListaIngredients, Path.Combine(diretorio, pathIngredient));
                            Console.WriteLine("Saindo");
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Opção Inválida");
                            Console.ReadKey();
                            break;
                    }
                    
                } while (principio != 5);
                break;
            //Medicamentos
            case 4:
                do
                {
                    Console.Clear();
                    Console.WriteLine("-----MENU DE MEDICAMENTOS-----------");
                    Console.WriteLine("1 - Inserir Medicamento");
                    Console.WriteLine("2 - Localizar Medicamento");
                    Console.WriteLine("3 - Alterar Medicamento");
                    Console.WriteLine("4 - Imprimir Medicamentos");
                    Console.WriteLine("5 - Sair");
                    manipulacao = int.Parse(Console.ReadLine());

                    switch (manipulacao)
                    {
                        case 1:
                            farmacia.IncluirMedicine();
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.WriteLine("Qual o CDB do medicamento que deseja localizar?");
                            string idloc = Console.ReadLine();
                            Medicine localizar = farmacia.LocalizarMedicine(idloc);
                            if (localizar != null)
                            {
                                Console.WriteLine(localizar.ToString());
                                Console.ReadKey();

                            }
                            else
                            {
                                Console.WriteLine("CDB não encontrado!");
                                Console.ReadKey();

                            }
                                
                            break;
                        case 3:
                            Console.WriteLine("Qual o CDB do medicamento que deseja alterar?");
                            string idalt = Console.ReadLine();
                            Medicine alterar = farmacia.LocalizarMedicine(idalt);
                            if (alterar != null)
                            {
                                farmacia.AlterarMedicine(idalt);
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("CDB não encontrado!");
                                Console.ReadKey();
                            }
                                

                            break;
                        case 4:
                            farmacia.ImprimirMedicines();
                            Console.ReadKey();
                            break;
                        case 5:
                            Medicine.GravarMedicine(farmacia.ListaMedicines, Path.Combine(diretorio, pathMedicine));
                            Console.WriteLine("Saindo");
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Opção Inválida");
                            Console.ReadKey();
                            break;
                    }
                } while (manipulacao != 5);
                break;
            case 5:
                
                Console.WriteLine("Saindo");
                Console.ReadKey();
                break;
            default:
                Console.WriteLine("Opção Inválida");
                Console.ReadKey();
                break;
        }
    } while (cadastro != 5);
}

void VendasMedicamentos()
{
    do
    {

        Console.Clear();
        Console.WriteLine("---- VENDAS DE MEDICAMENTOS ----");
        Console.WriteLine("1 - Registrar venda");
        Console.WriteLine("2 - Registrar um item ");
        Console.WriteLine("3 - Localizar vendas");
        Console.WriteLine("4 - Localizar os itens vendidos");
        Console.WriteLine("5 - Alterar");
        Console.WriteLine("6 - Exibir venda");
        Console.WriteLine("7 - Exibir itens já vendidos");
        Console.WriteLine("8 - Sair");
        vendas = int.Parse(Console.ReadLine());
        switch (vendas)
        {
            case 1:
                farmacia.IncluirSales();
                break;
            case 2:
                farmacia.IncluirSaleItems();
                break;
            case 3:
                farmacia.LocalizarSales();
                break;
            case 4:
                farmacia.LocalizarSalesItems();
                break;
            case 5:
                farmacia.AlterarSalesItems();
                break;
            case 6:
                Console.WriteLine("Imprimindo lista de vendas");
                farmacia.ImprimirListaSales();
                break;
            case 7:
                Console.WriteLine("Imprimindo lista de itens vendidos");
                farmacia.ImprimirListaSalesItems();
                break;
            case 8:
                Sales.GravarSales(farmacia.ListaSales, Path.Combine(diretorio, pathSales));
                SalesItems.GravarSalesItems(farmacia.ListaSalesItems, Path.Combine(diretorio, pathSalesItems));
                Console.WriteLine("Saindo");
                Console.ReadKey();
                break;
            default:
                Console.WriteLine("Opção Inválida");
                break;
        }

    }
    while (vendas != 8);
}

void ComprasPrincipiosAtivos()
{
    do
    {

        Console.Clear();
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
                Console.ReadKey();
                break;
            case 2:
                farmacia.LocalizarPurchases();
                Console.ReadKey();
                break;
            case 3:
                farmacia.LocalizarPurchaseItem();
                Console.ReadKey();
                break;
            case 4:
                Console.WriteLine("Qual o Id da compra que deseja alterar?");
                int IdAlt = int.Parse(Console.ReadLine());
                farmacia.AlterarPurchases(IdAlt);
                Console.ReadKey();
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
                Purchases.GravarPurchases(farmacia.ListaPurchases, Path.Combine(diretorio, pathPurchases));
                PurchaseItem.GravarPurchaseItem(farmacia.ListaPurchaseItems, Path.Combine(diretorio, pathPurchaseItem));
                Console.WriteLine("Saindo");
                Console.ReadKey();
                break;
            default:
                Console.WriteLine("Opção Inválida");
                Console.ReadKey();
                break;
        }
    } while (compras != 7);
}

void ManipulacaoMedicamentos()
{
    do
    {

        Console.Clear();
        Console.WriteLine("---- MANIPULAÇÃO DE MEDICAMENTOS ----");
        Console.WriteLine("1 - Incluir Produção");
        Console.WriteLine("2 - Incluir Item a ser produzido");
        Console.WriteLine("3 - Localizar Produção");
        Console.WriteLine("4 - Localizar Item produzido");
        Console.WriteLine("5 - Alterar Produção");
        Console.WriteLine("6 - Alterar Item produzido");
        Console.WriteLine("7 - Imprimir Lista de produções");
        Console.WriteLine("8 - Imrprimir Lista de itens produzidos");
        Console.WriteLine("9 - Sair");
        producoes = int.Parse(Console.ReadLine());
        switch(producoes)
        {
            case 1:
                farmacia.IncluirProduce();
                break;
            case 2:
                farmacia.IncluirProduceItem();
                break;
            case 3:
              
                farmacia.LocalizarProduce();
                break;
            case 4:
                farmacia.LocalizarProduceItem();
                break;
            case 5:
                farmacia.AlterarProduce();
                break;
            case 6:
                farmacia.AlterarProduceItem();
                break;
            case 7:
                Console.WriteLine("Imprimindo lista de produções");
                farmacia.ImprimirListaProduces();
                break;
            case 8:
                Console.WriteLine("Imprimindo lista de itens produzidos");
                farmacia.ImprimirListaProduceItems();
                break;
            case 9:
                Produce.GravarProduce(farmacia.ListaProduces, Path.Combine(diretorio, pathProduce));
                ProduceItem.GravarProduceItem(farmacia.ListaProducesItems, Path.Combine(diretorio, pathProduceItem));
                Console.WriteLine("Saindo");
                break;
            default:
                Console.WriteLine("Opção Inválida");
                Console.ReadKey();
                break;
        }
    } while (producoes != 9);
}
void Relatorios()
{
    string menuRelatorio;
    do
    {

        Console.Clear();
        Console.WriteLine("---- MENU DE RELATÓRIOS ----");
        Console.WriteLine("1 - Vendas Por Período");
        Console.WriteLine("2 - Medicamentos Mais Vendidos");
        Console.WriteLine("3 - Compras Por Fornecedor");
        Console.WriteLine("0 - Voltar");
        menuRelatorio = Console.ReadLine()!;

        switch (menuRelatorio)
        {
            case "1":
                farmacia.RelatorioVendasPorPeriodo();
                break;
            case "2":
                farmacia.RelatorioMedicamentosMaisVendidos();
                break;
            case "3":
                farmacia.RelatorioCompraPorFornecedor();
                break;
            case "0":
                Console.WriteLine("Voltando...");
                break;
            default:
                Console.WriteLine("Opção inválida!");
                break;
        }
    } while (menuRelatorio != "0");


}

do
{

    Console.Clear();
    Console.WriteLine("---- MENU PRINCIPAL ----");
    Console.WriteLine("1 - Cadastros básicos");
    Console.WriteLine("2 - Vendas de medicamentos");
    Console.WriteLine("3 - Compras de princípios ativos");
    Console.WriteLine("4 - Manipulação de medicamentos");
    Console.WriteLine("5 - Relatórios");
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
        case 5:
            Relatorios();
            break;
        case 0:
            Console.WriteLine("Saindo");
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }
} while (menuprincipal != 0);