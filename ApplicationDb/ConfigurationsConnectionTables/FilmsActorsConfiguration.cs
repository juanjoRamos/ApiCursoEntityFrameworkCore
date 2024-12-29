using ApiCursoEntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ApiCursoEntityFrameworkCore.ApplicationDb.ConfigurationsConnectionTables
{
    public class FilmsActorsConfiguration : IEntityTypeConfiguration<FilmsActors>
    {
        public void Configure(EntityTypeBuilder<FilmsActors> builder)
        {
            //Crear clave compuesta
            builder.HasKey(prop => new { prop.FilmId, prop.ActorId });

            builder.Property(prop => prop.Character)
                .HasMaxLength(150);
        }
    }
}
