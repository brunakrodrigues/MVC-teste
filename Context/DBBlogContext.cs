using System;
using Microsoft.EntityFrameworkCore;
using MVC_with_EF.Context.Models;

namespace MVC_with_EF.Context
{
    public class DBBlogContext : DbContext
    {
        public DBBlogContext(DbContextOptions<DBBlogContext> options)
            : base(options) { }

        public DbSet<Author> Author { get; set; }

        public DbSet<Post> Post { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //explicita o relacionamento das tabelass
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Author)
                .WithMany(b => b.Posts)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
