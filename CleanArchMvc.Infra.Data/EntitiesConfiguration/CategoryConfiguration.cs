using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(t => t.Id);

            // Corrige a forma padrão do entity de gravar string no banco.
            // Por padrão, grava string com tamanho máximo e permite nulos.
            // Alterado para tamanho 100 e não-nulo.
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();


            // Para popular Category, quando executar a migration. Adiciona estes registros.
            builder.HasData(
              new Category(1, "Material Escolar"),
              new Category(2, "Eletrônicos"),
              new Category(3, "Acessórios")
            );
        }

    }
}
