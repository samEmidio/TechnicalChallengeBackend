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
    public abstract class BaseEntityMap <TEntity> : AuditEntityMap<TEntity> where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder, string entityName)
        {
            builder.Property(c => c.Id)
                   .HasColumnName("id")
                   .HasColumnType("UniqueIdentifier");


            base.Configure(builder);
        }
    }
}
