using System;
using System.Collections.Generic;

using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using System.Security.Cryptography.X509Certificates;

using System.Threading.Tasks;

namespace ProjetoGrupo1
{
    public class Farmacia
    {
        public List<Ingridient> ListaIngridients = new List<Ingridient>();

        //método para verificar se já existe algum ingrediente com o mesmo id
        public bool BuscarIngridientId(string id)
        {
            return ListaIngridients.Any(aux => aux.Id == id);// true - existe | false - não existe
        }


        //Retorna um ingrediente novo para ser inserido na lista
        public Ingridient IncluirIngredient()
        {
            int auxId = 0, auxNome = 0;
            string nome, id;
            Console.WriteLine("INGREDIENTE:");

            //vai ficar no laço de repetição até digitar um Id válido
            do
            {
                Console.WriteLine("Qual o Id (Lembrete do formato obrigatório: AI + 4 dígitos, exemplo: AI0000)?");
                id = Console.ReadLine();
                if (id.Length == 6)
                {
                    string sufixo = id.Substring(0, 2);
                    string prefixo = id.Substring(2);
                    if (BuscarIngridientId(id))
                        Console.WriteLine("Erro! Esse Id já é cadastrado!");
                    else if ((!sufixo.Equals("AI", StringComparison.OrdinalIgnoreCase)) || (!prefixo.All(c => char.IsDigit(c))))
                        Console.WriteLine("Erro! O formato do Id está incorreto!\nEle precisa ser composto por AI + 4 dígitos, exemplo: AI0000");
                    else
                        auxId = 1;
                }
                else
                {
                    Console.WriteLine("Erro! O Id que digitou está no formato errado, contendo mais que 6 caracteres");
                }
            } while (auxId == 0);

            do
            {
                Console.WriteLine("Qual o nome do ingrediente (Lembrete do formato obrigatório: até 20 caracteres, e apenas alfanuméricos)?");
                nome = Console.ReadLine();
                if (nome.Length <= 20)
                {
                    if (!Regex.IsMatch(nome, @"^[a-zA-Z0-9]+$"))
                        Console.WriteLine("O nome deve conter apenas caracteres alfanuméricos!");
                    else
                        auxNome = 1;
                }
                else
                {
                    Console.WriteLine("O nome pode ter ATÉ 20 caracteres");
                }
            } while (auxNome == 0);

            //Data UltimaCompra será colocada apenas quando for realizado uma compra
            //DataCadstro será atribuída no próprio construtor com a data atual
            //Situação será atribuída no prórpio construtor como Ativa

            return new Ingridient(id, nome);
        }

        //Mostra uma mensagem com as informações do ingrediente, caso não ache o Id mostra uma mensagem que não achou
        public void LocalizarIngridient(string id)
        {
            foreach (var ing in ListaIngridients)
            {
                if (ing.Id == id)
                {
                    Console.WriteLine("Ingrediente localizado:\n");
                    Console.WriteLine(ing.ToString());
                }
                else
                    Console.WriteLine("Ingrediente não localizado!");
            }
        }

        //Altera a situação do ingrediente de Ativo para Inativo
        public void AlterarIngridient(string id)
        {
            foreach (var ing in ListaIngridients)
            {
                if (ing.Id == id)
                {
                    if (ing.Situacao == 'I')
                    {
                        Console.WriteLine("Situação do ingrediente alterada com sucesso! De inativo para ativo!");
                        ing.Situacao = 'A';
                    }
                    else if (ing.Situacao == 'A')
                    {
                        Console.WriteLine("Situação do ingrediente alterada com sucesso! De ativo para inativo!");
                        ing.Situacao = 'I';
                    }
                    else
                        Console.WriteLine("Ingrediente não localizado!");
                }
            }
        }

        //É chamada quando há uma nova compra, alterando a data da última compra
        public void AlterarIngridientUltimaCompra(DateOnly ultimacompra, string id)
        {
            foreach (var ing in ListaIngridients)
            {
                if (ing.Id == id)
                {
                    ing.UltimaCompra = ultimacompra;
                }
            }
        }

        //Imprime a lista de ingredientes
        public void ImprimirIngridient()
        {
            foreach (var ing in ListaIngridients)
            {
                Console.WriteLine(ing.ToString());
            }
        }


        //-----------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------


        public List<Medicine> ListaMedicines = new List<Medicine>();


        public bool VerificacaoCDB(string cdb)
        {
            char[] vetoraux = cdb.ToCharArray();
            int somaImpar = 0, somaPar = 0;

            for (int i = 1; i < 13; i++)
            {
                if (i % 2 != 0)
                    somaImpar++;
                else
                    somaPar++;
            }

            int somaTotal = somaImpar + somaPar * 3;
            int verificador = 10 - (somaTotal % 10);
            return verificador == vetoraux[12];
        }
        public Medicine IncluirMedicine()
        {
            string nome, cdb;
            char categoria = ' ';
            int opCategoria;
            int auxNome = 0, auxVenda = 0, auxCategoria = 1, auxCdb = 0;
            decimal valorVenda;
            Console.WriteLine("MEDICAMENTO");

            do
            {
                Console.WriteLine("Qual o código de barras?");
                cdb = Console.ReadLine();
                if (cdb.Length != 13)
                    Console.WriteLine("Código de barras com tamanho diferente de 13 caracteres!");
                else
                {
                    if (VerificacaoCDB(cdb))
                        auxCdb = 1;
                    else
                        Console.WriteLine("Código de barras inválido!");
                }
            } while (auxCdb == 0);

            do
            {
                Console.WriteLine("Qual o nome do medicamento (Lembrete do formato obrigatório: até 40 caracteres, e apenas alfanuméricos)?");
                nome = Console.ReadLine();
                if (nome.Length <= 40)
                {
                    if (!Regex.IsMatch(nome, @"^[a-zA-Z0-9]+$"))
                        Console.WriteLine("O nome deve conter apenas caracteres alfanuméricos!");
                    else
                        auxNome = 1;
                }
                else
                {
                    Console.WriteLine("O nome pode ter ATÉ 40 caracteres");
                }
            } while (auxNome == 0);

            do
            {
                Console.WriteLine("Qual a categoria do medicamento?\n1 - Analgésico\n2 - Antibiótico\n3 - Anti-inflamatório\n4 - Vitamina");
                opCategoria = int.Parse(Console.ReadLine());
                switch (opCategoria)
                {
                    case 1:
                        categoria = 'A';
                        break;
                    case 2:
                        categoria = 'B';
                        break;
                    case 3:
                        categoria = 'I';
                        break;
                    case 4:
                        categoria = 'V';
                        break;
                    default:
                        Console.WriteLine("Categoria inválida!");
                        auxCategoria = 0;
                        break;
                }
            } while (auxCategoria == 0);

            do
            {
                Console.WriteLine("Qual o valor da venda do medicamento?");
                valorVenda = decimal.Parse(Console.ReadLine());
                if (valorVenda > 0 && valorVenda < 10000)
                    auxVenda = 1;
                else
                    Console.WriteLine("Valor inválido! Deve ser > 0 e < 10.000");
            } while (auxVenda == 0);

            return new Medicine(cdb, nome, categoria, valorVenda);
        }


        public decimal VerificacaoValor()
        {
            Console.WriteLine("Qual o novo valor da venda do medicamento?");
            decimal valorVenda = decimal.Parse(Console.ReadLine());
            if (valorVenda > 0 && valorVenda < 10000)
                return valorVenda;
            else
            {
                Console.WriteLine("Valor inválido! Deve ser > 0 e < 10.000");
                return 0;
            }
        }
        public void AlterarMedicine(string cdb)
        {
            decimal resp;
            Console.WriteLine("O que deseja alterar?\n1 - Valor da Venda\n2 - Situação do medicamento\n3 - As duas opções");
            int op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    do
                    {
                        decimal = VerificacaoValor();
                    } while (!resp);
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }

        }
    }

    
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