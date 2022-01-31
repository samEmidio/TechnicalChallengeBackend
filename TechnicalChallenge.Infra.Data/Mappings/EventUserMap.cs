using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Domain.Entities;

namespace TechnicalChallenge.Infra.Data.Mappings
{
    public class EventUserMap : BaseEntityMap<EventUser>
    {

        public override void Configure(EntityTypeBuilder<EventUser> builder)
        {
            builder.ToTable("technical_challenge_event_user");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(255)")
                .HasColumnName("name")
                .IsRequired();

            builder.Property(c => c.Value)
                .HasColumnType("float")
                .HasColumnName("value")
                .IsRequired();

            builder.Property(c => c.IsPaid)
                .HasColumnName("is_paid")
                .IsRequired();

            builder.Property(c => c.EventId)
                .HasColumnName("event_id")
                .IsRequired();





            base.Configure(builder, "event_user");
        }

    }
}
