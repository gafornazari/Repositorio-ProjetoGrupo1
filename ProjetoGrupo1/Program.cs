
using ProjetoGrupo1;
Farmacia farmacia = new Farmacia();

string directoryPath = @"\Users\Lucas\source\repos\Repositorio-ProjetoGrupo1\Arquivos"; 

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

