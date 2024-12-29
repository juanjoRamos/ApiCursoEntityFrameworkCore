using ApiCursoEntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCursoEntityFrameworkCore.ApplicationDb.ConfigurationsConnectionTables
{
    public class FilmsMovieTheatersConfiguration : IEntityTypeConfiguration<FilmsMovieTheaters>
    {
        public void Configure(EntityTypeBuilder<FilmsMovieTheaters> builder)
        {
            //Crear clave compuesta
            builder.HasKey(prop => new { prop.FilmId, prop.MovieTheaterId });
        }
    }
}
