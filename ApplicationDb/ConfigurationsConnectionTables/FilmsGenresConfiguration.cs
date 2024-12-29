using ApiCursoEntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCursoEntityFrameworkCore.ApplicationDb.ConfigurationsConnectionTables
{
    public class FilmsGenresConfiguration : IEntityTypeConfiguration<FilmsGenres>
    {
        public void Configure(EntityTypeBuilder<FilmsGenres> builder)
        {
            //Crear clave compuesta
            builder.HasKey(prop => new { prop.FilmId, prop.GenreId });
        }
    }
}
