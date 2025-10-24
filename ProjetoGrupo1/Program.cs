using ProjetoGrupo1;
Farmacia farmacia = new Farmacia();

string directoryPath = @"C:\SneezePharma\";

List<Produce> producoes = new List<Produce>();

void CarregarDoArquivoProduce()
{
    string filePath = @"ProduceDept\Produce.data";
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
    string filePath = @"ProduceDept\ProduceItem.data";
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
                string idPrincipio = content.Substring(10, 6);
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
    string filePath = @"ProduceDept\Produce.data";
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
    string filePath = @"ProduceDept\ProduceItem.data";
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
void CarregarArquivo1()
{
    string filePath = @"PurchasesDept\Purchases.data";
    var fullPath = Path.Combine(directoryPath, filePath);
    try
    {
        if (!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);

        if (!File.Exists(fullPath))
            return;

        var temp = new List<Purchases>();
        Path.Combine(directoryPath, filePath);
        using (var sr = new StreamReader(fullPath))
        {
            string line = sr.ReadLine();
            int id = int.Parse(line.Substring(0, 5));
            DateOnly data = DateOnly.Parse(line.Substring(5, 10));
            Supplies suplier = new Supplies();
            string suplierCNPJ = line.Substring(15, 14);
            double totalValue = double.Parse(line.Substring(29, 10));

            temp.Add(new Purchases(id, data, suplierCNPJ, totalValue));
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        Console.WriteLine(e.StackTrace);
    }
}
void CarregarArquivo2()
{
    string filePath = @"PurchasesDept\PurchaseItems.data";
    var fullPath = Path.Combine(directoryPath, filePath);
    try
    {
        if (!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);

        if (!File.Exists(fullPath))
            return;

        var temp = new List<PurchaseItem>();
        Path.Combine(directoryPath, filePath);
        using (var sr = new StreamReader(fullPath))
        {
            string line = sr.ReadLine();
            int id = int.Parse(line.Substring(0, 5));
            Ingredient ingrediente = new Ingredient();
            string ingredienteId = line.Substring(5, 6);
            int quantidade = int.Parse(line.Substring(10, 14));
            double valorUnitario = double.Parse(line.Substring(24, 6));
            double totalItem = double.Parse(line.Substring(30, 10));

            temp.Add(new PurchaseItem(id, ingredienteId, quantidade,
                valorUnitario, totalItem));
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        Console.WriteLine(e.StackTrace);
    }
}

void GravarArquivo1(List<Purchases> purchases)
{
    string fullPath = @"C:\SneezePharma\PurchasesDept\Purchases.data";

    using (StreamWriter writer = new StreamWriter(fullPath))
    {
        foreach (var purchase in purchases)
        {
            writer.WriteLine(purchase.ToFile());
        }
        writer.Close();
    }
}

void GravarArquivo2(List<PurchaseItem> purchaseItems)
{
    string fullPath = @"C:\SneezePharma\PurchasesDept\PurchaseItems.data";

    using (StreamWriter writer = new StreamWriter(fullPath))
    {
        foreach (var purchase in purchaseItems)
        {
            writer.WriteLine(purchase.ToFile());
        }
        writer.Close();
    }
}

//Leandro ====================================================================

string CarregarArquivoSales()
{
    string file = @"SalesDept\Sales.data";
    if (!Directory.Exists(directoryPath))
    {
        Directory.CreateDirectory(directoryPath);
    }

    var path = Path.Combine(directoryPath, file);
    if (!File.Exists(path))
    {
        File.Create(path);
    }
    return path;
}

string CarregarArquivoSaleItems()
{
    string file1 = @"SalesDept\SaleItems.data";
    if (!Directory.Exists(directoryPath))
    {
        Directory.CreateDirectory(directoryPath);
    }

    var path1 = Path.Combine(directoryPath, file1);
    if (!File.Exists(path1))
    {
        File.Create(path1);
    }
    return path1;
}

List<Sales> LerArquivoSales()
{
    var fullPath = CarregarArquivoSales();

    StreamReader salesSR = new StreamReader(fullPath);

    using (salesSR)
    {
        List<Sales> sales = new List<Sales>();

        string line;

        while ((line = salesSR.ReadLine()) != null)
        {
            var id = line.Substring(0, 5);
            var date = line.Substring(5, 8);
            var cpf = line.Substring(13, 11);
            var TotalValue = line.Substring(24, 7);

            Sales sale = new Sales();
            sale.SetId(int.Parse(id));

            DateOnly data = DateOnly.ParseExact(date, "ddMMyyyy");
            sale.SetDataVenda(data);

            sale.SetCliente(cpf);

            sale.SetValorTotal(decimal.Parse(TotalValue));

            sales.Add(sale);
        }

        salesSR.Close();
        return sales;
    }
}

List<SalesItems> LerArquivosSaleItems()
{
    var fullPath1 = CarregarArquivoSaleItems();

    StreamReader saleItemsSR = new StreamReader(fullPath1);

    using (saleItemsSR)
    {
        List<SalesItems> saleItems = new List<SalesItems>();

        string line;

        while ((line = saleItemsSR.ReadLine()) != null)
        {
            var id = line.Substring(0, 5);
            var codigoDeBarras = line.Substring(5, 13);
            var quantidade = line.Substring(18, 3);
            var valorUnitario = line.Substring(21, 6);
            var totalItem = line.Substring(27, 7);

            SalesItems saleItems1 = new SalesItems();
            //saleItems1.SetIdVenda(int.Parse(id)); 

            // fazer o codigo de barras===========

            //sale.SetCliente(cpf);

            //sale.setValorTotal(decimal.Parse(TotalValue));

            //sales.Add(sale);
        }

        //salesSR.Close();
        return null /*sales*/;
    }
}
