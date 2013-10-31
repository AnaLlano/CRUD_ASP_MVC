using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using EF_CODE_FIRST.Models;

namespace EF_CODE_FIRST.Context
{
    public class BooksContext : DbContext 
    {
        public DbSet<Books> Books { get; set; }

        public DbSet<Reviews> Reviews { get; set; }

        public BooksContext():base("BooksConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
        }
    }
}