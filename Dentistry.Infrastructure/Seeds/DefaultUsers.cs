using Dentistry.Domain.Entity;

namespace Dentistry.Infrastructure.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedAsync(ApplicationDbContext dbContext)
        {
            var defusers = new List<User>
            {
                new User{Id=Guid.NewGuid(),FullName="رضا صلحی",Password="Reza@admin",UserName="admin"},
            };

            var users = defusers.Where(s => !dbContext.Users.Select(x => x.UserName).Contains(s.UserName)).ToList();
            if (users.Count() > 0)
            {
                await dbContext.Users.AddRangeAsync(users);

                await dbContext.SaveChangesAsync();
            }
        }

    }
}
