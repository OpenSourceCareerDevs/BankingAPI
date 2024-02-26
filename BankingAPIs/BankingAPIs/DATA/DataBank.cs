using BankingAPIs.ModelClass;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BankingAPIs.DATA
{
    public class DataBank : DbContext
    {
        public DataBank(DbContextOptions<DataBank> options) :
            base(options)
        {

        }
        
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAccount>()
                  .HasKey(m => new { m.AccountGenerated});
        }*/
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<AdminLogin> AdminLogins { get; set; }
        public DbSet<SignUp> SignUps { get; set; }
        public DbSet<Transcation> Transcations { get; set; }

    }
}
