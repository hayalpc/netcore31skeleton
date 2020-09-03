using Microsoft.EntityFrameworkCore;
using NetCore31Skeleton.WebApi.Repository.Models;
using System.Net;

namespace NetCore31Skeleton.WebApi.MigrationTool.Context
{
    public class MigrationDbContext : DbContext
    {
        public MigrationDbContext(DbContextOptions<MigrationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Note> Note { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Log> Log { get; set; }

    }
}
