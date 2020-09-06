using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore31Skeleton.WebApi.Repository.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace NetCore31Skeleton.WebApi.Repository.Mapping
{
    public class AppRoleMap : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).HasMaxLength(32).IsRequired();

            builder.HasMany(x => x.AppUserRoles).WithOne(x => x.AppRole).HasForeignKey(x => x.AppRoleId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
