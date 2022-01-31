using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Domain.Core.Entity;

namespace TechnicalChallenge.Infra.Data.Mappings
{
    public abstract class AuditEntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : AuditEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(c => c.CreateDate)
                   .HasColumnType("date")
                   .HasColumnName("create")
                   .IsRequired();

            builder.Property(c => c.CreatedBy)
                   .HasColumnName("created_by")
                   .IsRequired();

            builder.Property(c => c.UpdateDate)
                   .HasColumnType("date")
                   .HasColumnName("update");

            builder.Property(c => c.UpdatedBy)
                   .HasColumnName("updated_by");
        }
    }
}
