using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIM.Models;
using Microsoft.EntityFrameworkCore;

namespace AIM.Data
{
    public class AIMDbContext : DbContext
    {
        public AIMDbContext (DbContextOptions<AIMDbContext> options)
            : base(options)
        {
        }

        public DbSet<CustomerInfo> CustomerInfo { get; set; }
        public DbSet<DodicLibrary> DodicLibrary { get; set; }
        public DbSet<LocalInventory> LocalInventory { get; set; }
        public DbSet<LocalTransaction> LocalTransaction { get; set; }
        public DbSet<SingleInventory> SingleInventory { get; set; }
        public DbSet<SingleTransactionDetails> SingleTransactionDetails { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
    }
}
