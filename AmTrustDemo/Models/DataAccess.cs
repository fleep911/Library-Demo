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

        public List<Book> GetBooksByAuthor()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("Books_DB")))
            {
                //return connection.Query<Book>($"select * from Books").ToList();
                return connection.Query<Book>("dbo.spGet_BookByAuthor").ToList();
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

        public List<Author> AuthorCreate(string authorFirstName, string authorLastName)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("Books_DB")))
            {
                List<Author> authors = new List<Author>();
                connection.Query<Author>($"INSERT INTO dbo.Authors(AuthorFirstName,AuthorLastName)VALUES(@AuthorFirstName,@AuthorLastName)", new { authorFirstName, authorLastName });

                //authors.Add(new Author { id = AuthorId, AuthorFirstName = authorFirstName, AuthorLastName = authorLastName,StatementType = statementType});
                //connection.Execute("dbo.spMaster_AuthorById @AuthorId @AuthorFirstName @AuthorLastName @StatementType", authors);
                return authors;

            }
        }
        public List<Author> AuthorUpdate(int AuthorId, string AuthorFirstName, string AuthorLastName)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("Books_DB")))
            {
                List<Author> authors = new List<Author>();

                connection.Query<Author>($"UPDATE dbo.Authors SET AuthorFirstName = @AuthorFirstName, AuthorLastName = @AuthorLastName WHERE id = @AuthorId", new { AuthorFirstName, AuthorLastName, AuthorId });
                return authors;

            }
        }


        public void AuthorDelete(int AuthorId)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("Books_DB")))
            {
                var output = connection.Execute($"DELETE FROM dbo.Authors WHERE id = @AuthorID", new { AuthorId });

                //authors.Add(new Author { id = AuthorId, AuthorFirstName = authorFirstName, AuthorLastName = authorLastName,StatementType = statementType});
                //connection.Execute("dbo.spMaster_AuthorById @AuthorId @AuthorFirstName @AuthorLastName @StatementType", authors);

            }
        }

        public List<Author> GetAuthorById(int AuthorId)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("Books_DB")))
            {
                //return connection.Query<Book>($"select * from Books").ToList();
                return connection.Query<Author>("dbo.spGet_AuthorById @AuthorId" , new { AuthorId }).ToList();
            }
        }
    }
}