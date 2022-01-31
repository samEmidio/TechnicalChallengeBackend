using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Domain.Core.Entity;
using TechnicalChallenge.Domain.Entities;
using TechnicalChallenge.Infra.CrossCutting.Security.Model;
using TechnicalChallenge.Infra.Data.Mappings;

namespace TechnicalChallenge.Infra.Data.Context
{
    public class TechnicalChallengeContext : DbContext
    {

        private readonly IConfiguration _config;
        private readonly LoggedUser _loggedUser;

        public TechnicalChallengeContext(DbContextOptions<TechnicalChallengeContext> options,IConfiguration config,LoggedUser loggedUser) : base(options)
        {
            _config = config;
            _loggedUser = loggedUser;
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventUser> EventUsers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new EventMap());
            modelBuilder.ApplyConfiguration(new EventUserMap());


            base.OnModelCreating(modelBuilder);
        }



        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            

            options.UseSqlServer(
                _config.GetConnectionString("DefaultConnection"),
                x => x.MigrationsHistoryTable("technical_challenge_migrationsLog"));

        }


        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified
                        || e.State == EntityState.Deleted));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedBy = _loggedUser.Id;
                ((BaseEntity)entityEntry.Entity).UpdateDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreateDate = DateTime.Now;
                    ((BaseEntity)entityEntry.Entity).CreatedBy = _loggedUser.Id;
                }

            }

            return base.SaveChanges();
        }

    }


}
