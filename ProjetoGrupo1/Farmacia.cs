using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProjetoGrupo1;


namespace ProjetoGrupo1
{
    public class Farmacia
    {

        //-----------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        //lucas
        public List<Produce> ListaProduces { get; set; }
        public List<ProduceItem> ListaProducesItems { get; set; }

        public List<Ingredient> ListaIngredients { get; set; }
        public List<Medicine> ListaMedicines { get; set; }
        public List<Purchases> ListaPurchases { get; set; } 
        public List<PurchaseItem> ListaPurchaseItens { get; set; }

        public List<Customer> ListaCustomers { get; set; }
        public List<Supplies> ListaSupplies { get; set; }
        public List<Customer> ListaRestrictedCustomers { get; set; }
        public List<Supplies> ListaRestrictedSupplies { get; set; }
        public List<Sales> ListaSales { get; set; }
        public List<SalesItems> ListaSalesItems {  get; set; }

        public Farmacia()
        {
            this.ListaProduces = new List<Produce>();
            this.ListaProducesItems = new List<ProduceItem>();
            this.ListaIngredients = new List<Ingredient>();
            this.ListaMedicines = new List<Medicine>();
            this.ListaPurchases = new List<Purchases>();
            this.ListaPurchaseItens = new List<PurchaseItem>();
            this.ListaCustomers = new List<Customer>();
            this.ListaSupplies = new List<Supplies>();
            this.ListaRestrictedCustomers = new List<Customer>();
            this.ListaRestrictedSupplies = new List<Supplies>();
            this.ListaSales = new List<Sales>();
            this.ListaSalesItems = new List<SalesItems>();

        }

        public void PopularListaProduces(List<Produce> produces)
        {
            this.ListaProduces = produces;
        }
        public List<Produce> RetornoListaProduces()
        {
            return this.ListaProduces.ToList();
        }
        public void ImprimirListaProduces()
        {

            Console.Clear();
            foreach (var produce in this.ListaProduces)
            {
                Console.WriteLine("_______________________");
                Console.WriteLine(produce);
                Console.WriteLine("_______________________");
            }
            Console.ReadKey();
        }
        public Produce LocalizarProduce(double idProduce)
        {
            foreach (Produce produce in ListaProduces)
            {
                if (produce.Id == idProduce)
                {
                    return produce;
                }
            }

            return null;
        }
        public bool ExisteProduce(int idProduce)
        {
            foreach (Produce produce in ListaProduces)
            {
                if (produce.Id == idProduce)
                {
                    return true;
                }
            }
            return false;
        }

        public void IncluirProduce()
        {

            Console.WriteLine("Digite o id da Produção(5 digitos): ");
            int id = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Digite o Id do Medicamento: ");
            double idMedicamento = Convert.ToDouble(Console.ReadLine()!);
            Medicine medicine = LocalizarMedicine();
            if (medicine == null)
            {
                Console.WriteLine("Medicamento não encontrado!");
            }
            else if (medicine.Situacao == 'I')
            {

                Console.WriteLine("Medicamento não está ativo!");

            }
            else
            {
                Console.WriteLine("Digite a quantidade: ");
                int quantidade = int.Parse(Console.ReadLine()!);

                while (quantidade < 0 || quantidade > 999)
                {
                    Console.WriteLine("Digite uma quantidade entre 1 e 999");
                    quantidade = int.Parse(Console.ReadLine()!);
                }


                Produce produce = new Produce(id, idMedicamento, quantidade);
                this.ListaProduces.Add(produce);

                Console.Clear();
                Console.WriteLine("Produce criada com sucesso!");
                Console.ReadKey();

            }


        }


        public void AlterarProduce()
        {

            Console.WriteLine("Digite o id da produção a ser atualizada: ");
            double id = Convert.ToDouble(Console.ReadLine()!);
            var produce = LocalizarProduce(id);
            if (produce == null)
            {
                Console.WriteLine("Produção não encontrada");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Digite o id do novo medicamento: ");
                int idMedicamento = int.Parse(Console.ReadLine()!);
                Console.WriteLine("Digite a nova quantidade: ");
                int quantidade = int.Parse(Console.ReadLine()!);

                produce.SetQuantidade(quantidade);
                produce.SetMedicamento(idMedicamento);

                Console.Clear();
                Console.WriteLine("Produce atualizada com sucesso!");
                Console.ReadKey();
            }

        }


        public void IncluirProduceItem()
        {
            Console.WriteLine("Digite o id: ");
            int id = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Digite o id da produção: ");
            int idProduce = int.Parse(Console.ReadLine()!);
            var produce = LocalizarProduce(idProduce);
            if (produce == null)
            {
                Console.WriteLine("Produção não encontrada");
            }
            else
            {
                Console.WriteLine("Digite o id do Princípio Ativo");
                string idPrincipio = Console.ReadLine()!;
                Ingredient Ingredient = null;
                foreach (var ing in ListaIngredients)
                {
                    if (ing.Id == idPrincipio)
                    {
                        Ingredient = ing;
                        break;
                    }
                }
                if (Ingredient != null && Ingredient.Situacao == 'A')
                {
                    Console.WriteLine("Digite a quantidade do Princípio Ativo: ");
                    int quantidade = int.Parse(Console.ReadLine()!);
                    this.ListaProducesItems.Add(new ProduceItem(id, idProduce, idPrincipio, quantidade));
                    Console.Clear();
                    Console.WriteLine("Item de produção Incluído com sucesso!");
                    Console.ReadKey();
                }
                else
                {
                    if (Ingredient == null)
                    {
                        Console.WriteLine("Princípio não encontrado");
                    }
                    else
                    {
                        Console.WriteLine("Princípio não ativo");
                    }
                }
            }
        }

        public ProduceItem LocalizarProduceItem(int id)
        {
            foreach (var produceItem in this.ListaProducesItems)
            {
                if (produceItem.IdProduceItem == id)
                {
                    return produceItem;
                }
            }
            return null;
        }
        public void AlterarProduceItem()
        {
            Console.WriteLine("Digite o id do Item de Produção: ");
            int id = int.Parse(Console.ReadLine()!);
            var produceItem = LocalizarProduceItem(id);
            if (produceItem != null)
            {
                Console.WriteLine("Digite o id do novo Princípio Ativo");
                string idPrincipio = Console.ReadLine()!;
                Ingredient Ingredient = null;
                foreach (var ing in ListaIngredients)
                {
                    if (ing.Id == idPrincipio)
                    {
                        Ingredient = ing;
                        break;
                    }
                }
                if (Ingredient != null && Ingredient.Situacao == 'A')
                {
                    Console.WriteLine("Digite a quantidade do novo Princípio Ativo: ");
                    int quantidade = int.Parse(Console.ReadLine()!);
                    produceItem.SetIdPrincipio(idPrincipio);
                    produceItem.SetQuantidadePrincipio(quantidade);
                    Console.Clear();
                    Console.WriteLine("Item de produção Alterado com sucesso!");
                    Console.ReadKey();
                }
                else
                {
                    if (Ingredient == null)
                    {
                        Console.WriteLine("Princípio não encontrado");
                    }
                    else
                    {
                        Console.WriteLine("Princípio não ativo");
                    }
                }
            }
            else
            {
                Console.WriteLine("Item de produção não encontrado");
            }
        }



        public void ImprimirListaProduceItem()
        {
            Console.Clear();
            foreach (var produce in this.ListaProduces)
            {
                Console.WriteLine("_______________________");
                Console.WriteLine(produce);
                Console.WriteLine("_______________________");
            }
            Console.ReadKey();
        }

        public void PopularListaProduceItem(List<ProduceItem> producesItems)
        {
            this.ListaProducesItems = producesItems;
        }
        public List<ProduceItem> RetornoListaProduceItem()
        {
            return this.ListaProducesItems.ToList();
        }


        //-----------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------
        //giovanna


        

        //método para verificar se já existe algum ingrediente com o mesmo id
        public bool BuscarIngridientId(string id)
        {
            return ListaIngredients.Any(aux => aux.Id == id);// true - existe | false - não existe
        }


        //Retorna um ingrediente novo para ser inserido na lista
        public Ingredient IncluirIngredient()
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

            return new Ingredient(id, nome);
        }

        //Mostra uma mensagem com as informações do ingrediente, caso não ache o Id mostra uma mensagem que não achou
        public void LocalizarIngridient(string id)
        {
            foreach (var ing in ListaIngredients)
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
            foreach (var ing in ListaIngredients)
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
            foreach (var ing in ListaIngredients)
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
            foreach (var ing in ListaIngredients)
            {
                Console.WriteLine(ing.ToString());
            }
        }



       

        public Medicine LocalizarMedicine()
        {
            return null;
        }
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
                        decimal valorVenda = VerificacaoValor();
                    } while (op != 0);
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }

        }
        //-----------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------
        //Felipe


        

        public void IncluirPurchases()
        {
            Console.WriteLine("Digite o Id da compra: ");
            var id = int.Parse(Console.ReadLine());
            DateOnly data = DateOnly.FromDateTime(DateTime.Now);
            Console.WriteLine(data.ToString("dd/MM/yyyy"));
            data = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("Digite o CNPJ do fornecedor: ");
            var fornecedor = Console.ReadLine();
            Supplies suppliers = new Supplies();
            suppliers.SetCNPJ(fornecedor);
            Console.WriteLine("Digite o Id do principio ativo: ");
            var ingrediente = Console.ReadLine();
            Ingredient ingridient = new Ingredient();
            ingridient.Id = ingrediente;
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
            this.ListaPurchaseItens.Add(new PurchaseItem(id, ingridient, quantidade, valorUnitario, totalItem));
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
                Console.WriteLine("Digite o novo ingrediente do item: ");
                var ingrediente = Console.ReadLine();
                Ingredient ingredient = new Ingredient();
                ingredient.Id = ingrediente;
                Console.WriteLine("Digite a nova quantidade em gramas do item: ");
                var quantidade = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite o novo valor unitário do item: ");
                var valorUnitario = double.Parse(Console.ReadLine());
                var totalItem = quantidade * valorUnitario;
                Console.WriteLine($"Total do item atualizado: {totalItem}");
                // Atualiza o item na lista
                this.ListaPurchaseItens.Remove(purchaseItem);
                this.ListaPurchaseItens.Add(new PurchaseItem(id,
                    ingredient, quantidade, valorUnitario, totalItem));
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


        //---------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------
        //ANA

        

        //Métodos para os clientes/customers
        public string VerificarCpf(string cpf)
        {
            // Remove caracteres não numéricos
            cpf = cpf.Replace(".", "").Replace("-", "").Trim();

            // Verifica se tem 11 dígitos
            if (cpf.Length != 11)
                return "CPF inválido! (deve conter 11 dígitos)";

            // Verifica se todos os dígitos são iguais
            if (new string(cpf[0], 11) == cpf)
                return "CPF inválido! (números repetidos)";

            // Calcula o primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (cpf[i] - '0') * (10 - i);

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            // Calcula o segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (cpf[i] - '0') * (11 - i);

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            // Verifica se os dígitos calculados são iguais aos do CPF informado
            if (cpf[9] - '0' == digito1 && cpf[10] - '0' == digito2)
                return "CPF válido!";
            else
                return "CPF inválido!";
        }

        public void VerificarMaioridade(DateOnly dataNascimento)
        {
            DateTime dataAtual = DateTime.Now;
            int idade = dataAtual.Year - dataNascimento.Year;

            if (idade >= 18)

            {
                Console.WriteLine("Cadastro Concluído.");
            }


            else
                Console.WriteLine("Não é possível concluir o cadastro. Cliente menor de idade");

        }
        public void AdicionarCliente()
        {
            Console.Write("Informe CPF do cliente: ");
            string cpf = (Console.ReadLine()!);
            VerificarCpf(cpf);

            foreach (var cliente in ListaCustomers)
            {
                if (cliente.CPF == cpf)
                {
                    Console.WriteLine("Cliente já cadastrado.");
                }
            }

            Console.Write("Informe o nome do cliente: ");
            string nome = Console.ReadLine();

            Console.Write("Informe o telefone: DDD + Número");
            string telefone = Console.ReadLine();

            Console.Write("Informe a data da última compra: ");
            DateOnly ultimaCompra = DateOnly.Parse(Console.ReadLine());

            Console.Write("Informe a data do cadastro do cliente: ");
            DateOnly dataCadastro = DateOnly.Parse(Console.ReadLine());

            Console.WriteLine("Informa a situação do cliente: [I] para Inativo - [A] para Ativo");
            char situacao = char.Parse(Console.ReadLine());

            Console.Write("Informe a data de nascimento do cliente: ");
            DateOnly dataNascimento = DateOnly.Parse(Console.ReadLine());
            VerificarMaioridade(dataNascimento);

            ListaCustomers.Add(new Customer());
        }

        public Customer LocalizarCliente(string cpf)
        {
            return ListaCustomers.Find(c => c.CPF == cpf);
        }

        public void AlterarCliente()
        {
            Console.WriteLine("Qual o cpf do cliente? ");
            string cpf = Console.ReadLine()!;
            var cliente = LocalizarCliente(cpf);

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado");
            }
            else
            {
                Console.WriteLine("Qual informação deseja alterar? [1] Telefone, [2] Situação ");
                int opcao = int.Parse(Console.ReadLine());

                if (opcao == 1)
                {
                    Console.WriteLine("Digite o novo telefone: ");
                    string novoTelefone = Console.ReadLine();

                    cliente.SetTelefone(novoTelefone);
                    Console.WriteLine("Novo telefone cadastrado." + novoTelefone);

                }
                else if (opcao == 2)
                {
                    Console.WriteLine("Digite a nova situação: [I] para Inativo - [A] para Ativo");
                    char novaSituacao = char.Parse(Console.ReadLine());

                    cliente.SetSituacao(novaSituacao);
                    Console.WriteLine("Nova situação" + novaSituacao);
                }
                else
                {
                    Console.WriteLine("Opção inválida.");
                }

            }

        }
        public void ExibirClientes()
        {
            Console.WriteLine("LISTA DE CLIENTES");
            foreach (var cliente in ListaCustomers)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine(cliente + "\n");
                Console.WriteLine("-------------------------------------");
            }
        }

        //Métodos para os fornecedores/supplies
        public string VerificarCnpj(string cnpj)
        {
            // Verifica se tem 14 dígitos
            if (cnpj.Length != 14)
                return "CNPJ inválido! (deve conter 14 dígitos)";

            // Verifica se todos os dígitos são iguais (ex: 11111111111111)
            if (new string(cnpj[0], 14) == cnpj)
                return "CNPJ inválido! (números repetidos)";

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCnpj, digito;
            int soma, resto;

            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += (tempCnpj[i] - '0') * multiplicador1[i];

            resto = (soma % 11);
            resto = resto < 2 ? 0 : 11 - resto;
            digito = resto.ToString();

            tempCnpj += digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += (tempCnpj[i] - '0') * multiplicador2[i];

            resto = (soma % 11);
            resto = resto < 2 ? 0 : 11 - resto;
            digito += resto.ToString();

            // Verifica se os dois dígitos calculados são iguais aos informados
            if (cnpj.EndsWith(digito))
                return "CNPJ válido!";
            else
                return "CNPJ inválido!";

        }

        public void VerificarDataAbertura(DateOnly dataAbertura)
        {
            DateTime dataAtual = DateTime.Now;
            int anos = dataAtual.Year - dataAbertura.Year;

            if (anos >= 2)

            {
                Console.WriteLine("Cadastro Concluído.");
            }


            else
                Console.WriteLine("Não é possível concluir o cadastro. Empresa com menos de 2 anos.");

        }

        public void AdicionarFornecedor()
        {
            Console.Write("Informe CNPJ: ");
            string cnpj = (Console.ReadLine()!);
            VerificarCnpj(cnpj);

            foreach (var fornecedor in ListaSupplies)
            {
                if (fornecedor.GetCNPJ() == cnpj)
                {
                    Console.WriteLine("Empresa já cadastrada.");
                }
            }

            Console.Write("Informe a razão social da empresa: ");
            string razaoSocial = Console.ReadLine();

            Console.Write("Informe o país em que a empresa se encontra: ");
            string pais = Console.ReadLine();

            Console.Write("Informe a data da último fornecimento: ");
            DateOnly ultimoFornecimento = DateOnly.Parse(Console.ReadLine());

            Console.Write("Informe a data do cadastro da empresa: ");
            DateOnly dataCadastro = DateOnly.Parse(Console.ReadLine());

            Console.WriteLine("Informa a situação do cliente: [I] para Inativo - [A] para Ativo");
            char situacao = char.Parse(Console.ReadLine());

            Console.Write("Informe a data de fundação da empresa: ");
            DateOnly dataFundacao = DateOnly.Parse(Console.ReadLine());
            VerificarDataAbertura(dataFundacao);

            ListaSupplies.Add(new Supplies());
        }

        public Supplies LocalizarFornecedor(string cnpj)
        {
            return ListaSupplies.Find(s => s.GetCNPJ() == cnpj);

        }
        public void ListarFornecedores()
        {
            Console.WriteLine("LISTA DE FORNECEDORES");
            foreach (var fornecedor in ListaSupplies)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine(fornecedor + "\n");
                Console.WriteLine("-------------------------------------");
            }

        }

        public void AlterarFornecedores()
        {
            Console.WriteLine("Qual o cnpj da empresa? ");
            string cnpj = Console.ReadLine()!;
            var fornecedor = LocalizarFornecedor(cnpj);

            if (fornecedor == null)
            {
                Console.WriteLine("Fornecedor não encontrado");
            }
            else
            {
                Console.WriteLine("Qual informação deseja alterar? [1] Pais, [2] Situação ");
                int opcao = int.Parse(Console.ReadLine());

                if (opcao == 1)
                {
                    Console.WriteLine("Digite o novo país: ");
                    string novoPais = Console.ReadLine();

                    fornecedor.SetPais(novoPais);
                    Console.WriteLine("Novo país cadastrado." + novoPais);

                }
                else if (opcao == 2)
                {
                    Console.WriteLine("Digite a nova situação: [I] para Inativo - [A] para Ativo");
                    char novaSituacao = char.Parse(Console.ReadLine());

                    fornecedor.SetSituacao(novaSituacao);
                    Console.WriteLine("Nova situação" + novaSituacao);
                }
                else
                {
                    Console.WriteLine("Opção inválida.");
                }

            }

        }

        //Clientes Restritos

        public void AdicionarClientesRestritos()
        {
            Console.WriteLine("Qual o cpf do cliente que deseja cadastrar?");
            string cpf = Console.ReadLine()!;
            foreach (var cliente in ListaCustomers)
            {
                if (cliente.CPF == cpf)
                {
                    Console.WriteLine("Cliente adicionado a lista de Clientes Restritos.");
                    ListaRestrictedCustomers.Add(cliente);
                }
                else
                {
                    Console.WriteLine("O cliente não está cadastrado.");
                }
                Console.WriteLine(ListaRestrictedCustomers);
            }
        }

        public Customer LocalizarClientesRestritos(string cpf)
        {
            return ListaRestrictedCustomers.Find(c => c.CPF == cpf);
        }

        public void AlterarClientesRestritos()
        {
            Console.WriteLine("Qual o cpf do cliente? ");
            string cpf = Console.ReadLine()!;
            var cliente = LocalizarCliente(cpf);

            Console.WriteLine("Digite a nova situação: [I] para Inativo - [A] para Ativo");
            char novaSituacao = char.Parse(Console.ReadLine());

            cliente.SetSituacao(novaSituacao);
            Console.WriteLine("Nova situação" + novaSituacao);
        }

        public void ListarClientesRestritos()
        {
            Console.WriteLine("LISTA DE CLIENTES RESTRITOS");
            foreach (var cliente in ListaRestrictedCustomers)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine(cliente + "\n");
                Console.WriteLine("-------------------------------------");
            }
        }

        //Fornecedores Restritos
        public void AdicionarFornecedoresRestritos()
        {
            Console.WriteLine("Qual o cnpj da empresa que deseja cadastrar?");
            string cnpj = Console.ReadLine()!;
            foreach (var fornecedor in ListaSupplies)
            {
                if (fornecedor.GetCNPJ() == cnpj)
                {
                    Console.WriteLine("Empresa adicionada a lista de Empresas Restritas.");
                    ListaRestrictedSupplies.Add(fornecedor);
                }
                else
                {
                    Console.WriteLine("A empresa não está cadastrada.");
                }
            }
        }

        public Supplies LocalizarFornecedoresRestritos(string cnpj)
        {
            return ListaRestrictedSupplies.Find(s => s.GetCNPJ() == cnpj);
        }

        public void AlterarFornecedoresRestritos()
        {
            Console.WriteLine("Qual o cnpj da empresa? ");
            string cnpj = Console.ReadLine()!;
            var fornecedor = LocalizarFornecedor(cnpj);

            Console.WriteLine("Digite a nova situação: [I] para Inativo - [A] para Ativo");
            char novaSituacao = char.Parse(Console.ReadLine());

            fornecedor.SetSituacao(novaSituacao);
            Console.WriteLine("Nova situação" + novaSituacao);
        }

        public void ListarFornecedoresRestritos()
        {
            Console.WriteLine("LISTA DE FORNECEDORES RESTRITOS");
            foreach (var fornecedor in ListaRestrictedSupplies)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine(fornecedor + "\n");
                Console.WriteLine("-------------------------------------");
            }

        }

        //-----------------------------------------------------------------------
        //-----------------------------------------------------------------------
        //-----------------------------------------------------------------------
        //leandro

        





        public void IncluirSales()
        {
            Console.WriteLine("Digite o CPF do cliente: ");
            string cpf = Console.ReadLine();
            var customer = 0; //= LocalizarCustomer(cpf);

            if (customer == 0)
                Console.WriteLine("Cliente não cadastrado!");

            //else if (/*LocalizarClientesRestritos(cpf)*/)
            //{
            //    Console.WriteLine("Cliente restrito");
            //}
            else { }
        }
    public void LocalizarSales(int id)
    {
        foreach (var venda in ListaSales)
        {
            if (venda.Id == id)
            {
                Console.WriteLine("Venda encontrada!");
                Console.WriteLine(venda.ToString());
            }
            else
            {
                Console.WriteLine("Venda não encontrado!");
            }
        }
    }
        

    public void VerificarItem()
    {
        int auxid1 = 0;

        Console.WriteLine("Digite um número inteiro com 5 dígitos:");
        string entrada = Console.ReadLine();
        if (entrada.Length == 5 && entrada.All(char.IsDigit))
        {
            Console.WriteLine("Entrada válida: contém apenas números e tem 5 dígitos.");
            auxid1 = 1;
            int numero = int.Parse(entrada);
            Console.WriteLine(entrada);
        }
        else
        {
            Console.WriteLine("Entrada invalida! ");
            Console.WriteLine("O Id deve conter apenas 5 numeros inteiros!");
            Console.WriteLine("Tente novamente!");
        }

    }

    }
}
