using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace loginProject.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<LoginData> LoginData { get; set; }
        public DbSet<Input> Inputs { get; set; }
    }
}
