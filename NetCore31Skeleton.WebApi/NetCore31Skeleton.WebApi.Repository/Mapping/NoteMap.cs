using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore31Skeleton.WebApi.Repository.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace NetCore31Skeleton.WebApi.Repository.Mapping
{
    public class NoteMap : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Title).HasMaxLength(128).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(512).IsRequired();

            builder.HasIndex(x => x.CategoryId);

            builder.HasOne(x => x.Category).WithMany(x => x.Notes).HasForeignKey(x => x.CategoryId);
        }
    }
}
