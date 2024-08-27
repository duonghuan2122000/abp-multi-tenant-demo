using Microsoft.EntityFrameworkCore;
using Sora.AbpDemo.Entities;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Sora.AbpDemo.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public class BusinessDemoDbContext : AbpDbContext<BusinessDemoDbContext>
    {
        public virtual DbSet<Article> Article { get; set; }

        public BusinessDemoDbContext(DbContextOptions<BusinessDemoDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("article");
                entity.HasKey(a => a.Id);
            });
        }
    }
}