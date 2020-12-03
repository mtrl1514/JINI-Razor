using Microsoft.EntityFrameworkCore.Migrations;

namespace JINI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Supplier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrder",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesOrderNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrder", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SalesOrder_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Revenue",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RevenueDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevenueCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalesOrderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revenue", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Revenue_SalesOrder_SalesOrderID",
                        column: x => x.SalesOrderID,
                        principalTable: "SalesOrder",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderItem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitProfit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalesQuantity = table.Column<decimal>(type: "decimal(18,1)", nullable: false),
                    ItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesOrderID = table.Column<int>(type: "int", nullable: true),
                    ItemID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SalesOrderItem_Item_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Item",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesOrderItem_SalesOrder_SalesOrderID",
                        column: x => x.SalesOrderID,
                        principalTable: "SalesOrder",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Revenue_SalesOrderID",
                table: "Revenue",
                column: "SalesOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrder_CustomerID",
                table: "SalesOrder",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderItem_ItemID",
                table: "SalesOrderItem",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderItem_SalesOrderID",
                table: "SalesOrderItem",
                column: "SalesOrderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Revenue");

            migrationBuilder.DropTable(
                name: "SalesOrderItem");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "SalesOrder");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
