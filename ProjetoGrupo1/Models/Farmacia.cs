using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoGrupo1.Models;

namespace ProjetoGrupo1.Models
{
    public class Farmacia
    {

        public List<Customer> ListaCustomers = new List<Customer>();
        public List<Supplies> ListaSupplies = new List<Supplies>();
        public List<Customer> ListaRestrictedCustomers = new List<Customer>();
        public List<Supplies> ListaRestrictedSupplies = new List<Supplies>();





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
            string cpf = Console.ReadLine()!);
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
                if (fornecedor.CNPJ == cnpj)
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
            return ListaSupplies.Find(s => s.CNPJ == cnpj);

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
            string cnpj = Console.ReadLine()!);
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
                if (fornecedor.CNPJ == cnpj)
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
            return ListaRestrictedSupplies.Find(s => s.CNPJ == cnpj);
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

    } }
