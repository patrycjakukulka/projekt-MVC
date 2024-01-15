using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace platforma.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminRoleId = "db4cb291-e796-4369-9ae0-1a22c6e7253c";
            var userRoleId = "edfd2750-4298-4fae-a199-28e9eef5a793";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },

                  new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            var AdminId = "11d6c2d2-c4c5-4409-a561-6c516cf3e67a";
            var AdminUser = new IdentityUser
            {
                UserName = "admin@platforma.com",
                Email = "admin@platforma.com",
                NormalizedEmail = "admin@platforma.com".ToUpper(),
                NormalizedUserName = "admin@platforma.com".ToUpper(),
                Id = AdminId
            };
            AdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(AdminUser, "admin@123");

            builder.Entity<IdentityUser>().HasData(AdminUser);

            var AdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId =AdminId,
                },

                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId =AdminId,
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(AdminRoles);

        }
    }
}
