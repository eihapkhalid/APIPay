using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domains;
namespace Bl
{
    public class PaymentUserDbContext : DbContext
    {
        public DbSet<TbUser> TbUsers { get; set; }
        public DbSet<TbBankAccount> TbBankAccounts { get; set; }
        public DbSet<TbPayment> TbPayments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =DESKTOP-IBHOD3E;Database=PaymentUserDB; Trusted_Connection=True;Encrypt=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbPayment>()
                .HasOne(p => p.User)
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TbPayment>()
                .HasOne(p => p.BankAccount)
                .WithMany(b => b.Payments)
                .HasForeignKey(p => p.BankAccountId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TbBankAccount>()
                .HasOne(b => b.User)
                .WithOne(u => u.BankAccount)
                .HasForeignKey<TbBankAccount>(b => b.UserId);
        }
    }

}
