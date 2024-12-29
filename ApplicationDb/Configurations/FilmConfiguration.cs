using ApiCursoEntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCursoEntityFrameworkCore.ApplicationDb.Configurations
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {

            builder.Property(prop => prop.Title)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(prop => prop.PremiereDate);

            //Se usa donde vamos a meter una informacion que el usuario no pueda meter
            //Como esta informacion es para url no es necesario que sea unicode
            builder.Property(prop => prop.Poster)
                .HasMaxLength(500)
                .IsUnicode(false);
        }
    }
}
