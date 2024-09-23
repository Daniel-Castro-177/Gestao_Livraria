using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace TRABALHO
{
    internal class caixa : funcionario
    {
        public caixa(int id, string password, string nome)
        {
            this.id = id;
            this.password = password;
            this.nome = nome;

        }


        public void vender_livro_5(List<livro> livros, List<int>vendas)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("*****************************VENDER LIVRO****************************");
                Console.WriteLine("*********************************************************************");

                int codigo;
                int quantidade;
                double total = 0;
                double valor_iva;
                double preco_sem_iva;
                double receita_com_desconto;
                Console.WriteLine("Indique o código do livro que pretende vender (ou digite 0 para sair): ");
                codigo = Convert.ToInt32(Console.ReadLine());

                //enquanto o código não for 0
                while (codigo != 0)
                {
                    Console.WriteLine("Indique a quantidade que pretende vender: ");
                    quantidade = Convert.ToInt32(Console.ReadLine());


                    foreach (livro livro in livros)
                    {


                        if (codigo == livro.codigo)
                        {
                            //verifica se há stock
                            if (livro.stock >= quantidade)
                            {

                                livro.stock = livro.stock - quantidade;
                                livro.vendidos = livro.vendidos + quantidade;

                                valor_iva = (livro.preco * livro.iva / 100) * quantidade; // Calcula o valor do IVA com base no preço.
                                preco_sem_iva = (livro.preco - (livro.preco * livro.iva / 100)) * quantidade; // Calcula o preço do livro sem IVA.

                                livro.receita = livro.receita + preco_sem_iva; // Atualiza a receita considerando o preço sem IVA.
                                total = total + (preco_sem_iva + valor_iva);

                                if (total > 50)
                                {
                                    Console.WriteLine("");

                                    Console.WriteLine("Total maior que 50 euros. Foi atribuido um desconto de 10%");
                                    Console.WriteLine("");
                                    Console.WriteLine("");
                                    //tira os 10% ao total da compra
                                    double desconto = total * 0.10;
                                    
                                    //a partir daqui tira 10% às receitas geradas pelos livros porque o desconto foi aplicado
                                    receita_com_desconto = livro.receita * 0.10;
                                    livro.receita = livro.receita - receita_com_desconto;
                                    total = total - desconto;
                                }
                                Console.WriteLine("");

                                Console.WriteLine($"Livro vendido: {livro.titulo}, Quantidade: {quantidade}, Preço total: " + total);
                                Console.WriteLine("");


                            }
                            else
                            {
                                Console.WriteLine("");

                                Console.WriteLine("Stock insuficiente. Reponha o stock.");
                                Console.WriteLine("");

                            }


                        }

                    }
                    Console.WriteLine("");

                    Console.WriteLine("Indique o código do livro que pretende vender (ou digite 0 para sair): ");
                    codigo = Convert.ToInt32(Console.ReadLine());
                }
            }
            catch
            {

                Console.Clear();
                Console.WriteLine("*****************************VENDER LIVRO****************************");
                Console.WriteLine("*********************************************************************");
                Console.WriteLine("Não introduziu os dados corretamente.");
                Console.WriteLine("Tente novamente: ");
                Thread.Sleep(2000);
                vender_livro_5(livros, vendas);
            }
        }



        public void receita_gerada_7(List<livro> livros)
        {
            Console.Clear();
            Console.WriteLine("**************************CONSULTAR RECEITA**************************");
            Console.WriteLine("*********************************************************************");
            bool encontrado = false;
            double total=0;

            //mostra os livros que foram vendidos. Só mostra se já houver pelo menos um exemplar vendido
            foreach (livro livro in livros)
            {
                if (livro.vendidos > 0)
                { 
                    encontrado = true;
                    Console.WriteLine("");
                    Console.WriteLine("   O livro " + livro.codigo + " foi vendido " + livro.vendidos + " vezes.");
                Console.WriteLine("   Gerou uma receita de " + livro.receita + " euros.");
                    total = total + livro.receita;
                Console.WriteLine("");
}
              
           
            
            }

            if (encontrado == true)
            {
                Console.WriteLine("");
                Console.WriteLine("   O saldo atual da biblioteca é: " + total);
            }
  if (encontrado == false)
                {
                    Console.WriteLine("");
                    Console.WriteLine("   A biblioteca não vendeu qualquer livro até à data!");
                    Console.WriteLine("");

                }






        }
    }
}
