using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace TRABALHO
{
    internal class repositor : funcionario
    {

        public repositor(int id, string password, string nome) 
        {
            this.id = id;
            this.password = password;
            this.nome = nome;
           
        }
        public void registar_livro_1(List<livro> livros)
        {
            try
            {  
            Console.Clear();
            Console.WriteLine("****************************REGISTAR LIVRO***************************");
            Console.WriteLine("*********************************************************************");
            // foreach para verificar quantos existem existem para adicionar o codigo ao novo livro
            int contagem = 0;
            foreach (livro livro in livros)
            {
                contagem = contagem + 1;
            }

              int codigo;
         string titulo;
         string autor;
         int isbn;
         string genero;
         double preco;
         int iva;
         int stock;
            double receita = 0.00;
            int vendidos = 0;
        codigo = contagem + 1;

            Console.WriteLine("  Indique o titulo do novo livro: ");
            titulo = Convert.ToString(Console.ReadLine());

            Console.WriteLine("  Indique o autor do novo livro: ");
            autor = Convert.ToString(Console.ReadLine());

            Console.WriteLine("  Indique o ISNB do novo livro");
            isbn = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("  Indique o género do novo livro: ");
            genero = Convert.ToString(Console.ReadLine());

            Console.WriteLine("  Indique o preço do novo livro");
            preco = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("  Indique o IVA (em %) do novo livro");
            iva = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("  Indique o stock do novo livro");
            stock = Convert.ToInt32(Console.ReadLine());
            

         

            // adicionar o livro conforme os dados escritos anteriormente pelo utilizador

                livros.Add(new livro(codigo, titulo, autor, isbn, genero, preco, iva, stock, vendidos, receita));

            }
            catch(FormatException)
            {
                Console.Clear();
                Console.WriteLine("****************************REGISTAR LIVRO***************************");
                Console.WriteLine("*********************************************************************");
                Console.WriteLine("Não introduziu os dados corretamente.");
                Console.WriteLine("Tente novamente: ");
                Thread.Sleep(2000);
                
                registar_livro_1(livros);
            }


        }

   


       


       

       
    
       

        public void comprar_livros_6(List<livro> livros)
        {
            try
            { 
            Console.Clear();
            Console.WriteLine("****************************COMPRAR LIVROS***************************");
            Console.WriteLine("*********************************************************************");
            int codigo;
          
         string titulo;
         string autor;
         int isbn;
         string genero;
         double preco;
         int iva;
         int stock;
            double receita = 0.00;
            int vendidos = 0;
        string resposta;
            int quantidade;
            bool encontrado = false;

        Console.WriteLine("  O livro que pretende comprar já se encontra no sistema? (S/N)");
            resposta = Convert.ToString(Console.ReadLine());

            if (resposta  != "S" && resposta != "N")
            {
                Console.WriteLine("  Não inseriu uma resposta válida.");
                Console.WriteLine("  Tente novamente: ");
                comprar_livros_6(livros);
            }

            if (resposta == "S")
            {
                Console.WriteLine("  Indique o código do livro: ");
                codigo = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("  Indique a quantidade que pretende comprar: ");
                quantidade = Convert.ToInt32(Console.ReadLine());

                foreach (livro livro in livros)
                {
                    if (livro.codigo == codigo)
                    {
                        encontrado = true;
                        livro.stock = livro.stock + quantidade;

                        Console.WriteLine("  O stock do livro cujo código é " + livro.codigo + " foi aumentado com sucesso e agora o seu stock é de " + livro.stock);
                    }
                }
                if (encontrado == false)
                {
                    Console.WriteLine("  Não foi encontrado nenhum livro com esse código no sistema. Tente novamente.");
                    comprar_livros_6(livros);
                }

            }

            if (resposta == "N")
            {

                // foreach para verificar quantos existem existem para adicionar o codigo ao novo livro
                int contagem = 0;
                foreach (livro livro in livros)
                {
                    contagem = contagem + 1;
                }
               
                codigo = contagem +1;

                Console.WriteLine("  Indique o titulo do livro que pretende comprar");
                titulo = Convert.ToString(Console.ReadLine());

                Console.WriteLine("  Indique o autor do livro que pretende comprar");
                autor = Convert.ToString(Console.ReadLine());

                Console.WriteLine("  Indique o ISBN do livro que pretende comprar: ");
                isbn = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("  Indique o género do livro que pretende comprar: ");
                genero = Convert.ToString(Console.ReadLine());

                Console.WriteLine("  Indique o preco do livro que pretende comprar: ");
                preco = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("  Indique o IVA do livro que pretende comprar: ");
                iva = Convert.ToInt32(Console.ReadLine());


                Console.WriteLine("  Indique a quantidade de livros que pretende comprar: ");
                stock = Convert.ToInt32(Console.ReadLine()); 

                foreach (livro livro in livros)
                {
                    if (livro.codigo == codigo)
                    {
                        encontrado = true;
                        livro.codigo = codigo;
                        livro.titulo = titulo;
                        livro.autor = autor;
                        livro.isbn = isbn;
                        livro.genero = genero;
                        livro.preco = preco;
                        livro.iva = iva;

                        livro.stock = stock;
                        livro.vendidos = vendidos;
                    }
                }
                livros.Add(new livro(codigo, titulo, autor, isbn, genero, preco, iva, stock, vendidos, receita));

     
            }
            }
            catch(FormatException)
            {
                Console.Clear();
                Console.WriteLine("****************************COMPRAR LIVROS***************************");
                Console.WriteLine("*********************************************************************");
                Console.WriteLine("Não introduziu os dados corretamente.");
                Console.WriteLine("Tente novamente: ");
                Thread.Sleep(2000);
                
                comprar_livros_6(livros);
            }



        }




    }
}
