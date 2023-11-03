using DigitalTitans.DotnetApi.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalTitans.DotnetApi.Core.Common.Interfaces;

public interface IDbContext
{
    DbSet<UserEntity> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}