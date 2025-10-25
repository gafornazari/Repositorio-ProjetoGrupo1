using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjetoGrupo1
{
    public class Farmacia
    {
        public List<Produce> ListaProduces { get; set; }
        public List<ProduceItem> ListaProducesItems { get; set; }

        public List<Ingredient> ListaIngredients { get; set; }
        public List<Medicine> ListaMedicines { get; set; }
        public List<Purchases> ListaPurchases { get; set; }
        public List<PurchaseItem> ListaPurchaseItems { get; set; }

        public List<Customer> ListaCustomers { get; set; }
        public List<Suppliers> ListaSupplies { get; set; }
        public List<Customer> ListaRestrictedCustomers { get; set; }
        public List<Suppliers> ListaRestrictedSupplies { get; set; }
        public List<Sales> ListaSales { get; set; }
        public List<SalesItems> ListaSalesItems { get; set; }

        public Farmacia()
        {
            this.ListaProduces = new List<Produce>();
            this.ListaProducesItems = new List<ProduceItem>();
            this.ListaIngredients = new List<Ingredient>();
            this.ListaMedicines = new List<Medicine>();
            this.ListaPurchases = new List<Purchases>();
            this.ListaPurchaseItems = new List<PurchaseItem>();
            this.ListaCustomers = new List<Customer>();
            this.ListaSupplies = new List<Suppliers>();
            this.ListaRestrictedCustomers = new List<Customer>();
            this.ListaRestrictedSupplies = new List<Suppliers>();
            this.ListaSales = new List<Sales>();
            this.ListaSalesItems = new List<SalesItems>();

        }


        //Lucas-----------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------
        //Lucas
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
        public Produce LocalizarProduce(int idProduce)
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
            string cdbMedicamento = Console.ReadLine();
            Medicine medicine = LocalizarMedicine(cdbMedicamento);
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


                Produce produce = new Produce(id, cdbMedicamento, quantidade);
                this.ListaProduces.Add(produce);

                Console.Clear();
                Console.WriteLine("Produce criada com sucesso!");
                Console.ReadKey();

            }


        }


        public void AlterarProduce()
        {

            Console.WriteLine("Digite o id da produção a ser atualizada: ");
            int id = Convert.ToInt32(Console.ReadLine()!);
            var produce = LocalizarProduce(id);
            if (produce == null)
            {
                Console.WriteLine("Produção não encontrada");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Digite o id do novo medicamento: ");
                string cdbMedicamento = Console.ReadLine();
                Console.WriteLine("Digite a nova quantidade: ");
                int quantidade = int.Parse(Console.ReadLine()!);

                produce.SetQuantidade(quantidade);
                produce.SetMedicamento(cdbMedicamento);

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



        public void ImprimirListaProduceItems()
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


        //Giovanna-----------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------
        //Giovanna
        //método para verificar se já existe algum ingrediente com o mesmo id
        public bool BuscarIngridientId(string id)
        {
            if (ListaIngredients == null || ListaIngredients.Count == 0)
                return false;
            return ListaIngredients.Any(aux => aux.Id == id);// true - existe | false - não existe
        }


        //Retorna um ingrediente novo para ser inserido na lista
        public void IncluirIngredient()
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
                    Console.WriteLine("Erro! O Id que digitou está no formato errado, não contendo apenas 6 caracteres");
                }
            } while (auxId == 0);

            do
            {
                Console.WriteLine("Qual o nome do ingrediente (Lembrete do formato obrigatório: até 20 caracteres, e apenas alfanuméricos)?");
                nome = Console.ReadLine();
                if (nome.Length <= 20)
                {
                    if (!Regex.IsMatch(nome, @"^[a-zA-Z0-9 ]+$"))
                        Console.WriteLine("O nome deve conter apenas caracteres alfanuméricos!");
                    else
                    {
                        auxNome = 1;
                        nome = nome.PadRight(20);
                    }
                }
                else
                {
                    Console.WriteLine("O nome pode ter ATÉ 20 caracteres");
                }
            } while (auxNome == 0);

            //Data UltimaCompra será colocada apenas quando for realizado uma compra
            //DataCadstro será atribuída no próprio construtor com a data atual
            //Situação será atribuída no prórpio construtor como Ativa

            //return new Ingredient(id, nome);
            // Ingredient novo = ;
            ListaIngredients.Add(new Ingredient(id, nome));
            Console.WriteLine("Ingrediente adicionado com sucesso!");
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
                    return;
                }
            }
            Console.WriteLine("Ingrediente não localizado!");
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
                        ing.SetSituacao('A');
                        return;
                    }
                    else if (ing.Situacao == 'A')
                    {
                        Console.WriteLine("Situação do ingrediente alterada com sucesso! De ativo para inativo!");
                        ing.SetSituacao('I');
                        return;
                    }
                }
            }
            Console.WriteLine("Ingrediente não localizado!");
        }

        //É chamada quando há uma nova compra, alterando a data da última compra
        public void AlterarIngredientUltimaCompra(DateOnly ultimacompra, string id)
        {
            foreach (var ing in ListaIngredients)
            {
                if (ing.Id == id)
                {
                    ing.SetUltimaCompra(ultimacompra);
                }
            }
        }

        //Imprime a lista de ingredientes
        public void ImprimirIngridient()
        {
            if (ListaIngredients == null || !ListaIngredients.Any())
                Console.WriteLine("A lista está vazia!");
            else
            {
                foreach (var ing in ListaIngredients)
                {
                    Console.WriteLine(ing.ToString());
                }
            }
        }




        //começo medicine

        //Mostra uma mensagem com as informações do medicamento, caso não ache o Id mostra uma mensagem que não achou
        public Medicine LocalizarMedicine(string cdb)
        {
            foreach (var med in ListaMedicines)
            {
                if (med.CDB == cdb)
                    return med;
            }
            return null;
        }

        //verifica se o CDB passado existe
        public bool VerificacaoCDB(string cdb)
        {
            int[] vetoraux = new int[13];
            vetoraux = cdb.Select(c => int.Parse(c.ToString())).ToArray();
            int somaImpar = 0, somaPar = 0;

            for (int i = 1; i < 13; i++)
            {
                if (i % 2 != 0)
                    somaImpar += vetoraux[i - 1];
                else
                    somaPar += vetoraux[i - 1];
            }

            int somaTotal = somaImpar + somaPar * 3;
            int verificador = 10 - (somaTotal % 10);
            return verificador == vetoraux[12];
        }

        //inclui o novo medicamento
        public void IncluirMedicine()
        {
            string nome, cdb;
            char categoria = ' ';
            int opCategoria;
            int auxNome = 0, auxVenda = 0, auxCategoria = 1, auxCdb = 0;
            decimal valorVenda;
            Console.WriteLine("MEDICAMENTO");

            do
            {
                Console.WriteLine("Qual o código de barras. (Lembrete do formato obrigatório: 13 caracteres e ínicio '789')?");
                cdb = Console.ReadLine();
                if (cdb.Length != 13)
                    Console.WriteLine("Código de barras com tamanho diferente de 13 caracteres!");
                else if ((cdb.Substring(0, 3)) != "789")
                    Console.WriteLine("Começo do código diferente de '789'");
                else
                {
                    if (VerificacaoCDB(cdb))
                    {
                        if (LocalizarMedicine(cdb) == null)
                            auxCdb = 1;
                        else
                            Console.WriteLine("Código de barras já existente!");
                    }
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
                    if (!Regex.IsMatch(nome, @"^[a-zA-Z0-9 ]+$"))
                        Console.WriteLine("O nome deve conter apenas caracteres alfanuméricos!");
                    else
                    {
                        nome = nome.PadRight(40);
                        auxNome = 1;
                    }
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
                        auxCategoria = 1;
                        break;
                    case 2:
                        categoria = 'B';
                        auxCategoria = 1;
                        break;
                    case 3:
                        categoria = 'I';
                        auxCategoria = 1;
                        break;
                    case 4:
                        categoria = 'V';
                        auxCategoria = 1;
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
                {
                    string formatadoValorVenda = valorVenda.ToString("F2").PadLeft(7);
                    auxVenda = 1;
                }
                else
                    Console.WriteLine("Valor inválido! Deve ser > 0 e < 10.000");
            } while (auxVenda == 0);


            ListaMedicines.Add(new Medicine(cdb, nome, categoria, valorVenda));
            Console.WriteLine("Medicamento adicionado com sucesso!");
        }

        //altera as informações do medicamento
        public void AlterarMedicine(string cdb)
        {
            decimal valorVenda;
            int auxVenda = 0;
            Medicine medicine = LocalizarMedicine(cdb);
            Medicine medicine1 = medicine;

            Console.WriteLine("O que deseja alterar?\n1 - Valor da Venda\n2 - Situação do medicamento\n3 - As duas opções");
            int op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    do
                    {
                        Console.WriteLine("Qual o novo valor da venda do medicamento?");
                        valorVenda = decimal.Parse(Console.ReadLine());
                        if (valorVenda > 0 && valorVenda < 10000)
                            auxVenda = 1;
                        else
                            Console.WriteLine("Valor inválido! Deve ser > 0 e < 10.000");
                    } while (auxVenda == 0);
                    medicine.SetValorVenda(valorVenda);
                    Console.WriteLine("Valor alterado com sucesso!");
                    break;
                case 2:
                    foreach (var med in ListaMedicines)
                    {
                        if (med.CDB == cdb)
                        {
                            if (med.Situacao == 'I')
                            {
                                Console.WriteLine("Situação do medicamento alterada com sucesso! De inativo para ativo!");
                                med.SetSituacao('A');
                            }
                            else if (med.Situacao == 'A')
                            {
                                Console.WriteLine("Situação do medicamento alterada com sucesso! De ativo para inativo!");
                                med.SetSituacao('I');
                            }
                            else
                                Console.WriteLine("Medicamento não localizado!");
                        }
                    }
                    break;
                case 3:
                    do
                    {
                        Console.WriteLine("Qual o novo valor da venda do medicamento?");
                        valorVenda = decimal.Parse(Console.ReadLine());
                        if (valorVenda > 0 && valorVenda < 10000)
                            auxVenda = 1;
                        else
                            Console.WriteLine("Valor inválido! Deve ser > 0 e < 10.000");
                    } while (auxVenda == 0);
                    medicine1.SetValorVenda(valorVenda);

                    foreach (var med in ListaMedicines)
                    {
                        if (med.CDB == cdb)
                        {
                            if (med.Situacao == 'I')
                            {
                                Console.WriteLine("Situação do medicamento e valor alteradas com sucesso! De inativo para ativo!");
                                med.SetSituacao('A');
                            }
                            else if (med.Situacao == 'A')
                            {
                                Console.WriteLine("Situação do medicamento e valor alteradas com sucesso! De ativo para inativo!");
                                med.SetSituacao('I');
                            }
                            else
                                Console.WriteLine("Medicamento não localizado!");
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }

        //
        public void ImprimirMedicines()
        {
            if (ListaMedicines == null || !ListaMedicines.Any())
                Console.WriteLine("A lista está vazia!");
            else
            {
                foreach (var med in ListaMedicines)
                {
                    Console.WriteLine(med.ToString());
                }
            }
        }

        //Ana---------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------
        //Ana

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

            Console.Write("Informe o telefone: DDD + Número ");
            string telefone = Console.ReadLine();


            Console.Write("Informe a data de nascimento do cliente: ");
            DateOnly dataNascimento = DateOnly.Parse(Console.ReadLine());
            VerificarMaioridade(dataNascimento);

            ListaCustomers.Add(new Customer(cpf, nome, dataNascimento, telefone));
        }

        public void AlterarCustomerUltimaCompra(DateOnly ultimaCompra, string cpf)
        {
            foreach (var cliente in ListaCustomers)
            {
                if (cliente.CPF == cpf)
                {
                    cliente.SetUltimaCompra(ultimaCompra);
                }
            }
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
                if (cliente == null)
                {
                    Console.WriteLine("Lista vazia");
                }
                else
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine(cliente + "\n");
                    Console.WriteLine("-------------------------------------");
                }
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

            Console.Write("Informe a data de fundação da empresa: ");
            DateOnly dataFundacao = DateOnly.Parse(Console.ReadLine());
            VerificarDataAbertura(dataFundacao);

            ListaSupplies.Add(new Suppliers(cnpj, razaoSocial, pais, dataFundacao));
        }

        public Suppliers LocalizarFornecedor(string cnpj)
        {
            return ListaSupplies.Find(s => s.GetCNPJ() == cnpj);

        }
        public void ExibirFornecedores()
        {
            Console.WriteLine("LISTA DE FORNECEDORES");
            foreach (var fornecedor in ListaSupplies)
            {
                if (fornecedor == null)
                {
                    Console.WriteLine("Lista vazia");
                }
                else
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine(fornecedor + "\n");
                    Console.WriteLine("-------------------------------------");
                }

            }
        }

        public void AlterarSuppliesUltimoFornecimento(DateOnly ultimoFornecimento, string cnpj)
        {
            foreach (var fornecedor in ListaSupplies)
            {
                if (fornecedor.CNPJ == cnpj)
                {
                    fornecedor.SetUltimoFornecimento(ultimoFornecimento);
                }
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
                    ListaRestrictedCustomers.Add(cliente);
                    Console.WriteLine("Cliente adicionado a lista de Clientes Restritos.");

                }
                else
                {
                    Console.WriteLine("O cliente não está cadastrado.");
                }

            }
        }

        public bool LocalizarClientesRestritos(string cpf)
        {
            foreach (var cliente in ListaRestrictedCustomers)
            {
                if (cliente.CPF == cpf)
                {
                    return true;
                }

            }
            return false;
        }

        public void AlterarClientesRestritos()
        {
            Console.WriteLine("Qual o cpf do cliente que deseja excluir da lista de restritos?");
            string cpf = Console.ReadLine()!;
            var cliente = LocalizarCliente(cpf);
            Console.WriteLine("Tem certeza que deseja excluir da lista de restritos? [1] SIM / [2] NÃO");
            int op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                ListaCustomers.Add((cliente));
                ListaRestrictedCustomers.Remove(cliente);
            }
            else if (op == 2)
            {
                Console.WriteLine("Sem alterações");
            }
            else
            {
                Console.WriteLine("Opção inválida");
            }

        }

        public void ExibirClientesRestritos()
        {
            Console.WriteLine("LISTA DE CLIENTES RESTRITOS");
            foreach (var cliente in ListaRestrictedCustomers)
            {
                if (cliente == null)
                {
                    Console.WriteLine("Lista vazia");
                }
                else
                    Console.WriteLine("------------------------------------");
                Console.WriteLine(cliente.CPF + "\n");
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
                    ListaRestrictedSupplies.Add(fornecedor);
                    Console.WriteLine("Empresa adicionada a lista de Empresas Restritas.");

                }
                else
                {
                    Console.WriteLine("A empresa não está cadastrada.");
                }
            }
        }

        public bool LocalizarFornecedoresRestritos(string cnpj)
        {
            foreach (var fornecedor in ListaRestrictedSupplies)
            {
                if (fornecedor.CNPJ == cnpj)
                {
                    return true;
                }

            }
            return false;
        }

        public void AlterarFornecedoresRestritos()
        {
            Console.WriteLine("Qual o cnpj da empresa que deseja excluir da lista de restritos?");
            string cnpj = Console.ReadLine()!;
            var fornecedor = LocalizarFornecedor(cnpj);
            Console.WriteLine("Tem certeza que deseja excluir da lista de restritos? [1] SIM / [2] NÃO");
            int op = int.Parse(Console.ReadLine());

            if (op == 1)
            {
                ListaSupplies.Add((fornecedor));
                ListaRestrictedSupplies.Remove(fornecedor);
            }
            else if (op == 2)
            {
                Console.WriteLine("Sem alterações");
            }
            else
            {
                Console.WriteLine("Opção inválida");
            }
        }

        public void ExibirFornecedoresRestritos()
        {
            Console.WriteLine("LISTA DE FORNECEDORES RESTRITOS");
            foreach (var fornecedor in ListaRestrictedSupplies)
            {
                if (fornecedor == null)
                {
                    Console.WriteLine("Lista vazia");
                }
                else
                    Console.WriteLine("------------------------------------");
                Console.WriteLine(fornecedor.CNPJ + "\n");
                Console.WriteLine("-------------------------------------");
            }

        }

        //Felipe---------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------

        public void IncluirPurchases()
        {
            double valorTotal = 0;
            int id;
            while (true)
            {
                Console.WriteLine("Digite o Id da compra: ");
                if (int.TryParse(Console.ReadLine(), out id))
                    break;
                string formatadoId = id.ToString().PadLeft(5, '0');
                Console.WriteLine("Id inválido. Digite um número inteiro.");
            }
            DateOnly data;
            while (true)
            {
                Console.WriteLine($"Digite a data da compra (ddMMyyyy)," +
                    $"vazio para hoje ({DateOnly.FromDateTime(DateTime.Now):ddMMyyyy}):");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    data = DateOnly.FromDateTime(DateTime.Now);
                    break;
                }
                if (DateOnly.TryParseExact(input, "ddMMyyyy", null,
                    System.Globalization.DateTimeStyles.None, out data))
                    break;
                string formatadoData = data.ToString().PadLeft(8);
                Console.WriteLine("Data no formato inválido. Tente novamente.");
            }

            string fornecedorCnpj;
            Suppliers fornecedor = null;
            while (true)
            {
                Console.WriteLine("Digite o CNPJ do fornecedor: ");
                fornecedorCnpj = Console.ReadLine();
                string formatadoCnpj = fornecedorCnpj.ToString().PadLeft(14);
                fornecedor = ListaSupplies.FirstOrDefault(f => f.CNPJ == fornecedorCnpj);
                if (fornecedor == null)
                {
                    Console.WriteLine("Fornecedor não encontrado. Tente novamente.");
                    continue;
                }
                if (ListaRestrictedSupplies.Any(f => f.CNPJ == fornecedorCnpj))
                {
                    Console.WriteLine("Fornecedor está bloqueado e " +
                        "não pode ser selecionado.");
                    continue;
                }
                break;
            }
            int contadorItens = 0;
            while (contadorItens <= 3)
            {
                int idCompra;
                while (true)
                {
                    Console.WriteLine("Digite o Id do item comprado: ");
                    if (int.TryParse(Console.ReadLine(), out idCompra))
                        break;
                    Console.WriteLine("Id inválido. Digite um número inteiro.");
                }
                string ingredienteId;
                Ingredient ingredient = null;
                while (true)
                {
                    Console.WriteLine("Digite o Id do princípio ativo: ");
                    ingredienteId = Console.ReadLine();
                    ingredient = ListaIngredients.FirstOrDefault(i => i.Id ==
                    ingredienteId && i.Situacao == 'A');
                    if (ingredient != null)
                        break;
                    Console.WriteLine("Ingrediente inválido ou inativo. " +
                        "Tente novamente.");
                }
                int quantidade;
                while (true)
                {
                    Console.WriteLine("Digite a quantidade em gramas do item " +
                        "(0 a 10000):");
                    if (int.TryParse(Console.ReadLine(), out quantidade) &&
                        quantidade >= 0 && quantidade <= 10000)
                        break;
                    Console.WriteLine("Quantidade inválida. Deve estar entre " +
                        "0 e 10.000.");
                }
                double valorUnitario;
                while (true)
                {
                    Console.WriteLine("Digite o valor unitário do item (0 a 1000): ");
                    if (double.TryParse(Console.ReadLine(), out valorUnitario)
                        && valorUnitario >= 0 && valorUnitario <= 1000)
                        break;
                    Console.WriteLine("Valor unitário inválido. Deve estar entre" +
                        " 0 e 1.000.");
                }
                double totalItem = quantidade * valorUnitario;
                Console.WriteLine($"Total do item: {totalItem:F2}");

                valorTotal += totalItem;

                this.ListaPurchaseItems.Add(new PurchaseItem(idCompra,
                    ingredient.Id, quantidade, valorUnitario, totalItem));
                contadorItens++;

                if (contadorItens <= 3)
                {
                    Console.WriteLine("Deseja adicionar mais um item? (S/N)");
                    var resposta = Console.ReadLine();
                    if (resposta == null || !resposta.Trim().ToUpper().StartsWith("S"))
                        break;
                }
                AlterarIngredientUltimaCompra(data, ingredienteId);
            }
            Console.WriteLine($"Valor total dos itens: {valorTotal:F2}");
            this.ListaPurchases.Add(new Purchases(id, data, fornecedor.CNPJ,
                valorTotal));
        }

        public Purchases RetornarPurchases(int Id)
        {
            foreach (var item in ListaPurchases)
            {
                if (item.Id == Id)
                {
                    return item;
                }
            }
            return null;
        }
        public PurchaseItem RetornarPurchaseItem(int Id)
        {
            foreach (var item in ListaPurchaseItems)
            {
                if (item.IdCompra == Id)
                {
                    return item;
                }
            }
            return null;
        }
        public void LocalizarPurchases()
        {
            Console.WriteLine("Digite o id da compra: ");
            int id = int.Parse(Console.ReadLine()!);
            Purchases purchase = RetornarPurchases(id);
            if (purchase != null)
            {
                Console.Clear();
                Console.WriteLine("Compra encontrada!");
                Console.WriteLine(purchase);
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Compra não encontrada!");
                Console.ReadKey();
            }
        }
        public void LocalizarPurchaseItem()
        {
            Console.WriteLine("Digite o id do item da compra: ");
            int id = int.Parse(Console.ReadLine()!);
            PurchaseItem item = RetornarPurchaseItem(id);
            if (item != null)
            {
                Console.Clear();
                Console.WriteLine("Item da compra encontrado!");
                Console.WriteLine(item);
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Item da compra não encontrado!");
                Console.ReadKey();
            }
        }
        public void AlterarPurchases(int IdCompra)
        {
            int quantidade;
            double valorUnitario;
            int auxItems = 0;
            PurchaseItem purchaseItem;
            Purchases purchases;
            do
            {
                Console.WriteLine("O Id da compra está incorreto");
                var aux = int.Parse(Console.ReadLine());
                purchaseItem = RetornarPurchaseItem(aux);
            } while (purchaseItem == null);

            purchases = RetornarPurchases(IdCompra);

            Console.WriteLine("Digite o que deseja alterar:\n1 - Quantidade" +
                "\n2 - ValorUnitário\n3 - As duas opções ");
            var opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    auxItems = 0;
                    do
                    {
                        Console.WriteLine("Digite a nova quantidade em gramas do item:");
                        quantidade = int.Parse(Console.ReadLine());
                        string formatadoQuantidade =
                            quantidade.ToString().PadLeft(4, '0');
                        if (quantidade < 0 && quantidade > 10000)
                        {
                            Console.WriteLine("Quantidade Inválida! A quantidade " +
                                "em gramas de itens deve estar entre 0 e 10.000.");
                        }
                        var totalItem = quantidade * purchaseItem.ValorUnitario;
                        if (totalItem <= 0 || totalItem >= 9999999.00)
                        {
                            Console.WriteLine("Valor total inválido! " +
                                "Deve estar entre 0 e 10.000.000,00.");
                            continue;
                        }
                        auxItems = 1;
                        purchaseItem.setQuantidade(quantidade);
                        purchaseItem.setTotaItem(totalItem);
                        purchases.setValorTotal(totalItem);
                    } while (auxItems == 0);
                    break;
                case 2:
                    auxItems = 0;
                    do
                    {
                        Console.WriteLine("Digite o novo Valor Unitário" +
                            " por gramas do item: ");
                        valorUnitario = double.Parse(Console.ReadLine());
                        string formatadoValorUnitario = valorUnitario.
                            ToString("F2").PadLeft(6, '0');
                        if (valorUnitario < 0 && valorUnitario > 1000)
                        {
                            Console.WriteLine("Quantidade Inválida! " +
                                "A quantidade em grams de " +
                                "itens deve estar entre 0 e 1.000.");
                            continue;
                        }
                        var totalItem = purchaseItem.Quantidade * valorUnitario;
                        if (totalItem <= 0 || totalItem >= 9999999.00)
                        {
                            Console.WriteLine("Valor total inválido! " +
                                "Deve estar entre 0 e 10.000.000,00.");
                            continue;
                        }
                        auxItems = 1;
                        purchaseItem.setValorUnitario(valorUnitario);
                        purchaseItem.setTotaItem(purchaseItem.Quantidade * valorUnitario);
                        purchases.setValorTotal(totalItem);
                    } while (auxItems == 0);
                    break;
                case 3:
                    auxItems = 0;
                    do
                    {
                        Console.WriteLine("Digite a nova quantidade em gramas do item:");
                        quantidade = int.Parse(Console.ReadLine());
                        string formatadoQuantidade =
                            quantidade.ToString().PadLeft(4, '0');
                        if (quantidade < 0 && quantidade > 10000)
                        {
                            Console.WriteLine("Quantidade Inválida! " +
                                "A quantidade em gramas de " +
                                "itens deve estar entre 0 e 10.000.");
                            continue;
                        }
                        Console.WriteLine("Digite o novo Valor Unitário" +
                            " por gramas do item: ");
                        valorUnitario = double.Parse(Console.ReadLine());
                        string formatadoValorUnitario = valorUnitario.
                            ToString("F2").PadLeft(6, '0');
                        if (valorUnitario < 0 && valorUnitario > 1000)
                        {
                            Console.WriteLine("Quantidade Inválida! " +
                                "A quantidade em gramas de " +
                                "itens deve estar entre 0 e 1.000.");
                            continue;
                        }
                        var totalItem = purchaseItem.Quantidade * valorUnitario;
                        if (totalItem <= 0 || totalItem >= 9999999.00)
                        {
                            Console.WriteLine("Valor total inválido! " +
                                "Deve estar entre 0 e 10.000.000,00.");
                            continue;
                        }
                        auxItems = 1;
                        purchaseItem.setQuantidade(quantidade);
                        purchaseItem.setValorUnitario(valorUnitario);
                        purchaseItem.setTotaItem(totalItem);
                        purchases.setValorTotal(totalItem);
                    } while (auxItems == 0);
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
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
            foreach (var purchaseItem in this.ListaPurchaseItems)
            {
                Console.WriteLine(purchaseItem);
            }
        }

        //Leandro--------------------------------------------------------------------------------------------
        public void IncluirSales()
        {
            Console.WriteLine("Digite o CPF do cliente: ");
            string cpf = Console.ReadLine()!;
            Sales sal = new Sales(cpf);
            this.ListaSales.Add(sal);
            Console.Clear();
            Console.WriteLine("Venda realizada com Sucesso!");
            Console.ReadKey();
        }
        public Sales RetornarSales(int id)
        {
            foreach (var sales in this.ListaSales)
            {
                if (sales.Id == id)
                {
                    return sales;
                }
            }
            return null;
        }
        public void LocalizarSales()
        {
            Console.WriteLine("Digite o id da venda: ");
            int id = int.Parse(Console.ReadLine()!);
            Sales sal = RetornarSales(id);
            if (sal != null)
            {
                Console.Clear();
                Console.WriteLine("Venda encontrada!");
                Console.WriteLine(sal);
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Venda não encontrado!");
                Console.ReadKey();
            }
        }
        public void ImprimirListaSales()
        {
            Console.Clear();
            foreach (var venda in ListaSales)
            {
                Console.WriteLine(venda);
                Console.WriteLine("---------//---------");
            }
            Console.ReadKey();
        }
        public void IncluirSaleItems()
        {
            int aux = 0;
            int id = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Digite o Id da Venda: ");
                var idVenda = Console.ReadLine()!;
                if (idVenda.Length == 5 && idVenda.All(char.IsDigit))
                {
                    id = int.Parse(idVenda);
                    aux = 1;
                }
                else
                {
                    Console.WriteLine("Id no formato inválido!");
                    Console.ReadKey();
                }
            } while (aux == 0);
            var sales = RetornarSales(id);
            if (sales == null)
            {
                Console.Clear();
                Console.WriteLine("Venda não encontrada");
                Console.ReadLine();
            }
            else if (sales.ItemsFull())
            {
                Console.Clear();
                Console.WriteLine("Venda ja possui três itens!");
                Console.ReadLine();
            }
            else
            {
                aux = 0;
                string cdb;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Digite o código de barras do medicamento");
                    cdb = Console.ReadLine()!;
                    if (cdb.Length == 13 && cdb.All(char.IsDigit))
                    {
                        aux = 1;
                    }
                    else
                    {
                        Console.WriteLine("Código de barra no formato inválido!");
                        Console.ReadKey();
                    }
                } while (aux == 0);
                aux = 0;
                int quantidade = 0;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Digite a quantidade vendida: ");
                    string stringQuantidade = Console.ReadLine()!;
                    if (stringQuantidade.Length <= 3 && stringQuantidade.All(char.IsDigit))
                    {
                        quantidade = int.Parse(stringQuantidade);
                        aux = 1;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Número inválido!");
                        Console.ReadKey();
                    }
                } while (aux == 0);
                aux = 0;
                decimal valorUnit = 0.0m;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Digite o valor unitario: ");
                    string stringvalorUnit = Console.ReadLine()!;
                    if (stringvalorUnit.Length <= 6 && stringvalorUnit.All(char.IsDigit))
                    {
                        valorUnit = decimal.Parse(stringvalorUnit);
                        aux = 1;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Número inválido!");
                        Console.ReadKey();
                    }
                } while (aux == 0);
                var salesItems = new SalesItems(id, cdb, quantidade, valorUnit);
                this.ListaSalesItems.Add(salesItems);
                sales.IncluirListaSalesItems(salesItems);
                Console.Clear();
                Console.WriteLine("Item de venda inserido com sucesso!");
                Console.ReadKey();
            }
        }
        public void ImprimirListaSalesItems()
        {
            Console.Clear();
            foreach (var item in ListaSalesItems)
            {
                Console.WriteLine(item);
                Console.WriteLine("---------//---------");
            }
            Console.ReadKey();
        }
        public void AlterarSalesItems()
        {
            int id = 0;
            int aux = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Digite o Id do item: ");
                var idItem = Console.ReadLine()!;
                if (idItem.Length == 5 && idItem.All(char.IsDigit))
                {
                    id = int.Parse(idItem);
                    aux = 1;
                }
                else
                {
                    Console.WriteLine("Id no formato inválido!");
                    Console.ReadKey();
                }
            } while (aux == 0);
            var salesItems = RetornaSalesItems(id);
            if (salesItems is null)
            {
                Console.Clear();
                Console.WriteLine("O item buscado não existe!");
                Console.ReadKey();
            }
            else
            {
                aux = 0;
                int quantidade = 0;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Digite a nova quantidade vendida: ");
                    string stringQuantidade = Console.ReadLine()!;
                    if (stringQuantidade.Length <= 3 && stringQuantidade.All(char.IsDigit))
                    {
                        quantidade = int.Parse(stringQuantidade);
                        aux = 1;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Número inválido!");
                        Console.ReadKey();
                    }
                } while (aux == 0);
                aux = 0;
                decimal valorUnit = 0;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Digite o novo valor unitario: ");
                    string stringvalorUnit = Console.ReadLine()!;
                    if (stringvalorUnit.Length <= 6 && stringvalorUnit.All(char.IsDigit))
                    {
                        valorUnit = decimal.Parse(stringvalorUnit);
                        aux = 1;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Número inválido!");
                        Console.ReadKey();
                    }
                } while (aux == 0);
                salesItems.SetQuantidade(quantidade);
                salesItems.SetValorUnitario(valorUnit);
                Sales sales = RetornarSales(salesItems.IdVenda);
                sales.SetValorTotal();
                Console.Clear();
                Console.WriteLine("Item de venda alterado com sucesso!");
                Console.ReadKey();
            }
        }
        public SalesItems RetornaSalesItems(int codigo)
        {
            foreach (var item in ListaSalesItems)
            {
                if (item.Chave == codigo)
                {
                    return item;
                }
            }
            return null;
        }
        public void LocalizarSalesItems()
        {
            int id = 0;
            int aux = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Digite o Id do item: ");
                var idItem = Console.ReadLine()!;
                if (idItem.Length == 5 && idItem.All(char.IsDigit))
                {
                    id = int.Parse(idItem);
                    aux = 1;
                }
                else
                {
                    Console.WriteLine("Id no formato inválido!");
                    Console.ReadKey();
                }
            } while (aux == 0);
            var salesItems = RetornaSalesItems(id);
            if (salesItems is null)
            {
                Console.Clear();
                Console.WriteLine("O item buscado não existe!");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine(salesItems);
                Console.ReadKey();
            }
        }
    }
}











    

