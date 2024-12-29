using ApiCursoEntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ApiCursoEntityFrameworkCore.ApplicationDb
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<People> PeopleTable { get; set; }
        public DbSet<Genre> GenreTable { get; set; }
        public DbSet<Actor> ActorTable { get; set; }
        public DbSet<Movie> MovieTable { get; set; }
        public DbSet<Film> FilmTable { get; set; }
        public DbSet<OfferMovie> OfferMovieTable { get; set; }
        public DbSet<MovieTheater> MovieTheaterTable { get; set; }

        //Tablas de conexion entre tablas para guardar registros y estos sean de * a *
        public DbSet<FilmsActors> FilmsActorsTable { get; set; }
        public DbSet<FilmsGenres> FilmsGenreTable { get; set; }
        public DbSet<FilmsMovieTheaters> FilmsMovieTheaterTable { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //crear una convencion poner por defecto las fechas a tipo date
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(AssemblyBuilder.GetExecutingAssembly());
            modelBuilder.HasPostgresExtension("postgis");
            SeedingModulConsult.SeedingData.Seed(modelBuilder);
        }
    }
}
