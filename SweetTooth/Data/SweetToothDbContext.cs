﻿using Microsoft.EntityFrameworkCore;
using SweetTooth.Models;

namespace SweetTooth.Data
{
    public class SweetToothDbContext:DbContext
    {
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<PurchaseChart> DailyOpeningCharts { get; set; }
        public DbSet<Budget> PeriodicBudgets { get; set; }
        public DbSet<ShoppingListItem> ShoppingListItems { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<StaffMembersInfo> StaffMembersInfos { get; set; }
        public DbSet<DailyClosingChart> DailyClosingCharts { get; set; }
        public DbSet<BillsAndOtherExpences> BillsAndOtherExpences { get; set; }
        // Add other DbSet properties here as needed

        public SweetToothDbContext(DbContextOptions<SweetToothDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
