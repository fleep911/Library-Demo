using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;


namespace AmTrustDemo.Models
{
    public class DataAccess
    {
        public List<Book> GetBooks()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("Books_DB")))
            {
                //return connection.Query<Book>($"select * from Books").ToList();
                return connection.Query<Book>("dbo.spGet_Book").ToList();
            }
        }

        public List<Book> GetBookById(int Bookid)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("Books_DB")))
            {
                //var output =  connection.Query<Book>($"select * from Books where id = '{Bookid}'").ToList();
                var output = connection.Query<Book>("dbo.spGet_BookById @BookId", new { Bookid }).ToList();
                return output;
            }

        }

        public List<Author> GetAuthor()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("Books_DB")))
            {
                //return connection.Query<Book>($"select * from Books").ToList();
                return connection.Query<Author>("dbo.spGet_Author").ToList();
            }
        }
    }
}