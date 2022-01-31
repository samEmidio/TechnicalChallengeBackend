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
    public class EventMap : BaseEntityMap<Event>
    {

        public override void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("technical_challenge_event");

            builder.Property(c => c.Date)
                .HasColumnType("varchar(255)")
                .HasColumnName("date")
                .IsRequired();

            builder.Property(c => c.Description)
                .HasColumnType("varchar(255)")
                .HasColumnName("description")
                .IsRequired();

            builder.Property(c => c.AdditionalInformation)
                .HasColumnType("varchar(255)")
                .HasColumnName("additional_information");



            base.Configure(builder, "event");
        }

    }
}
