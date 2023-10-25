using DotnetApi.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetApi.Core.Common.Interfaces;

public interface IDotnetApiDbContext
{
    DbSet<UserEntity> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}