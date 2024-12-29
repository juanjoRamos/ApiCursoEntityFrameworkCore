using ApiCursoEntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCursoEntityFrameworkCore.ApplicationDb.Configurations
{
    public class PeopleConfiguration : IEntityTypeConfiguration<People>
    {
        public void Configure(EntityTypeBuilder<People> builder)
        {
            //De esta manera podemos configurar cual es la primarykey de la tabla
            builder.HasKey(prop => prop.Id);
        }
    }
}
