using ProjetoGrupo1;
Farmacia farmacia = new Farmacia();

string directoryPath = @"C:\SneezePharma\ProduceDept\"; 

List<Produce> producoes = new List<Produce>();

void CarregarDoArquivoProduce()
{
    string filePath = "Produce.data";
    var fullPath = Path.Combine(directoryPath, filePath);
    try
    {
        if (!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);

        if (!File.Exists(fullPath))
            return;

        var temp = new List<Produce>();
        using (var sr = new StreamReader(fullPath))
        {
            while (!sr.EndOfStream)
            {
                string content = sr.ReadLine()!;
                int id = int.Parse(content.Substring(0, 5));
                DateOnly data = DateOnly.Parse(content.Substring(5, 10)); 
                double idMedicamento = double.Parse(content.Substring(15, 13).Trim());
                int quantidade = int.Parse(content.Substring(28, 3));

                temp.Add(new Produce(id, data, idMedicamento, quantidade));
            }
        }
        farmacia.PopularListaProduces(temp);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        Console.WriteLine(e.StackTrace);
    }
}

void CarregarDoArquivoProduceItem()
{
    string filePath = "ProduceItem.data";
    var fullPath = Path.Combine(directoryPath, filePath);
    try
    {
        if (!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);

        if (!File.Exists(fullPath))
            return;

        var temp = new List<ProduceItem>();
        using (var sr = new StreamReader(fullPath))
        {
            while (!sr.EndOfStream)
            {
                string content = sr.ReadLine()!;
                int idProduceItem = int.Parse(content.Substring(0, 5));
                int idProducao = int.Parse(content.Substring(5, 5));
                string idPrincipio =content.Substring(10, 6);
                int quantidade = int.Parse(content.Substring(16, 4));

                temp.Add(new ProduceItem(idProduceItem, idProducao, idPrincipio, quantidade));
            }
        }
        farmacia.PopularListaProduceItem(temp);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        Console.WriteLine(e.StackTrace);
    }
}

void SalvarNoArquivoProduce()
{
    string filePath = "Produce.data";
    var fullPath = Path.Combine(directoryPath, filePath);
    StreamWriter sw = new StreamWriter(fullPath);
    List<Produce> produces = farmacia.RetornoListaProduces();

    foreach (Produce produce in produces)
    {
        sw.WriteLine(produce.ToFile());
    }
    
    sw.Close();
}
void SalvarNoArquivoProduceItem()
{
    string filePath = "ProduceItem.data";
    var fullPath = Path.Combine(directoryPath, filePath);
    StreamWriter sw = new StreamWriter(fullPath);
    List<ProduceItem> producesItems = farmacia.RetornoListaProduceItem();

    foreach (var produceItem in producesItems)
    {
        sw.WriteLine(produceItem.ToFile());
    }

    sw.Close();
}

void MenuProduce()
{

    string option;
    do
    {
        Console.Clear();
        Console.WriteLine("1 - Cadastrar Produção");
        Console.WriteLine("2 - Exibir Produções");
        Console.WriteLine("3 - Atualizar Produção");
        Console.WriteLine("4 - Buscar Produção");
        Console.WriteLine("0 - Sair");
        option = Console.ReadLine()!;

        switch (option)
        {
            case "1":
                Console.Clear();
                farmacia.IncluirProduce();
                break;
            case "2":
                Console.Clear();
                farmacia.ImprimirListaProduces();
                break;
            case "3":
                Console.Clear();
                farmacia.AlterarProduce();
                break;
            case "0":
                Console.WriteLine("Saindo...");
                break;
            default:
                Console.WriteLine("Escolha uma opção válida");
                break;
        }

    } while (option != "0");

}
void MenuProducesItems()
{
    string option;
    do
    {
        Console.Clear();
        Console.WriteLine("1 - Cadastrar Item da Produção");
        Console.WriteLine("2 - Exibir Itens da Produção");
        Console.WriteLine("3 - Atualizar item da Produção");
        Console.WriteLine("4 - Buscar item da Produção");
        Console.WriteLine("0 - Voltar");
        option = Console.ReadLine()!;

        switch (option)
        {
            case "1":
                Console.Clear();
                farmacia.IncluirProduceItem();
                break;
            case "2":
                Console.Clear();
                farmacia.ImprimirListaProduceItem();
                break;
            case "3":
                Console.Clear();
                farmacia.AlterarProduceItem();
                break;
            case "0":
                Console.WriteLine("Voltar...");
                break;
            default:
                Console.WriteLine("Escolha uma opção válida");
                break;
        }

    } while (option != "0");
}


string option;
CarregarDoArquivoProduce();
CarregarDoArquivoProduceItem();
do
{
    Console.Clear();
    Console.WriteLine("1 - Menu Produces");
    Console.WriteLine("2 - Menu ProducesItems");
    Console.WriteLine("0 - Sair");
    option = Console.ReadLine()!;

    switch (option)
    {
        case "1":
            Console.Clear();
            MenuProduce();
            break;
        case "2":
            Console.Clear();
            MenuProducesItems();
            break;
        case "0":
            Console.WriteLine("Saindo...");
            break;
        default:
            Console.WriteLine("Escolha uma opção válida");
            break;
    }

} while (option != "0");

SalvarNoArquivoProduce();
SalvarNoArquivoProduceItem();


//------------------------------------------------------------------------------------------------------
//FELIPE
string CarregarArquivo1()
{
    string directory = @"C:\SneezePharma\PurchaseDept\";
    string file1 = "Purchases.data";
    if (!Directory.Exists(directory))
    {
        Directory.CreateDirectory(directory);
    }
    if (!File.Exists(Path.Combine(directory, file1)))
    {
        File.Create(Path.Combine(directory, file1));
    }
    return Path.Combine(directory, file1);
}
string CarregarArquivo2()
{
    string directory = @"C:\SneezePharma\PurchaseDept\";
    string file2 = "PurchaseItems.data";
    if (!Directory.Exists(directory))
    {
        Directory.CreateDirectory(directory);
    }
    if (!File.Exists(Path.Combine(directory, file2)))
    {
        File.Create(Path.Combine(directory, file2));
    }
    return Path.Combine(directory, file2);
}

List<Purchases> LerArquivo1()
{
    var fullPath = CarregarArquivo1();

    StreamReader purchaseSR = new StreamReader(fullPath);

    using (purchaseSR)
    {
        if (purchaseSR.ReadToEnd() is "")
        {
            return new List<Purchases>();
        }
        else
        {
            List<Purchases> purchases = new List<Purchases>();

            while(purchaseSR.ReadLine() is not null)
            {
                string line = purchaseSR.ReadLine();
                var id = line.Substring(0, 5);
                var date = line.Substring(5, 10);
                var suplierCNPJ = line.Substring(14, 14);
                var TotalValue = line.Substring(29, 8);
                Purchases purchase = new Purchases(int.Parse(id), 
                    DateOnly.Parse(date), /*suplierCNPJ,*/
                    double.Parse(TotalValue));
                purchases.Add(purchase);
            }
            purchaseSR.Close();
            return purchases;
        }
    }
}
List<PurchaseItem> LerArquivo2()
{
    var fullPath = CarregarArquivo2();

    StreamReader purchaseItensSR = new StreamReader(fullPath);

    using (purchaseItensSR)
    {
        if (purchaseItensSR.ReadToEnd() is "")
        {
            return new List<PurchaseItem>();
        }
        else
        {
            List<PurchaseItem> purchaseItens = new List<PurchaseItem>();

            while(purchaseItensSR.ReadLine() is not null)
            {
                string line = purchaseItensSR.ReadLine();
                var idCompra = line.Substring(0, 5);
                var ingredient = line.Substring(5, 6);
                var quantity = line.Substring(15, 14);
                var TotalItem = line.Substring(29, 8);
                PurchaseItem purchaseItem = new PurchaseItem(int.Parse(idCompra), 
                    int.Parse(ingredient), int.Parse(quantity),
                    double.Parse(TotalItem));
                purchaseItens.Add(purchaseItem);
            }
            purchaseItensSR.Close();
            return purchaseItens;
        }
    }
}

void GravarArquivo1(List<Purchases> purchases)
{
    var fullPath = CarregarArquivo1();
    StreamWriter purchaseSW = new StreamWriter(fullPath);
    using (purchaseSW)
    {
        foreach (Purchases purchase in purchases)
        {
            purchaseSW.WriteLine(purchase.ToFile());
        }
        purchaseSW.Close();
    }
}

void GravarArquivo2(List<PurchaseItem> purchaseItems)
{
    var fullPath = CarregarArquivo2();
    StreamWriter purchaseItemSW = new StreamWriter(fullPath);
    using (purchaseItemSW)
    {
        foreach (PurchaseItem purchaseItem in purchaseItems)
        {
            purchaseItemSW.WriteLine(purchaseItem.ToFile());
        }
        purchaseItemSW.Close();
    }
}

