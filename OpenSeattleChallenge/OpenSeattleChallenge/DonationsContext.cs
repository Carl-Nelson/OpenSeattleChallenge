using Microsoft.EntityFrameworkCore;

namespace OpenSeattleChallenge
{
    class DonationsContext : DbContext
    {
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Distribution> Distributions { get; set; }
        public DbSet<Donor> Donors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=donations.db");
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
