using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGrupo1
{
    public class Farmacia
    {

        public List<Produce> ListaProduces { get; set; }
        public List<ProduceItem> ListaProducesItems { get; set; }

        public Farmacia()
        {
            this.ListaProduces = new List<Produce>();
            this.ListaProducesItems = new List<ProduceItem>();

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
                if(produce.Id == idProduce)
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
            //Medicine medicene = LocalizarMedicine();
            if (medicine == null)
            {
                Console.WriteLine("Medicamento não encontrado!");
            }
            else if (medicine.Situacao == "I")
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
            if(produce == null)
            {
                Console.WriteLine("Produção não encontrada");
            }
            else
            {
                Console.WriteLine("Digite o id do Princípio Ativo");
                string idPrincipio = Console.ReadLine()!;
                var Ingredient = LocalizarIngredient(idPrincipio);
                if(Ingredient != null && Ingredient.Situacao == "A")
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
                    if(Ingredient == null)
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
            foreach(var produceItem in this.ListaProducesItems){
                if(produceItem.IdProduceItem == id)
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
                var Ingredient = LocalizarIngredient(idPrincipio);
                if (Ingredient != null && Ingredient.Situacao == "A")
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
    }


}
