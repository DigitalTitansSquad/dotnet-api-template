using System;
using DotnetApi.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetApi.Infrastructure.Database.Extensions
{
    public static class DotnetApiDbContextContextExtensions
    {
        public static async Task<UserEntity?> GetUserOrDefaultAsync(this DotnetApiDbContext dbContext, string userId) => await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
    }
}

