namespace EF_CODE_FIRST.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using EF_CODE_FIRST.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<EF_CODE_FIRST.Context.BooksContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EF_CODE_FIRST.Context.BooksContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var libros = new List<Books>()
            {
                new Books(){Title = "HP y la piedra filosofal", Author = "J.K Rowling"},
                new Books(){Title = "EF Code First", Author = "Rowan Miller"}
            };
            libros.ForEach(x => context.Books.Add(x));
            context.SaveChanges();
        }
    }
}
