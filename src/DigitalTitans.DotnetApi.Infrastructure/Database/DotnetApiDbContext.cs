using System;
using DigitalTitans.DotnetApi.Core.Common.Interfaces;
using DigitalTitans.DotnetApi.Core.Models;
using DigitalTitans.DotnetApi.Infrastructure.Database.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace DigitalTitans.DotnetApi.Infrastructure.Database
{
    public class AppDbContext : DbContext, IDbContext
    {
        public virtual DbSet<UserEntity> Users { get; set; } = default!;

        private AuditableEntitySaveChangesInterceptor? auditableEntitySaveChangesInterceptor;
  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (auditableEntitySaveChangesInterceptor == null)
                return;

            optionsBuilder.AddInterceptors(auditableEntitySaveChangesInterceptor);
        }

        public AppDbContext(
            DbContextOptions<AppDbContext> options,
            AuditableEntitySaveChangesInterceptor? auditableEntitySaveChangesInterceptor) : base(options)
        {
            this.auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        }

        public AppDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}

