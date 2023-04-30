using Gliese.DAL.Configurations;
using Gliese.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.DAL.SQL
{
    public class DeimosDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
    IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DeimosDbContext(DbContextOptions<DeimosDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.ApplyConfiguration(new CurrencyConfiguration());
            builder.ApplyConfiguration(new ExchangeRateConfiguration());
            builder.ApplyConfiguration(new PersonConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new MainTransactionConfiguration());
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new TransactionTypeConfiguration());
            builder.ApplyConfiguration(new PurchaseTransactionConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfiguration(new AccountConfiguration());
            builder.ApplyConfiguration(new WorkedTaskConfiguration());
        }

        public DbSet<Country> Country { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<ExchangeRate> ExchangeRate { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<MainTransaction> MainTransaction { get; set; }
        public DbSet<TransactionType> TransactionType { get; set; }
        public DbSet<PurchaseTransaction> PurchaseTransaction { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<WorkedTask> WorkedTask { get; set; }
    }
}
