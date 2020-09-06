using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore31Skeleton.WebApi.Repository.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace NetCore31Skeleton.WebApi.Repository.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Username).HasMaxLength(32);
            builder.HasIndex(x => x.Username).IsUnique();

            builder.Property(x => x.Password).HasMaxLength(128);
            builder.HasIndex(x => x.Password);

            builder.Property(x => x.Name).HasMaxLength(32);
            builder.Property(x => x.Surname).HasMaxLength(32);

            builder.Property(x => x.Email).HasMaxLength(64);
            builder.HasIndex(x => x.Email).IsUnique();

            builder.HasMany(x => x.AppUserRoles).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
