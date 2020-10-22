using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using Dapper;


namespace AmTrustDemo.Models
{
    public class DataAccess
    {
        /// <summary>
        /// returns all books from the database 
        /// </summary>
        /// <returns></returns>
        public List<Book> GetBooks()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("Books_DB")))
            {
                return connection.Query<Book>("dbo.spBook_GET").ToList();
            }
        }

        /// <summary>
        /// returns all books sorted by author from the database
        /// </summary>
        /// <returns></returns>
        public List<Book> GetBooksByAuthor()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("Books_DB")))
            {
                return connection.Query<Book>("dbo.spBook_GET_ByAuthor").ToList();
            }
        }

        /// <summary>
        /// returns book basted on the BookId
        /// </summary>
        /// <param name="Bookid"></param>
        /// <returns></returns>
        public List<Book> GetBookById(int Bookid)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("Books_DB")))
            {
                var output = connection.Query<Book>("dbo.spBook_GET_ById @BookId", new { Bookid }).ToList();
                return output;
            }

        }

        /// <summary>
        /// inserts book data into the database
        /// </summary>
        /// <param name="BookName"></param>
        /// <param name="AuthorId"></param>
        /// <returns></returns>
        public List<Book> BookCreate(string BookName, int AuthorId)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("Books_DB")))
            {
                List<Book> books = new List<Book>();
                //connection.Query<Book>($"INSERT INTO dbo.Books(BookName, AuthorID)VALUES(@BookName,@AuthorId)", new { BookName, AuthorId });
                connection.Query<Book>("dbo.spBook_INSERT @BookName, @AuthorId", new { BookName, AuthorId });
                return books;
            }
        }

        /// <summary>
        /// updates the book data in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="BookName"></param>
        /// <param name="AuthorId"></param>
        /// <returns></returns>
        public List<Book> BookUpdate(int id, string BookName, int AuthorId)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("Books_DB")))
            {
                List<Book> books = new List<Book>();
                //connection.Query<Book>($"UPDATE dbo.Books SET BookName = @BookName, AuthorId = @AuthorId WHERE id = @Id", new { BookName, AuthorId, id });
                connection.Query<Book>("dbo.spBook_UPDATE @BookName, @AuthorId, @id", new { BookName, AuthorId, id });

                return books;

            }
        }

        /// <summary>
        /// removes book data from the database
        /// </summary>
        /// <param name="BookId"></param>
        public void BookDelete(int BookId)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("Books_DB")))
            {
                //var output = connection.Execute($"DELETE FROM dbo.Books WHERE id = @BookID", new { BookId });
                var output = connection.Execute("dbo.spBook_DELETE @BookId", new { BookId });

            }
        }


        /// <summary>
        /// returns all author data from the database
        /// </summary>
        /// <returns></returns>
        public List<Author> GetAuthor()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("Books_DB")))
            {
                return connection.Query<Author>("dbo.spAuthor_GET").ToList();
            }
        }

        /// <summary>
        /// returns all author first and last name data from the database
        /// </summary>
        /// <returns></returns>
        public List<Author> GetAuthorFullName()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("Books_DB")))
            {
                return connection.Query<Author>("dbo.spAuthor_GET_FullName").ToList();
            }
        }

        /// <summary>
        /// adds author data to the database
        /// </summary>
        /// <param name="authorFirstName"></param>
        /// <param name="authorLastName"></param>
        /// <returns></returns>
        public List<Author> AuthorCreate(string authorFirstName, string authorLastName)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("Books_DB")))
            {
                List<Author> authors = new List<Author>();
                //connection.Query<Author>($"INSERT INTO dbo.Authors(AuthorFirstName,AuthorLastName)VALUES(@AuthorFirstName,@AuthorLastName)", new { authorFirstName, authorLastName });
                connection.Query<Book>("dbo.spAuthor_INSERT @AuthorFirstName, @AuthorLastName", new { authorFirstName, authorLastName });

                return authors;

            }
        }

        /// <summary>
        /// updates author data to the database
        /// </summary>
        /// <param name="AuthorId"></param>
        /// <param name="AuthorFirstName"></param>
        /// <param name="AuthorLastName"></param>
        /// <returns></returns>
        public List<Author> AuthorUpdate(int AuthorId, string AuthorFirstName, string AuthorLastName)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("Books_DB")))
            {
                List<Author> authors = new List<Author>();
                //connection.Query<Author>($"UPDATE dbo.Authors SET AuthorFirstName = @AuthorFirstName, AuthorLastName = @AuthorLastName WHERE id = @AuthorId", new { AuthorFirstName, AuthorLastName, AuthorId });
                connection.Query<Book>("dbo.spAuthor_UPDATE @AuthorFirstName, @AuthorLastName, @AuthorId", new { AuthorFirstName, AuthorLastName, AuthorId });
                return authors;

            }
        }

        /// <summary>
        /// removes author data from the database
        /// </summary>
        /// <param name="AuthorId"></param>
        public void AuthorDelete(int AuthorId)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("Books_DB")))
            {
                var output = connection.Execute($"DELETE FROM dbo.Authors WHERE id = @AuthorID", new { AuthorId });
                //var output = connection.Execute("dbo.spAuthor_DELETE @AuthorId", new { AuthorId });

            }
        }

        /// <summary>
        /// returns author data based on the AuthorId
        /// </summary>
        /// <param name="AuthorId"></param>
        /// <returns></returns>
        public List<Author> GetAuthorById(int AuthorId)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("Books_DB")))
            {
                return connection.Query<Author>("dbo.spAuthor_GET_ById @AuthorId", new { AuthorId }).ToList();
            }
        }

    }
}