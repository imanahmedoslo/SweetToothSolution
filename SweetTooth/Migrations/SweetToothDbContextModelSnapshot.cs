﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SweetTooth.Data;

#nullable disable

namespace SweetTooth.Migrations
{
    [DbContext(typeof(SweetToothDbContext))]
    partial class SweetToothDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SweetTooth.Data.Models.BillsAndOtherExpences", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClosingChart")
                        .HasColumnType("int");

                    b.Property<int>("DailyClosingChartId")
                        .HasColumnType("int");

                    b.Property<string>("ExpenceTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExpencetType")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DailyClosingChartId");

                    b.ToTable("BillsAndOtherExpences");
                });

            modelBuilder.Entity("SweetTooth.Data.Models.Budget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CharityBudget")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExpensesBudget")
                        .HasColumnType("int");

                    b.Property<int>("GoalEarnings")
                        .HasColumnType("int");

                    b.Property<int>("TotalSum")
                        .HasColumnType("int");

                    b.Property<int>("WasteBudget")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("SweetTooth.Data.Models.DailyClosingChart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BudgetId")
                        .HasColumnType("int");

                    b.Property<string>("ClosingReport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("TotalCharity")
                        .HasColumnType("int");

                    b.Property<int>("TotalEarnings")
                        .HasColumnType("int");

                    b.Property<int>("TotalWaste")
                        .HasColumnType("int");

                    b.Property<int>("TotallBills")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("DailyClosingCharts");
                });

            modelBuilder.Entity("SweetTooth.Data.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeNumber")
                        .HasColumnType("int");

                    b.Property<int>("MonthlyWage")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("SweetTooth.Data.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpiringDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Measurement")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("SweetTooth.Data.Models.PurchaseChart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BudgetId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Report")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalPurchasePrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BudgetId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("PurchaseCharts");
                });

            modelBuilder.Entity("SweetTooth.Data.Models.ShoppingListItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpiringDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPurchased")
                        .HasColumnType("bit");

                    b.Property<int>("Measurement")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PurchaseChartId")
                        .HasColumnType("int");

                    b.Property<int>("TotalItemPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PurchaseChartId");

                    b.ToTable("ShoppingListItems");
                });

            modelBuilder.Entity("SweetTooth.Data.Models.StaffMembersInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Allergies")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmergencyContact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeOfEmployment")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("StaffMembersInfos");
                });

            modelBuilder.Entity("SweetTooth.Data.Models.BillsAndOtherExpences", b =>
                {
                    b.HasOne("SweetTooth.Data.Models.DailyClosingChart", "DailyClosingChart")
                        .WithMany("BillsAndOtherExpences")
                        .HasForeignKey("DailyClosingChartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DailyClosingChart");
                });

            modelBuilder.Entity("SweetTooth.Data.Models.DailyClosingChart", b =>
                {
                    b.HasOne("SweetTooth.Data.Models.Budget", "Budget")
                        .WithMany("DailyClosingCharts")
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SweetTooth.Data.Models.Employee", "Employee")
                        .WithMany("DailyClosingChart")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Budget");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("SweetTooth.Data.Models.PurchaseChart", b =>
                {
                    b.HasOne("SweetTooth.Data.Models.Budget", "Budget")
                        .WithMany("PurchaseCharts")
                        .HasForeignKey("BudgetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SweetTooth.Data.Models.Employee", "Employee")
                        .WithMany("PurchaseChart")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Budget");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("SweetTooth.Data.Models.ShoppingListItem", b =>
                {
                    b.HasOne("SweetTooth.Data.Models.PurchaseChart", "PurchaseChart")
                        .WithMany("ShoppingList")
                        .HasForeignKey("PurchaseChartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PurchaseChart");
                });

            modelBuilder.Entity("SweetTooth.Data.Models.StaffMembersInfo", b =>
                {
                    b.HasOne("SweetTooth.Data.Models.Employee", "Employee")
                        .WithOne("StaffMembersInfo")
                        .HasForeignKey("SweetTooth.Data.Models.StaffMembersInfo", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("SweetTooth.Data.Models.Budget", b =>
                {
                    b.Navigation("DailyClosingCharts");

                    b.Navigation("PurchaseCharts");
                });

            modelBuilder.Entity("SweetTooth.Data.Models.DailyClosingChart", b =>
                {
                    b.Navigation("BillsAndOtherExpences");
                });

            modelBuilder.Entity("SweetTooth.Data.Models.Employee", b =>
                {
                    b.Navigation("DailyClosingChart");

                    b.Navigation("PurchaseChart");

                    b.Navigation("StaffMembersInfo");
                });

            modelBuilder.Entity("SweetTooth.Data.Models.PurchaseChart", b =>
                {
                    b.Navigation("ShoppingList");
                });
#pragma warning restore 612, 618
        }
    }
}
