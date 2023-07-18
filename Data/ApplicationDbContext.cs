using Microsoft.EntityFrameworkCore;
using SignalRChat.Models;
using System.Collections.Generic;

namespace SignalRChat.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Groups> Groups { get; set; }
    }
}
