﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechnicalChallenge.Infra.Data.Context;

#nullable disable

namespace TechnicalChallenge.Infra.Data.Migrations
{
    [DbContext(typeof(TechnicalChallengeContext))]
    [Migration("20220131133354_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TechnicalChallenge.Domain.Entities.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UniqueIdentifier")
                        .HasColumnName("id");

                    b.Property<string>("AdditionalInformation")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("additional_information");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("date")
                        .HasColumnName("create");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("created_by");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("date")
                        .HasColumnName("update");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("updated_by");

                    b.HasKey("Id");

                    b.ToTable("technical_challenge_event", (string)null);
                });

            modelBuilder.Entity("TechnicalChallenge.Domain.Entities.EventUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UniqueIdentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("date")
                        .HasColumnName("create");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("created_by");

                    b.Property<Guid>("EventId")
                        .HasColumnType("UniqueIdentifier")
                        .HasColumnName("event_id");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit")
                        .HasColumnName("is_paid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("date")
                        .HasColumnName("update");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("updated_by");

                    b.Property<double>("Value")
                        .HasColumnType("float")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("technical_challenge_event_user", (string)null);
                });

            modelBuilder.Entity("TechnicalChallenge.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UniqueIdentifier")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("date")
                        .HasColumnName("create");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("created_by");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("last_name");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<string>("Pass")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("password");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("date")
                        .HasColumnName("update");

                    b.Property<Guid>("UpdatedBy")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("updated_by");

                    b.HasKey("Id");

                    b.ToTable("technical_challenge_user", (string)null);
                });

            modelBuilder.Entity("TechnicalChallenge.Domain.Entities.EventUser", b =>
                {
                    b.HasOne("TechnicalChallenge.Domain.Entities.Event", null)
                        .WithMany("EventUsers")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TechnicalChallenge.Domain.Entities.Event", b =>
                {
                    b.Navigation("EventUsers");
                });
#pragma warning restore 612, 618
        }
    }
}