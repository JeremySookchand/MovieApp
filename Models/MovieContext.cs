 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MovieApp.Models
{
    public class MovieContext: DbContext
    {
        public MovieContext() : base("Movie2022")
        {

        }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<MembershipType> MembershipTypes { get; set; }

        public virtual DbSet<Genre> Genres { get; set; }


    }
}