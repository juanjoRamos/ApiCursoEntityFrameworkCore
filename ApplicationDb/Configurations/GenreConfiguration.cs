using ApiCursoEntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCursoEntityFrameworkCore.ApplicationDb.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            //Podemos poner limitaciones a los campos de distintas formas
            builder.Property(prop => prop.Name)
                .HasMaxLength(255)
                .IsRequired();

        }
    }
}
