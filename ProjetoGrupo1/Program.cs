using ProjetoGrupo1;
using System.Xml;

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
                var suplierCNPJ = line.Substring(15, 14);
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
                var TotalValue = line.Substring(29, 8);
                PurchaseItem purchaseItem = new PurchaseItem(int.Parse(idCompra), 
                    DateOnly.Parse(date), /*suplierCNPJ,*/
                    double.Parse(TotalValue));
                purchaseItens.Add(purchaseItem);
            }
            purchaseItensSR.Close();
            return purchaseItens;
        }
    }
}
