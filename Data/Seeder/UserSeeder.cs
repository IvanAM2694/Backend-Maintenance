using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Data.Seeder
{
    public static class UserSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    Guid = new Guid("112428f9-9b87-471a-b288-d9e50f10a914"),
                    Name = "Admin",
                    LastName = "Super",
                    Gender = "M",
                    BirthDate = DateOnly.FromDateTime(DateTime.Now),
                    Email = "admin@test.com",
                    Password = StringCipher.Encrypt("admin"),
                    CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)
                }
            );
        }
    }
}
