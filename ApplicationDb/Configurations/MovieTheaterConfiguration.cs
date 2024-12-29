using ApiCursoEntityFrameworkCore.Entities;
using ApiCursoEntityFrameworkCore.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCursoEntityFrameworkCore.ApplicationDb.Configurations
{
    public class MovieTheaterConfiguration : IEntityTypeConfiguration<MovieTheater>
    {
        public void Configure(EntityTypeBuilder<MovieTheater> builder)
        {
            builder.Property(prop => prop.Price)
            .HasPrecision(9, 2);

            builder.Property(prop => prop.TypeMovieTheater)
                .HasDefaultValue(TypeMovieTheater.dimensions2);
        }
    }
}
