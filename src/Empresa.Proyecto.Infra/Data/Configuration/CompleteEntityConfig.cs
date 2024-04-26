using Empresa.Proyecto.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Empresa.Proyecto.Infra.Data.Configuration
{
    public class CompleteEntityConfig : IEntityTypeConfiguration<CompleteEntity>
    {
        public void Configure(EntityTypeBuilder<CompleteEntity> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(50);

            builder.HasOne(d => d.SimpleEntity)
               .WithMany(p => p.CompleteEntity)
               .HasForeignKey(d => d.SimpleEntityId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_CompleteEntity_SimpleEntity");
        }
    }
}