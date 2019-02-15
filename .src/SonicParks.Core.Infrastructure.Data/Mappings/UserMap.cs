using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SonicParks.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicParks.Core.Infrastructure.Data.Mappings {

    public class UserMap : IEntityTypeConfiguration<UserEntity> {

        public void Configure(EntityTypeBuilder<UserEntity> builder) {

            #region Table Definitions

            builder.ToTable("Users");
            builder.HasKey(k => k.UserID);

            #endregion

            #region Properties

            builder.Property(p => p.UserID)
                .HasColumnName("UserID")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Active)
                .HasColumnName("Active");

            builder.Property(p => p.Login)
                .HasColumnName("Login");

            builder.Property(p => p.Password)
                .HasColumnName("Password");

            #endregion

            #region Relationships

            builder.HasMany(m => m.UsersEmails)
                .WithOne(m => m.User);

            #endregion

            #region Ignored

            builder.Ignore(p => p.NewPassword);
            builder.Ignore(p => p.NewPasswordConfirm);

            #endregion

        }

    }

}
