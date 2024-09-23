using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
namespace TRABALHO
{

    internal class Program
    {
       

        static void Main(string[] args)
        {
 

        // Criando uma lista para armazenar funcionários (classe base)

        List<funcionario> funcionarios = new List<funcionario>
        {
            new caixa(1, "souojoao", "João"),
            new repositor(2, "souoartur", "Artur"),
            new gerente(3, "souumgerente", "Carlos"),
            new caixa(4, "daniel", "João")
        };

            List<livro> livros = new List<livro>
        {
            new livro(1, "All About Love", "bell hooks", 95632, "Não ficção", 20, 23, 5, 0, 0),
            new livro(2, "A Viagem das Almas", "Michael Newton", 97886, "Literário", 30, 23, 3, 0, 0),
            new livro(3, "The Hunger Games", "Suzzane Collins", 97346, "Aventura", 40, 23, 1, 0, 0)
        };

            List <int>vendas = new List<int>();


            bool loginSucesso = Login(funcionarios, livros, vendas);

           
        }

        static bool Login(List<funcionario> funcionarios, List<livro> livros, List<int>vendas)
        {

            Console.Clear();
            bool login = false;

            while (!login)
            {
                try
                {
                    Console.WriteLine("*******************************LOGIN*********************************");

                    Console.WriteLine("*********************************************************************");
                    Console.WriteLine("  ID: ");
                    int username = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("  PASSWORD: ");
                    string password = Convert.ToString(Console.ReadLine());

                    //verifica se existe um funcionario com aquele username e aquela password

                    foreach (funcionario funcionario in funcionarios)
                    {
                        if (funcionario.id == username && funcionario.password == password)
                        {
                            login = true;
                            //abre o menu dependendo da sua classe
                            if (funcionario is gerente)
                            {
                                menu_gerente(funcionario, livros, funcionarios, vendas);
                                break;
                            }
                            if (funcionario is caixa)
                            {
                                menu_caixa(funcionario, livros, funcionarios, vendas);
                                break;
                            }
                            if (funcionario is repositor)
                            {
                                menu_repositor(funcionario, livros, funcionarios, vendas);
                                break;
                            }

                        }
                    }

                    if (!login)
                    {
                        Console.Clear();
                        Console.WriteLine("\n  Utilizador ou senha incorreto. Tente novamente.");
                        Console.WriteLine("");


                    }
                }
                catch(FormatException)
                {
                    Login(funcionarios, livros, vendas);
                }

}
            
            return login;
        }

        static void menu_gerente(funcionario funcionario, List<livro> livros, List<funcionario> funcionarios, List<int>vendas)
        {
            try
            {
                int opcao;
                Console.Clear();
                Console.WriteLine("*********************************************************************");
                Console.WriteLine("  NOME: " + funcionario.nome + "                                                 " + "ID: " + funcionario.id);
                Console.WriteLine("*********************************************************************");
                Console.WriteLine("");
                Console.WriteLine("****************************MENU GERENTE*****************************");
                Console.WriteLine("*********************************************************************");
                Console.WriteLine("  1- ATUALIZAR LIVRO");   //feito
                Console.WriteLine("  2- CONSULTAR A INFORMAÇÃO DO LIVRO A PARTIR DO CÓDIGO"); //feito
                Console.WriteLine("  3- LISTAR LIVROS PELO GÉNERO");   //feito
                Console.WriteLine("  4- LISTAR LIVROS PELO AUTOR");   //feito
                Console.WriteLine("  5- LISTAR OS UTILIZADORES");  //feito
                Console.WriteLine("  6- VENDER LIVROS");     //feito
                Console.WriteLine("  7- CONSULTAR STOCK");   //feito
                Console.WriteLine("  8- CONSULTAR O TOTAL DE LIVROS VENDIDOS E A RESPETIVA RECEITA");   //feito
                Console.WriteLine("  9- CRIAR FUNCIONÁRIO");  //feito
                Console.WriteLine("  10- ELIMINAR FUNCIONÁRIO");  //feito
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("  0- LOGOUT");  //feito
                Console.WriteLine("  99- SAIR");
                Console.WriteLine("*********************************************************************");
                Console.WriteLine("SELECIONE UMA OPÇÃO:");
                Console.WriteLine("*********************************************************************");

                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 0:
                        Login(funcionarios, livros, vendas);
                        break;
                    case 1:
                        gerente gerenteLogado1 = (gerente)funcionario; // onde 'funcionario' é o objeto que fez login e é do tipo gerente
                        gerenteLogado1.editar_livro(livros);
                        //voltar ao menu
                        int op1;
                        Console.WriteLine("");

                        Console.WriteLine("  0- VOLTAR AO MENU");
                        Console.WriteLine("  99- SAIR");
                        Console.WriteLine("*********************************************************************");
                        Console.WriteLine("*********************************************************************");
                        op1 = Convert.ToInt32(Console.ReadLine());
                        switch (op1)
                        {
                            case 0:
                                menu_gerente(funcionario, livros, funcionarios, vendas);
                                break;
                            case 99:
                                Environment.Exit(0);

                                break;
                            default:
                                gerenteLogado1.editar_livro(livros);

                                break;
                        }

                        break;

                    case 2:
                        gerente gerenteLogado2 = (gerente)funcionario; // onde 'funcionario' é o objeto que fez login e é do tipo gerente
                        gerenteLogado2.consultar_livro(livros);
                        //voltar ao menu
                        int op2;
                        Console.WriteLine("");

                        Console.WriteLine("  0- VOLTAR AO MENU");
                        Console.WriteLine("  99- SAIR");
                        Console.WriteLine("*********************************************************************");
                        Console.WriteLine("*********************************************************************");
                        op2 = Convert.ToInt32(Console.ReadLine());
                        switch (op2)
                        {
                            case 0:
                                menu_gerente(funcionario, livros, funcionarios, vendas);
                                break;
                            case 99:
                                Environment.Exit(0);

                                break;
                            default:
                                gerenteLogado2.consultar_livro(livros);
                                break;
                        }

                        break;

                    case 3:
                        gerente gerenteLogado3 = (gerente)funcionario; // onde 'funcionario' é o objeto que fez login e é do tipo gerente
                        gerenteLogado3.consultar_livro2(livros);
                        //voltar ao menu
                        int op3;
                        Console.WriteLine("");

                        Console.WriteLine("  0- VOLTAR AO MENU");
                        Console.WriteLine("  99- SAIR");
                        Console.WriteLine("*********************************************************************");
                        Console.WriteLine("*********************************************************************");
                        op3 = Convert.ToInt32(Console.ReadLine());
                        switch (op3)
                        {
                            case 0:
                                menu_gerente(funcionario, livros, funcionarios, vendas);
                                break;
                            case 99:
                                Environment.Exit(0);

                                break;
                            default:
                                gerenteLogado3.consultar_livro2(livros);

                                break;
                        }
                        break;
                    case 4:
                        gerente gerenteLogado4 = (gerente)funcionario; // onde 'funcionario' é o objeto que fez login e é do tipo gerente
                        gerenteLogado4.consultar_livro3(livros);

                        //voltar ao menu
                        int op4;
                        Console.WriteLine("");

                        Console.WriteLine("  0- VOLTAR AO MENU");
                        Console.WriteLine("  99- SAIR");
                        Console.WriteLine("*********************************************************************");
                        Console.WriteLine("*********************************************************************");
                        op4 = Convert.ToInt32(Console.ReadLine());
                        switch (op4)
                        {
                            case 0:
                                menu_gerente(funcionario, livros, funcionarios, vendas);
                                break;
                            case 99:
                                Environment.Exit(0);

                                break;
                            default:
                                gerenteLogado4.consultar_livro3(livros);

                                break;
                        }
                        break;


                    case 5:
                        gerente gerenteLogado5 = (gerente)funcionario; // onde 'funcionario' é o objeto que fez login e é do tipo gerente
                        gerenteLogado5.listar_utilizadores_5(funcionarios);

                        //voltar ao menu
                        int op5;
                        Console.WriteLine("");

                        Console.WriteLine("  0- VOLTAR AO MENU");
                        Console.WriteLine("  99- SAIR");
                        Console.WriteLine("*********************************************************************");
                        Console.WriteLine("*********************************************************************");
                        op5 = Convert.ToInt32(Console.ReadLine());
                        switch (op5)
                        {
                            case 0:
                                menu_gerente(funcionario, livros, funcionarios, vendas);
                                break;
                            case 99:
                                Environment.Exit(0);

                                break;
                            default:
                                gerenteLogado5.listar_utilizadores_5(funcionarios);

                                break;
                        }
                        break;

                    case 6:
                        gerente gerenteLogado6 = (gerente)funcionario; // onde 'funcionario' é o objeto que fez login e é do tipo gerente
                        gerenteLogado6.vender_livro_6(livros);

                        //voltar ao menu
                        int op6;
                        Console.WriteLine("");

                        Console.WriteLine("  0- VOLTAR AO MENU");
                        Console.WriteLine("  99- SAIR");
                        Console.WriteLine("*********************************************************************");
                        Console.WriteLine("*********************************************************************");
                        op6 = Convert.ToInt32(Console.ReadLine());
                        switch (op6)
                        {
                            case 0:
                                menu_gerente(funcionario, livros, funcionarios, vendas);
                                break;
                            case 99:
                                Environment.Exit(0);
                                break;
                            default:
                                gerenteLogado6.vender_livro_6(livros);

                                break;

                        }
                        break;

                    case 7:
                        gerente gerenteLogado7 = (gerente)funcionario; // onde 'funcionario' é o objeto que fez login e é do tipo gerente
                        gerenteLogado7.consultar_stock_7(livros);
                        int op7;
                        Console.WriteLine("");

                        Console.WriteLine("  0- VOLTAR AO MENU");
                        Console.WriteLine("  99- SAIR");
                        Console.WriteLine("*********************************************************************");
                        Console.WriteLine("*********************************************************************");
                        op7 = Convert.ToInt32(Console.ReadLine());
                        switch (op7)
                        {
                            case 0:
                                menu_gerente(funcionario, livros, funcionarios, vendas);
                                break;
                            case 99:
                                Environment.Exit(0);

                                break;
                            default:
                                gerenteLogado7.consultar_stock_7(livros);

                                break;
                        }
                        break;

                    case 8:
                        gerente gerenteLogado8 = (gerente)funcionario; // onde 'funcionario' é o objeto que fez login e é do tipo gerente
                        gerenteLogado8.receita_gerada_8(livros);

                        //voltar ao menu
                        int op8;
                        Console.WriteLine("");

                        Console.WriteLine("  0- VOLTAR AO MENU");
                        Console.WriteLine("  99- SAIR");
                        Console.WriteLine("*********************************************************************");
                        Console.WriteLine("*********************************************************************");
                        op8 = Convert.ToInt32(Console.ReadLine());
                        switch (op8)
                        {
                            case 0:
                                menu_gerente(funcionario, livros, funcionarios, vendas);
                                break;
                            case 99:
                                Environment.Exit(0);

                                break;
                            default:
                                gerenteLogado8.receita_gerada_8(livros);

                                break;
                        }
                        break;

                    case 9:
                        gerente gerenteLogado9 = (gerente)funcionario; // onde 'funcionario' é o objeto que fez login e é do tipo gerente
                        gerenteLogado9.add_func_9(funcionarios);

                        //voltar ao menu
                        int op9;
                        Console.WriteLine("");

                        Console.WriteLine("  0- VOLTAR AO MENU");
                        Console.WriteLine("  99- SAIR");
                        Console.WriteLine("*********************************************************************");
                        Console.WriteLine("*********************************************************************");
                        op9 = Convert.ToInt32(Console.ReadLine());
                        switch (op9)
                        {
                            case 0:
                                menu_gerente(funcionario, livros, funcionarios, vendas);
                                break;
                            case 99:
                                Environment.Exit(0);

                                break;
                            default:
                                gerenteLogado9.add_func_9(funcionarios);

                                break;
                        }
                        break;



                    case 10:
                        gerente gerenteLogado10 = (gerente)funcionario; // onde 'funcionario' é o objeto que fez login e é do tipo gerente
                        gerenteLogado10.remove_func_10(funcionarios);

                        //voltar ao menu
                        int op10;
                        Console.WriteLine("");

                        Console.WriteLine("  0- VOLTAR AO MENU");
                        Console.WriteLine("  99- SAIR");
                        Console.WriteLine("*********************************************************************");
                        Console.WriteLine("*********************************************************************");
                        op10 = Convert.ToInt32(Console.ReadLine());
                        switch (op10)
                        {
                            case 0:
                                menu_gerente(funcionario, livros, funcionarios, vendas);
                                break;
                            case 99:
                                Environment.Exit(0);

                                break;
                            default:
                                gerenteLogado10.remove_func_10(funcionarios);

                                break;
                        }
                        break;

                    case 99:
                        Environment.Exit(0);
                        break;
              default:
                        menu_gerente(funcionario, livros, funcionarios, vendas);

                        break;
                
                }
                
            }
            catch(FormatException)
            {
                menu_gerente(funcionario, livros, funcionarios, vendas);
            }





        }

        static void menu_repositor(funcionario funcionario, List<livro> livros, List<funcionario> funcionarios, List<int>vendas)
        {
            try
            { 
            Console.Clear();

            int opcao;
            Console.WriteLine("*********************************************************************");
            Console.WriteLine("  NOME: " + funcionario.nome + "                                                 " + "ID: " + funcionario.id);
            Console.WriteLine("*********************************************************************");
            Console.WriteLine("");
            Console.WriteLine("****************************MENU REPOSITOR***************************");
            Console.WriteLine("*********************************************************************");

            Console.WriteLine("  1- REGISTAR LIVROS");   //feito
            Console.WriteLine("  2- ATUALIZAR LIVRO");  //feito
            Console.WriteLine("  3- CONSULTAR A INFORMAÇÃO DO LIVRO A PARTIR DO CÓDIGO");  //feito
            Console.WriteLine("  4- LISTAR LIVROS PELO GÉNERO");  //feito
            Console.WriteLine("  5- LISTAR LIVROS PELO AUTOR");  //feito
            Console.WriteLine("  6- COMPRAR LIVROS");   //feito
            Console.WriteLine("  7- CONSULTAR STOCK");  //feito
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("  0- LOGOUT");  //feito
            Console.WriteLine("  99- SAIR");   //feito
            Console.WriteLine("*********************************************************************");
            Console.WriteLine("SELECIONE UMA OPÇÃO:");

            Console.WriteLine("*********************************************************************");

            opcao = Convert.ToInt32(Console.ReadLine());

            switch (opcao)
            {
                case 0:
                    Login(funcionarios, livros, vendas);
                    break;
                case 1:
                    repositor repositorLogado1 = (repositor)funcionario; // onde 'funcionario' é o objeto que fez login e é do tipo repositor
                    repositorLogado1.registar_livro_1(livros);

                    //voltar ao menu
                    int op1;
                    Console.WriteLine("");

                    Console.WriteLine("  0- VOLTAR AO MENU");
                    Console.WriteLine("  99- SAIR");
                    Console.WriteLine("*********************************************************************");
                    Console.WriteLine("*********************************************************************");
                    op1 = Convert.ToInt32(Console.ReadLine());
                    switch (op1)
                    {
                        case 0:
                            menu_repositor(funcionario, livros, funcionarios, vendas);
                            break;
                        case 99:
                            Environment.Exit(0);

                            break;
                            default:
                                repositorLogado1.registar_livro_1(livros);

                                break;
                        }

                    break;
                case 2:
                    repositor repositorLogado2 = (repositor)funcionario; // onde 'funcionario' é o objeto que fez login e é do tipo repositor
                    repositorLogado2.editar_livro(livros);

                    //voltar ao menu
                    int op2;
                    Console.WriteLine("");

                    Console.WriteLine("  0- VOLTAR AO MENU");
                    Console.WriteLine("  99- SAIR");
                    Console.WriteLine("*********************************************************************");
                    Console.WriteLine("*********************************************************************");
                    op2 = Convert.ToInt32(Console.ReadLine());
                    switch (op2)
                    {
                        case 0:
                            menu_repositor(funcionario, livros, funcionarios, vendas);
                            break;
                        case 99:
                            Environment.Exit(0);

                            break;
                            default:
                                repositorLogado2.editar_livro(livros);

                                break;
                        }

                    break;


                case 3:
                    repositor repositorLogado3 = (repositor)funcionario; // onde 'funcionario' é o objeto que fez login e é do tipo repositor
                    repositorLogado3.consultar_livro(livros);

                    //voltar ao menu
                    int op3;
                    Console.WriteLine("");

                    Console.WriteLine("  0- VOLTAR AO MENU");
                    Console.WriteLine("  99- SAIR");
                    Console.WriteLine("*********************************************************************");
                    Console.WriteLine("*********************************************************************");
                    op3 = Convert.ToInt32(Console.ReadLine());
                    switch (op3)
                    {
                        case 0:
                            menu_repositor(funcionario, livros, funcionarios, vendas);
                            break;
                        case 99:
                            Environment.Exit(0);

                            break;
                            default:
                                repositorLogado3.consultar_livro(livros);

                                break;
                        }

                    break;


                case 4:
                    repositor repositorLogado4 = (repositor)funcionario; // onde 'funcionario' é o objeto que fez login e é do tipo repositor
                    repositorLogado4.consultar_livro2(livros);

                    //voltar ao menu
                    int op4;
                    Console.WriteLine("");

                    Console.WriteLine("  0- VOLTAR AO MENU");
                    Console.WriteLine("  99- SAIR");
                    Console.WriteLine("*********************************************************************");
                    Console.WriteLine("*********************************************************************");
                    op4 = Convert.ToInt32(Console.ReadLine());
                    switch (op4)
                    {
                        case 0:
                            menu_repositor(funcionario, livros, funcionarios, vendas);
                            break;
                        case 99:
                            Environment.Exit(0);

                            break;
                            default:
                                repositorLogado4.consultar_livro2(livros);

                                break;
                        }

                    break;

                case 5:
                    repositor repositorLogado5 = (repositor)funcionario; // onde 'funcionario' é o objeto que fez login e é do tipo repositor
                    repositorLogado5.consultar_livro3(livros);

                    //voltar ao menu
                    int op5;
                    Console.WriteLine("");

                    Console.WriteLine("  0- VOLTAR AO MENU");
                    Console.WriteLine("  99- SAIR");
                    Console.WriteLine("*********************************************************************");
                    Console.WriteLine("*********************************************************************");
                    op5 = Convert.ToInt32(Console.ReadLine());
                    switch (op5)
                    {
                        case 0:
                            menu_repositor(funcionario, livros, funcionarios, vendas);
                            break;
                        case 99:
                            Environment.Exit(0);

                            break;
                            default:
                                repositorLogado5.consultar_livro3(livros);

                                break;
                        }

                    break;


               

                case 6:
                    repositor repositorLogado6 = (repositor)funcionario; // onde 'funcionario' é o objeto que fez login e é do tipo repositor
                    repositorLogado6.comprar_livros_6(livros);

                    //voltar ao menu
                    int op6;
                    Console.WriteLine("");

                    Console.WriteLine("  0- VOLTAR AO MENU");
                    Console.WriteLine("  99- SAIR");
                    Console.WriteLine("*********************************************************************");
                    Console.WriteLine("*********************************************************************");
                    op6 = Convert.ToInt32(Console.ReadLine());
                    switch (op6)
                    {
                        case 0:
                            menu_repositor(funcionario, livros, funcionarios, vendas);
                            break;
                        case 99:
                            Environment.Exit(0);

                            break;
                  default:
                        repositorLogado6.comprar_livros_6(livros);

                        break;
                        }

                    break;
                   


                    case 7:
                    repositor repositorLogado7 = (repositor)funcionario; // onde 'funcionario' é o objeto que fez login e é do tipo repositor
                    repositorLogado7.consultar_stock_7(livros);

                    //voltar ao menu
                    int op7;
                    Console.WriteLine("");

                    Console.WriteLine("  0- VOLTAR AO MENU");
                    Console.WriteLine("  99- SAIR");
                    Console.WriteLine("*********************************************************************");
                    Console.WriteLine("*********************************************************************");
                    op7 = Convert.ToInt32(Console.ReadLine());
                    switch (op7)
                    {
                        case 0:
                            menu_repositor(funcionario, livros, funcionarios, vendas);
                            break;
                        case 99:
                            Environment.Exit(0);

                            break;
                            default:
                                repositorLogado7.consultar_stock_7(livros);

                                break;
                        }

                    break;
                  
                    default:
                        menu_repositor(funcionario, livros, funcionarios, vendas);

                        break;

                }

            }
            catch (FormatException)
            {
                menu_repositor(funcionario, livros, funcionarios, vendas);
            }

        
        }

        static void menu_caixa(funcionario funcionario, List<livro> livros, List<funcionario> funcionarios, List<int>vendas)
        {
            try
            {
                Console.Clear();

                int opcao;
                Console.WriteLine("*********************************************************************");
                Console.WriteLine("  NOME: " + funcionario.nome + "                                                 " + "ID: " + funcionario.id);
                Console.WriteLine("*********************************************************************");
                Console.WriteLine("");
                Console.WriteLine("******************************MENU CAIXA*****************************");
                Console.WriteLine("*********************************************************************");

                Console.WriteLine("  1- EDITAR LIVRO");  //feito
                Console.WriteLine("  2- CONSULTAR A INFORMAÇÃO DO LIVRO A PARTIR DO CÓDIGO");  //feito
                Console.WriteLine("  3- LISTAR LIVROS PELO GÉNERO");   //feito
                Console.WriteLine("  4- LISTAR LIVROS PELO AUTOR"); //feito
                Console.WriteLine("  5- VENDER LIVROS");   //feito
                Console.WriteLine("  6- CONSULTAR STOCK"); //feito
                Console.WriteLine("  7- CONSULTAR O TOTAL DE LIVROS VENDIDOS E RESPETIVA RECEITA");   //feito
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("  0- LOGOUT");   //feito
                Console.WriteLine("  99- SAIR");   //feito
                Console.WriteLine("*********************************************************************");
                Console.WriteLine("SELECIONE UMA OPÇÃO:");

                Console.WriteLine("*********************************************************************");
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 0:
                        Login(funcionarios, livros, vendas);
                        break;
                    case 1:
                        caixa caixaLogado1 = (caixa)funcionario; // onde 'funcionario' é o objeto que fez login e é do tipo caixa
                        caixaLogado1.editar_livro(livros);

                        //voltar ao menu
                        int op1;
                        Console.WriteLine("");

                        Console.WriteLine("  0- VOLTAR AO MENU");
                        Console.WriteLine("  99- SAIR");
                        Console.WriteLine("*********************************************************************");
                        Console.WriteLine("*********************************************************************");
                        op1 = Convert.ToInt32(Console.ReadLine());
                        switch (op1)
                        {
                            case 0:
                                menu_caixa(funcionario, livros, funcionarios, vendas);
                                break;
                            case 99:
                                Environment.Exit(0);
                                break;
                            default:
                                caixaLogado1.editar_livro(livros);

                                break;
                        }

                        break;

                    case 2:
                        caixa caixaLogado2 = (caixa)funcionario; // onde 'funcionario' é o objeto que fez login e é do tipo caixa
                        caixaLogado2.consultar_livro(livros);

                        //voltar ao menu
                        int op2;
                        Console.WriteLine("");

                        Console.WriteLine("  0- VOLTAR AO MENU");
                        Console.WriteLine("  99- SAIR");
                        Console.WriteLine("*********************************************************************");
                        Console.WriteLine("*********************************************************************");
                        op2 = Convert.ToInt32(Console.ReadLine());
                        switch (op2)
                        {
                            case 0:
                                menu_caixa(funcionario, livros, funcionarios, vendas);
                                break;
                            case 99:
                                Environment.Exit(0);

                                break;
                            default:
                                caixaLogado2.consultar_livro(livros);

                                break;
                        }

                        break;

                    case 3:
                        caixa caixaLogado3 = (caixa)funcionario; // onde 'funcionario' é o objeto que fez login e é do tipo caixa
                        caixaLogado3.consultar_livro2(livros);

                        //voltar ao menu
                        int op3;
                        Console.WriteLine("");

                        Console.WriteLine("  0- VOLTAR AO MENU");
                        Console.WriteLine("  99- SAIR");
                        Console.WriteLine("*********************************************************************");
                        Console.WriteLine("*********************************************************************");
                        op3 = Convert.ToInt32(Console.ReadLine());
                        switch (op3)
                        {
                            case 0:
                                menu_caixa(funcionario, livros, funcionarios, vendas);
                                break;
                            case 99:
                                Environment.Exit(0);

                                break;
                            default:
                                caixaLogado3.consultar_livro2(livros);

                                break;
                        }

                        break;


                    case 4:
                        caixa caixaLogado4 = (caixa)funcionario; // onde 'funcionario' é o objeto que fez login e é do tipo caixa
                        caixaLogado4.consultar_livro3(livros);

                        //voltar ao menu
                        int op4;
                        Console.WriteLine("");

                        Console.WriteLine("  0- VOLTAR AO MENU");
                        Console.WriteLine("  99- SAIR");
                        Console.WriteLine("*********************************************************************");
                        Console.WriteLine("*********************************************************************");
                        op4 = Convert.ToInt32(Console.ReadLine());
                        switch (op4)
                        {
                            case 0:
                                menu_caixa(funcionario, livros, funcionarios, vendas);
                                break;
                            case 99:
                                Environment.Exit(0);

                                break;
                            default:
                                caixaLogado4.consultar_livro3(livros);

                                break;
                        }

                        break;




                    case 5:
                        caixa caixaLogado5 = (caixa)funcionario; // onde 'funcionario' é o objeto que fez login e é do tipo caixa
                        caixaLogado5.vender_livro_5(livros, vendas);

                        //voltar ao menu
                        int op5;
                        Console.WriteLine("");

                        Console.WriteLine("  0- VOLTAR AO MENU");
                        Console.WriteLine("  99- SAIR");
                        Console.WriteLine("*********************************************************************");
                        Console.WriteLine("*********************************************************************");
                        op5 = Convert.ToInt32(Console.ReadLine());
                        switch (op5)
                        {
                            case 0:
                                menu_caixa(funcionario, livros, funcionarios, vendas);
                                break;
                            case 99:

                                break;
                            default:
                                caixaLogado5.vender_livro_5(livros, vendas);

                                break;
                        }
                        break;

                    case 6:
                        caixa caixaLogado6 = (caixa)funcionario; // onde 'funcionario' é o objeto que fez login e é do tipo caixa
                        caixaLogado6.consultar_stock_7(livros);

                        //voltar ao menu
                        int op6;
                        Console.WriteLine("");
                        Console.WriteLine("  0- VOLTAR AO MENU");
                        Console.WriteLine("  99- SAIR");
                        Console.WriteLine("*********************************************************************");
                        Console.WriteLine("*********************************************************************");
                        op6 = Convert.ToInt32(Console.ReadLine());
                        switch (op6)
                        {
                            case 0:
                                menu_caixa(funcionario, livros, funcionarios, vendas);
                                break;
                            case 99:
                                Environment.Exit(0);

                                break;
                            default:
                                caixaLogado6.consultar_stock_7(livros);

                                break;
                        }

                        break;

                    case 7:
                        caixa caixaLogado7 = (caixa)funcionario; // onde 'funcionario' é o objeto que fez login e é do tipo caixa
                        caixaLogado7.receita_gerada_7(livros);

                        //voltar ao menu
                        int op7;
                        Console.WriteLine("");
                        Console.WriteLine("  0- VOLTAR AO MENU");
                        Console.WriteLine("  99- SAIR");
                        Console.WriteLine("*********************************************************************");
                        Console.WriteLine("*********************************************************************");
                        op7 = Convert.ToInt32(Console.ReadLine());
                        switch (op7)
                        {
                            case 0:
                                menu_caixa(funcionario, livros, funcionarios, vendas);
                                break;
                            case 99:
                                Environment.Exit(0);

                                break;
                            default:
                                caixaLogado7.receita_gerada_7(livros);

                                break;
                        }

                        break;
                    case 99:
                        Environment.Exit(0);
                        break;
                    default:
                        menu_caixa(funcionario, livros, funcionarios, vendas);

                        break;

                }
            }

            catch (FormatException)
            {
                menu_caixa(funcionario, livros, funcionarios, vendas);
            }
        }



        /*  public void voltar_menu_gerente(funcionario funcionario, List<livro> livros, List<funcionario> funcionarios)
          {
              int op;

              Console.WriteLine("0- Voltar ao menu");
              op = Convert.ToInt32(Console.ReadLine());

              switch (op)
              {
                  case 0:
                      gerente gerenteLogado7 = (gerente)funcionario; // onde 'funcionario' é o objeto que fez login e é do tipo gerente
                      menu_gerente(funcionario, livros, funcionarios);
                      break;
          }
          } */



       



    }
    }





