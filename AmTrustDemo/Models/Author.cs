﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmTrustDemo.Models
{
    public class Author
    {
        public int id { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}