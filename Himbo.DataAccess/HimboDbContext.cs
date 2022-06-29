using Himbo.Domain;
using Himbo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Himbo.DataAccess
{
    public class HimboDbContext : AuditableDbContext
    {
        public HimboDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        #region Entities
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostMeta> PostsMetas { get; set; }
        public DbSet<Rating> PostsRatings { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion

        #region UseCases
        public DbSet<Group> Groups { get; set; }
        public DbSet<UseCase> UseCases { get; set; }
        #endregion
    }
}
