using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace TRABALHO
{
   internal class funcionario
    {
        public int id;
        public string password;
        public string nome;



        public void consultar_livro(List<livro> livros)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("**********************CONSULTAR LIVRO POR CÓDIGO*********************");
                Console.WriteLine("*********************************************************************");
                int codigo;
                int contagem = 0;

                //lê o codigo do livro
                Console.WriteLine("  Indique o código do livro que pretende pesquisar");
                codigo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");

                //precorre a lista de livros para verificar se há algum livro com aquele codigo
                foreach (livro livro in livros)
                {
                    if (livro.codigo == codigo)
                    {
                        contagem = 1;
                        Console.WriteLine("  Código do livro: " + livro.codigo);
                        Console.WriteLine("  Titulo do livro: " + livro.titulo);
                        Console.WriteLine("  Autor do livro: " + livro.autor);
                        Console.WriteLine("  ISBN do livro: " + livro.isbn);
                        Console.WriteLine("  Género do livro: " + livro.genero);
                        Console.WriteLine("  Preço do livro: " + livro.preco);
                        Console.WriteLine("  Iva do livro: " + livro.iva);
                        Console.WriteLine("  Stock do livro: " + livro.stock);
                        Console.WriteLine("  Exemplares vendidos: " + livro.vendidos);
                        Console.WriteLine("  Receita gerada: " + livro.receita);
                    }

                }
                if (contagem == 0)
                {
                    Console.WriteLine("");

                    Console.WriteLine("  Não foi encontrado nenhum resultado para a sua pesquisa!");
                    Console.WriteLine("");

                }
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("**********************CONSULTAR LIVRO POR CÓDIGO*********************");
                Console.WriteLine("*********************************************************************");
                Console.WriteLine("Não introduziu os dados corretamente.");
                Console.WriteLine("Tente novamente: ");
                Thread.Sleep(2000);

                consultar_livro(livros);
            }
        }


        public void consultar_livro2(List<livro> livros)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("**********************CONSULTAR LIVRO POR GÉNERO*********************");
                Console.WriteLine("*********************************************************************");
              
                bool contagem = false;
                string genero;
                // guarda todos os generos únicos dos livros, a funcao distinct é util para que isso aconteça
                List<string> generosDisponiveis = livros.Select(livro => livro.genero).Distinct().ToList();

                // mostra todos os generos disponíveis
                Console.WriteLine("");
                Console.WriteLine("   Géneros disponíveis em stock:");
                foreach (string generos in generosDisponiveis)
                {
                    Console.WriteLine("   -" + generos);
                }
                //lê o genero pesquisado
                Console.WriteLine("");

                Console.WriteLine("  Indique o género do livro que pretende pesquisar:");
                genero = Convert.ToString(Console.ReadLine());
                Console.WriteLine("");

                //mostra os dados dos livros que tenham aquele genero
                foreach (livro livro in livros)
                {
                    if (livro.genero == genero)
                    {
                        contagem = true;
                        Console.WriteLine("");
                        Console.WriteLine("");

                        Console.WriteLine("  Código do livro: " + livro.codigo);
                        Console.WriteLine("  Titulo do livro: " + livro.titulo);
                        Console.WriteLine("  Autor do livro: " + livro.autor);
                        Console.WriteLine("  ISBN do livro: " + livro.isbn);
                        Console.WriteLine("  Género do livro: " + livro.genero);
                        Console.WriteLine("  Preço do livro: " + livro.preco);
                        Console.WriteLine("  Iva do livro: " + livro.iva);
                        Console.WriteLine("  Stock do livro: " + livro.stock);
                        Console.WriteLine("  Exemplares vendidos: " + livro.vendidos);
                        Console.WriteLine("  Receita gerada: " + livro.receita);
                        Console.WriteLine("");
                        Console.WriteLine("");

                    }

                }
                if (contagem == false)
                {
                    Console.WriteLine("");
                    Console.WriteLine("  Não foi encontrado nenhum resultado para a sua pesquisa!");
                    Console.WriteLine("");

                }
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("**********************CONSULTAR LIVRO POR GÉNERO*********************");
                Console.WriteLine("*********************************************************************");
                Console.WriteLine("Não introduziu os dados corretamente.");
                Console.WriteLine("Tente novamente! ");
                Thread.Sleep(2000);
                consultar_livro2(livros);
            }
        }


        public void consultar_livro3(List<livro> livros)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("**********************CONSULTAR LIVRO POR AUTOR**********************");
                Console.WriteLine("*********************************************************************");
                string autor;
                bool contagem = false;

                // guarda todos os autores únicos dos livros, a função distinct é util para que isso aconteça
                List<string> autoresDisponiveis = livros.Select(livro => livro.autor).Distinct().ToList();

                // mostra todos os generos disponíveis
                Console.WriteLine("");
                Console.WriteLine("   Géneros disponíveis em stock:");
                foreach (string autores in autoresDisponiveis)
                {
                    Console.WriteLine("   -" + autores);
                }

                //lê o autor pesquisado
                Console.WriteLine("  Indique o autor do livro que pretende pesquisar");
                autor = Convert.ToString(Console.ReadLine());
                Console.WriteLine("");

                //mostra os dados dos livros que tenham aquele autor

                foreach (livro livro in livros)
                {
                    if (livro.autor == autor)
                    {
                        contagem = true;
                        Console.WriteLine("");
                        Console.WriteLine("");

                        Console.WriteLine("  Código do livro: " + livro.codigo);
                        Console.WriteLine("  Titulo do livro: " + livro.titulo);
                        Console.WriteLine("  Autor do livro: " + livro.autor);
                        Console.WriteLine("  ISBN do livro: " + livro.isbn);
                        Console.WriteLine("  Género do livro: " + livro.genero);
                        Console.WriteLine("  Preço do livro: " + livro.preco);
                        Console.WriteLine("  Iva do livro: " + livro.iva);
                        Console.WriteLine("  Stock do livro: " + livro.stock);
                        Console.WriteLine("  Exemplares vendidos: " + livro.vendidos);
                        Console.WriteLine("  Receita gerada: " + livro.receita);
                        Console.WriteLine("");
                        Console.WriteLine("");

                    }

                }
                if (contagem == false)
                {

                    Console.WriteLine("");

                    Console.WriteLine("  Não foi encontrado nenhum resultado para a sua pesquisa!");
                    Console.WriteLine("");

                }
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("**********************CONSULTAR LIVRO POR AUTOR**********************");
                Console.WriteLine("*********************************************************************");
                Console.WriteLine("Não introduziu os dados corretamente.");
                Console.WriteLine("Tente novamente! ");
                Thread.Sleep(2000);
                consultar_livro3(livros);
            }
        }
        //
        public void editar_livro(List<livro> livros)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("*****************************EDITAR LIVRO****************************");
                Console.WriteLine("*********************************************************************");
                bool validacao = false;
                int codigo;
                string titulo;
                string autor;
                int isbn;
                string genero;
                double preco;
                int iva;
                int stock;

                Console.WriteLine("   Indique o código do livro que pretende editar:");
                codigo = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("   Indique o novo título do livro:");
                titulo = Convert.ToString(Console.ReadLine());

                Console.WriteLine("   Indique o novo autor do livro:");
                autor = Convert.ToString(Console.ReadLine());

                Console.WriteLine("   Indique o novo ISBN do livro: ");
                isbn = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("   Indique o novo género do livro: ");
                genero = Convert.ToString(Console.ReadLine());

                Console.WriteLine("   Indique o novo preço do livro: ");
                preco = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("   Indique o novo IVA do livro: ");
                iva = Convert.ToInt32(Console.ReadLine());


                Console.WriteLine("   Indique o novo stock do livro: ");
                stock = Convert.ToInt32(Console.ReadLine());

                foreach (livro livro in livros)
                {
                    if (livro.codigo == codigo)
                    {
                        validacao = true;
                        livro.codigo = codigo;
                        livro.titulo = titulo;
                        livro.autor = autor;
                        livro.isbn = isbn;
                        livro.genero = genero;
                        livro.preco = preco;
                        livro.iva = iva;

                        livro.stock = stock;
                    }
                }
                if (validacao == false)
                {
                    Console.WriteLine("");
                    Console.WriteLine("  Não foi encontrado nenhum livro com o código indicado!");
                    Console.WriteLine("");

                }

                if (validacao == true)

                {
                    Console.WriteLine("");
                    Console.WriteLine("  O livro foi editado com sucesso!");
                    Console.WriteLine("");


                }
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("*****************************EDITAR LIVRO****************************");
                Console.WriteLine("*********************************************************************");
                Console.WriteLine("Não introduziu os dados corretamente.");
                Console.WriteLine("Tente novamente! ");
                Thread.Sleep(2000);

                editar_livro(livros);
            }
        }

        public void consultar_stock_7(List<livro> livros)
        {
            Console.Clear();
            Console.WriteLine("***************************CONSULTAR STOCK***************************");
            Console.WriteLine("*********************************************************************");
            foreach (livro livro in livros)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("  Código do livro: " + livro.codigo);
                Console.WriteLine("  Titulo do livro: " + livro.titulo);
                Console.WriteLine("  Autor do livro: " + livro.autor);
                Console.WriteLine("  ISBN do livro: " + livro.isbn);
                Console.WriteLine("  Género do livro: " + livro.genero);
                Console.WriteLine("  Preço do livro: " + livro.preco);
                Console.WriteLine("  Iva do livro: " + livro.iva);
                Console.WriteLine("  Stock do livro: " + livro.stock);
                Console.WriteLine("  Exemplares vendidos: " + livro.vendidos);
                Console.WriteLine("  Receita gerada: " + livro.receita);
                Console.WriteLine("");
                Console.WriteLine("");



            }

        }




    }



}
