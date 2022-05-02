using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VxTel.EntityFramework.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CallPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FreeTime = table.Column<int>(type: "int", nullable: false),
                    ExcedeedTimeFeePercentage = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CallPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromDDD = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ToDDD = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PricePerMinute = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallPrices", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CallPlans",
                columns: new[] { "Id", "ExcedeedTimeFeePercentage", "FreeTime", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 0.10000000000000001, 30, "FaleMais 30", 10.0 },
                    { 2, 0.10000000000000001, 60, "FaleMais 60", 20.0 },
                    { 3, 0.10000000000000001, 120, "FaleMais 120", 30.0 }
                });

            migrationBuilder.InsertData(
                table: "CallPrices",
                columns: new[] { "Id", "FromDDD", "PricePerMinute", "ToDDD" },
                values: new object[,]
                {
                    { 1, "011", 1.8999999999999999, "016" },
                    { 2, "016", 2.8999999999999999, "011" },
                    { 3, "011", 1.7, "017" },
                    { 4, "017", 2.7000000000000002, "011" },
                    { 5, "011", 0.90000000000000002, "018" },
                    { 6, "018", 1.8999999999999999, "011" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CallPlans_Name",
                table: "CallPlans",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CallPrices_FromDDD_ToDDD",
                table: "CallPrices",
                columns: new[] { "FromDDD", "ToDDD" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallPlans");

            migrationBuilder.DropTable(
                name: "CallPrices");
        }
    }
}
