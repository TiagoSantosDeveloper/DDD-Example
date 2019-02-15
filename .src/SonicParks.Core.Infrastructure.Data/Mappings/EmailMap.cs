using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SonicParks.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicParks.Core.Infrastructure.Data.Mappings {

    public class EmailMap : IEntityTypeConfiguration<EmailEntity> {

        public void Configure(EntityTypeBuilder<EmailEntity> builder) {

            #region Table Definitions

            builder.ToTable("Emails");
            builder.HasKey(k => k.EmailID);

            #endregion

            #region Properties

            builder.Property(p => p.EmailID)
                .HasColumnName("EmailID")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Active)
                .HasColumnName("Active");

            builder.Property(p => p.Email)
                .HasColumnName("Email");

            #endregion

            #region Relationships

            builder.HasMany(m => m.UsersEmails)
                .WithOne(m => m.Email);

            #endregion

            #region Ignored


            #endregion

        }

    }

}
