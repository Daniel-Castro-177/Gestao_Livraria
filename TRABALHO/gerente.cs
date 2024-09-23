using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace TRABALHO
{
    internal class gerente : funcionario
    {
        public gerente(int id, string password, string nome)
        {
            this.id = id;
            this.password = password;
            this.nome = nome;

        }


        public void add_func_9(List<funcionario> funcionarios)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("*************************ADICIONAR FUNCINÁRIO************************");
                Console.WriteLine("*********************************************************************");
                int contagem = 1;
                // foreach para verificar quantos funcionários existem para adicionar o id ao novo

                foreach (funcionario funcionario in funcionarios)
                {
                    if (funcionario.id >= contagem)
                    {
                        contagem = funcionario.id + 1;
                    }
                }

                int id;
                string password;
                string nome;
                int posicao;
                id = contagem;

                Console.WriteLine("   Indique a posição do novo funcionário: ");
                Console.WriteLine("   1- Repositor");
                Console.WriteLine("   2- Caixa");
                Console.WriteLine("   3- Gerente");


                posicao = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("  Indique a password do novo funcionário: ");
                password = Convert.ToString(Console.ReadLine());

                Console.WriteLine("  Indique o nome do novo funcinário:");
                nome = Convert.ToString(Console.ReadLine());


                // verificar se a posição digitada pelo utilizador faz sentido

                if (posicao != 1 && posicao != 2 && posicao != 3)
                {
                    Console.WriteLine("");
                    Console.WriteLine("  Não inseriu uma posição válida!");
                    Console.WriteLine("  Tente novamente: ");
                    Console.WriteLine("");
                    add_func_9(funcionarios);
                }

                // verificação para saber que tipo de funcinário é

                if (posicao == 2)
                {
                    funcionarios.Add(new caixa(id, password, nome));
                    Console.WriteLine("");
                    Console.WriteLine("O funcionário foi adicionado ao sistema com sucesso e o seu ID é o " + id);
                    Console.WriteLine("");

                }

                if (posicao == 1)
                {
                    funcionarios.Add(new repositor(id, password, nome));
                    Console.WriteLine("");
                    Console.WriteLine("O funcionário foi adicionado ao sistema com sucesso e o seu ID é o " + id);
                    Console.WriteLine("");
                }

                if (posicao == 3)
                {
                    funcionarios.Add(new gerente(id, password, nome));
                    Console.WriteLine("");
                    Console.WriteLine("O funcionário foi adicionado ao sistema com sucesso e o seu ID é o " + id);
                    Console.WriteLine("");
                }
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("*************************ADICIONAR FUNCINÁRIO************************");
                Console.WriteLine("*********************************************************************");
                Console.WriteLine("Não introduziu os dados corretamente.");
                Console.WriteLine("Tente novamente: ");
                Thread.Sleep(2000);
               
                add_func_9(funcionarios);
            }
        }


        public void remove_func_10(List<funcionario> funcionarios)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("*************************REMOVER FUNCIONÁRIO*************************");
                Console.WriteLine("*********************************************************************");
                int id;
                bool encontrado = false;

                Console.WriteLine("  Indique o ID do funcionário que pretende eliminar: ");
                id = Convert.ToInt32(Console.ReadLine());


                for (int i = 0; i < funcionarios.Count; i++)
                {
                    if (funcionarios[i].id == id)
                    {
                        funcionarios.RemoveAt(i);
                        encontrado = true;
                    }

                }

                if (encontrado == true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("   O funcionário foi eliminado do sistema com sucesso!");
                    Console.WriteLine("");

                }
                if (encontrado == false)
                {
                    Console.WriteLine("");
                    Console.WriteLine("  Não foi encontrado nenhum utilizador com o ID inserido!");
                    Console.WriteLine("");

                }

            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("*************************REMOVER FUNCIONÁRIO*************************");
                Console.WriteLine("*********************************************************************");
                Console.WriteLine("Não introduziu os dados corretamente.");
                Console.WriteLine("Tente novamente: ");
                Thread.Sleep(2000);
               
                remove_func_10(funcionarios);
            }


        }



        public void listar_utilizadores_5(List<funcionario> funcionarios)
        {
            Console.Clear();
            Console.WriteLine("*************************LISTAR FUNCIONÁRIOS*************************");
            Console.WriteLine("*********************************************************************");
            foreach (funcionario funcionario in funcionarios)
            {

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("   Id do funcionário: " + funcionario.id);
                Console.WriteLine("   Password do funcionário: " + funcionario.password);
                Console.WriteLine("   Nome do funcinário: " + funcionario.nome);
                if (funcionario is caixa)
                {
                    Console.WriteLine("   Posição: Caixa");
                }
                if (funcionario is repositor)
                {
                    Console.WriteLine("   Posição: Repositor");
                }
                if (funcionario is gerente)
                {
                    Console.WriteLine("   Posição: Gerente");
                }
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }

        public void vender_livro_6(List<livro> livros)
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
                                    receita_com_desconto = livro.receita * 0.10;  //
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
                vender_livro_6(livros);
            }
        }


        public void receita_gerada_8(List<livro> livros)
        {
            Console.Clear();
            Console.WriteLine("**************************CONSULTAR RECEITA**************************");
            Console.WriteLine("*********************************************************************");
            bool encontrado = false;
            double total = 0;

            foreach (livro livro in livros)
            {
                //se houver algum livro que foi vendido
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
