using ApiCursoEntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCursoEntityFrameworkCore.ApplicationDb.Configurations
{
    public class OfferMovieConfiguration : IEntityTypeConfiguration<OfferMovie>
    {
        public void Configure(EntityTypeBuilder<OfferMovie> builder)
        {
            builder.Property(prop => prop.PercentageDiscount)
                .HasPrecision(precision: 5, scale: 2);
        }
    }
}
