using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SweetTooth.Migrations
{
    /// <inheritdoc />
    public partial class _8Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeNumber = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthlyWage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Measurement = table.Column<int>(type: "int", nullable: false),
                    ExpiringDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeriodicBudgets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalSum = table.Column<int>(type: "int", nullable: false),
                    ExpensesBudget = table.Column<int>(type: "int", nullable: false),
                    CharityBudget = table.Column<int>(type: "int", nullable: false),
                    WasteBudget = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GoalEarnings = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodicBudgets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffMembersInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    EmergencyContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfEmployment = table.Column<int>(type: "int", nullable: false),
                    Allergies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffMembersInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffMembersInfos_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyClosingCharts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalEarnings = table.Column<int>(type: "int", nullable: false),
                    TotalWaste = table.Column<int>(type: "int", nullable: false),
                    TotalCharity = table.Column<int>(type: "int", nullable: false),
                    ClosingReport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotallBills = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    BudgetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyClosingCharts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyClosingCharts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyClosingCharts_PeriodicBudgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "PeriodicBudgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyOpeningCharts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPurchasePrice = table.Column<int>(type: "int", nullable: false),
                    Report = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    BudgetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyOpeningCharts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyOpeningCharts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DailyOpeningCharts_PeriodicBudgets_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "PeriodicBudgets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillsAndOtherExpences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenceTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpencetType = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ClosingChart = table.Column<int>(type: "int", nullable: false),
                    DailyClosingChartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillsAndOtherExpences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillsAndOtherExpences_DailyClosingCharts_DailyClosingChartId",
                        column: x => x.DailyClosingChartId,
                        principalTable: "DailyClosingCharts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingListItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    TotalItemPrice = table.Column<int>(type: "int", nullable: false),
                    IsPurchased = table.Column<bool>(type: "bit", nullable: false),
                    Measurement = table.Column<int>(type: "int", nullable: false),
                    PurchaseChartId = table.Column<int>(type: "int", nullable: false),
                    ExpiringDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingListItems_DailyOpeningCharts_PurchaseChartId",
                        column: x => x.PurchaseChartId,
                        principalTable: "DailyOpeningCharts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillsAndOtherExpences_DailyClosingChartId",
                table: "BillsAndOtherExpences",
                column: "DailyClosingChartId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyClosingCharts_BudgetId",
                table: "DailyClosingCharts",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyClosingCharts_EmployeeId",
                table: "DailyClosingCharts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyOpeningCharts_BudgetId",
                table: "DailyOpeningCharts",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyOpeningCharts_EmployeeId",
                table: "DailyOpeningCharts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItems_PurchaseChartId",
                table: "ShoppingListItems",
                column: "PurchaseChartId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffMembersInfos_EmployeeId",
                table: "StaffMembersInfos",
                column: "EmployeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillsAndOtherExpences");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "ShoppingListItems");

            migrationBuilder.DropTable(
                name: "StaffMembersInfos");

            migrationBuilder.DropTable(
                name: "DailyClosingCharts");

            migrationBuilder.DropTable(
                name: "DailyOpeningCharts");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "PeriodicBudgets");
        }
    }
}
