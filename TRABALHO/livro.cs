using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TRABALHO
{
    internal class livro
    {
        public int codigo;
        public string titulo;
        public string autor;
        public int isbn;
        public string genero;
        public double preco;
        public int iva;
        public int stock;
        public int vendidos;
        public double receita;




        public livro(int codigo, string titulo, string autor, int isbn, string genero, double preco, int iva, int stock, int vendidos, double receita)
        {
            this.codigo = codigo;
            this.titulo = titulo;   
            this.autor = autor;
            this.isbn = isbn;
            this.genero = genero;
            this.preco = preco;
            this.iva = iva;
            this.stock = stock;
            this.vendidos = vendidos;
            this.receita = receita;

        }
    }
}
