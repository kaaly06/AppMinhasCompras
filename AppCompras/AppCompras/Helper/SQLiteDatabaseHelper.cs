using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppCompras.Model;
using SQLite;

namespace AppCompras.Helper
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _connection;

        public SQLiteDatabaseHelper(string path) //preparando o contrutor para quando chamarmos ele,ele abra a conexão
        {
            _connection = new SQLiteAsyncConnection(path);
            _connection.CreateTableAsync<Produto>().Wait();
        }
        public Task<int> Insert(Produto p)
        {
            return _connection.InsertAsync(p);
        }

        public Task<List<Produto>> Update(Produto p)
        {
            string sql = "UPTADE Produto SET descricao=?, quantidade=?, preco=? WHERE id= ?";
            return _connection.QueryAsync<Produto>(sql, p.descricao, p.quantidade, p.preco, p.id);
        }

        /** public Task<Produto> getByid(int id)
       {
           return new Produto();
       }
        */

        public Task<List<Produto>> GetAll()
        {
            return _connection.Table<Produto>().ToListAsync();
        }


        public Task<int> Delete(int id)
        {
            return _connection.Table<Produto>().DeleteAsync(i => i.id == id);
        }

        public Task<List<Produto>> Search(string q)
        {
            string sql = "SELECT * FROM Produto WHERE descricao LIKE '%" + q + "%' ";

            return _connection.QueryAsync<Produto>(sql);
        }
    }
}
