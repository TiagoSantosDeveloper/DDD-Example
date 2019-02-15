using Microsoft.EntityFrameworkCore;
using SonicParks.Core.Domain.Entities;
using SonicParks.Core.Infrastructure.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicParks.Core.Infrastructure.Data.Contexts {

    public class SonicParksNexContext : BaseContext {

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<EmailEntity> Emails { get; set; }
        public DbSet<UserEmailEntity> UsersEmails { get; set; }

        public SonicParksNexContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new EmailMap());
            modelBuilder.ApplyConfiguration(new UserEmailMap());

            base.OnModelCreating(modelBuilder);

        }

    }

}