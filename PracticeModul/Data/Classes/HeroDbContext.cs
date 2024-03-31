using Microsoft.EntityFrameworkCore;
using PracticeModul.Models;

namespace PracticeModul.Data.Classes
{
    public class HeroDbContext  : DbContext
    {
        public DbSet<Hero> Heroes { get; set; }
        public HeroDbContext(DbContextOptions<HeroDbContext> opt) : base(opt)
        {

        }
    }
}
