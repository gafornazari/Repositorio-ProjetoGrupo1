using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGrupo1
{
    internal class Farmacia
    {
        List<Purchases> ListaPurchases { get; set; } = new List<Purchases>();
        List<PurchaseItem> ListaPurchaseItens { get; set; } = new List<PurchaseItem>();

        public void IncluirPurchases()
        {
            Console.WriteLine("Digite o Id da compra: ");
            var id = int.Parse(Console.ReadLine());
            DateOnly data = DateOnly.FromDateTime(DateTime.Now);
            Console.WriteLine(data.ToString("dd/MM/yyyy"));
            data = DateOnly.Parse(Console.ReadLine());
            //Console.WriteLine("Digite o CNPJ do fornecedor: ");
            //var fornecedor = Console.ReadLine();
            //suppliers.CNPJ = fornecedor;
            //Console.WriteLine("Digite o Id do principio ativo: ");
            //var ingrediente = Console.ReadLine();
            //ingredient.Id = ingrediente;
            Console.WriteLine("Digite a quantidade em gramas do item: ");
            var quantidade = int.Parse(Console.ReadLine());
            if (quantidade < 0 || quantidade > 10000)
            {
                Console.WriteLine("Quantidade deve estar entre 0 e 10.000");
            }
            Console.WriteLine("Digite o valor unitário do item: ");
            var valorUnitario = double.Parse(Console.ReadLine());
            if (valorUnitario < 0 || valorUnitario > 1000)
            {
                Console.WriteLine("Valor unitário deve estar entre 0 e 1.000.");
            }
            var totalItem = quantidade * valorUnitario;
            Console.WriteLine($"Total do item: {totalItem}");
            double valorTotal = 0;
            valorTotal += totalItem;
            Console.WriteLine($"{valorTotal}");
            if (valorTotal < 0 || valorTotal > 100000)
            {
                Console.WriteLine("Valor total deve estar entre 0 e 100.000.");
            }

            this.ListaPurchases.Add(new Purchases(id, data, valorTotal));
            this.ListaPurchaseItens.Add(new PurchaseItem(id, quantidade, valorUnitario, totalItem));
        }

        public void LocalizarPurchases()
        {
            Console.WriteLine("Digite o Id da compra que deseja localizar: ");
            var id = int.Parse(Console.ReadLine());
            var purchase = this.ListaPurchases.Find(p => p.Id == id);
            if (purchase != null)
            {
                Console.WriteLine(purchase);
            }
            else
            {
                Console.WriteLine("Compra não encontrada.");
            }
        }
        public void LocalizarPurchaseItem()
        {
            Console.WriteLine("Digite o Id da compra que deseja localizar o item: ");
            var id = int.Parse(Console.ReadLine());
            var purchaseItem = this.ListaPurchaseItens.Find(pi => pi.IdCompra == id);
            if (purchaseItem != null)
            {
                Console.WriteLine(purchaseItem);
            }
            else
            {
                Console.WriteLine("Item da compra não encontrado.");
            }
        }
        public void AlterarPurchases()
        {
            Console.WriteLine("Digite o Id da compra que deseja alterar: ");
            var id = int.Parse(Console.ReadLine());
            var purchase = this.ListaPurchases.Find(p => p.Id == id);
            if (purchase != null)
            {
                DateOnly data = DateOnly.FromDateTime(DateTime.Now);
                Console.WriteLine(data.ToString("dd/MM/yyyy"));
                data = DateOnly.Parse(Console.ReadLine());
                double valorTotal = 0;
                Console.WriteLine("Digite o novo valor total da compra: ");
                valorTotal = double.Parse(Console.ReadLine());
                Console.WriteLine($"Valor Total atualizado: {valorTotal}");
                // Atualiza a compra na lista
                this.ListaPurchases.Remove(purchase);
                this.ListaPurchases.Add(new Purchases(id, data, valorTotal));
            }
            else
            {
                Console.WriteLine("Compra não encontrada.");
            }
        }
        public void AlterarPurchaseItem()
        {
            Console.WriteLine("Digite o Id da compra que deseja alterar o item: ");
            var id = int.Parse(Console.ReadLine());
            var purchaseItem = this.ListaPurchaseItens.Find(pi => pi.IdCompra == id);
            if (purchaseItem != null)
            {
                //ingrediente
                //Console.WriteLine("Digite o novo ingrediente do item: ");
                //var ingrediente = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite a nova quantidade em gramas do item: ");
                var quantidade = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite o novo valor unitário do item: ");
                var valorUnitario = double.Parse(Console.ReadLine());
                var totalItem = quantidade * valorUnitario;
                Console.WriteLine($"Total do item atualizado: {totalItem}");
                // Atualiza o item na lista
                this.ListaPurchaseItens.Remove(purchaseItem);
                this.ListaPurchaseItens.Add(new PurchaseItem(id 
                    /*purchaseItem.Ingrediente*/, quantidade, valorUnitario, totalItem));
            }
            else
            {
                Console.WriteLine("Item da compra não encontrado.");
            }
        }
        public void ImprimirPurchases()
        {
            foreach (var purchase in this.ListaPurchases)
            {
                Console.WriteLine(purchase);
            }
        }
        public void ImprimirPurchaseItens()
        {
            foreach (var purchaseItem in this.ListaPurchaseItens)
            {
                Console.WriteLine(purchaseItem);
            }
        }
    }
}
