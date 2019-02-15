using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SonicParks.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicParks.Core.Infrastructure.Data.Mappings {

    public class UserEmailMap : IEntityTypeConfiguration<UserEmailEntity> {

        public void Configure(EntityTypeBuilder<UserEmailEntity> builder) {

            #region Table Definitions

            builder.ToTable("UsersEmails");
            builder.HasKey(k => new { k.EmailID, k.UserID });

            #endregion

            #region Properties

            builder.Property(p => p.EmailID)
                .HasColumnName("EmailID");

            builder.Property(p => p.UserID)
                .HasColumnName("UserID");

            #endregion

            #region Relationships

            builder.HasOne(m => m.User)
                .WithMany(m => m.UsersEmails);

            builder.HasOne(m => m.Email)
                .WithMany(m => m.UsersEmails);

            #endregion

            #region Ignored


            #endregion

        }

    }

}
