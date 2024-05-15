using System;
using DigitalTitans.DotnetApi.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalTitans.DotnetApi.Infrastructure.Database.Extensions
{
    public static class AppDbContextContextExtensions
    {
        public static async Task<UserEntity?> GetUserOrDefaultAsync(this AppDbContext dbContext, long userId) => await dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
    }
}

