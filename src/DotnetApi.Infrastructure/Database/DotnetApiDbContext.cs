using System;
using DotnetApi.Core.Common.Interfaces;
using DotnetApi.Core.Models;
using DotnetApi.Infrastructure.Database.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace DotnetApi.Infrastructure.Database
{
    public class DotnetApiDbContext : DbContext, IDotnetApiDbContext
    {
        public virtual DbSet<UserEntity> Users { get; set; } = default!;

        private AuditableEntitySaveChangesInterceptor? auditableEntitySaveChangesInterceptor;
  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (auditableEntitySaveChangesInterceptor == null)
                return;

            optionsBuilder.AddInterceptors(auditableEntitySaveChangesInterceptor);
        }

        public DotnetApiDbContext(
            DbContextOptions<DotnetApiDbContext> options,
            AuditableEntitySaveChangesInterceptor? auditableEntitySaveChangesInterceptor) : base(options)
        {
            this.auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        }

        public DotnetApiDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}

