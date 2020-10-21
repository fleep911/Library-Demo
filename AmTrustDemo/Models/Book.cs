using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace AmTrustDemo.Models
{
    public class Book
    {
        public int id { get; set; }
        public string BookName { get; set; }
        public int AuthorId { get; set; }
        public DateTime DateCreated { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
    }
}