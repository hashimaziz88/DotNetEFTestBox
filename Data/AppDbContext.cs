using DotNetEFTestBox.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetEFTestBox.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
    {

        public DbSet<Character> Characters => Set<Character>();
    }
}
