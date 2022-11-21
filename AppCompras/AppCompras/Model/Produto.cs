using System;
using System.Collections.Generic;
using System.Text;
using SQLite; 

namespace AppCompras.Model
{
    public class Produto
    {
        public int id { get; set; }         

        public string descricao { get; set; }

        public double quantidade { get; set; } 

        public double preco { get; set; }

    }
}
