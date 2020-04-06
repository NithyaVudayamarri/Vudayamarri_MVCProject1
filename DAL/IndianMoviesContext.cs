using IndianMovies.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Vudayamarri_Project.DAL
{
    public class IndianMoviesContext : DbContext
    {

        public IndianMoviesContext() : base("IndianMoviesContext")
        {
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie_Acted> Movies_Acted { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}