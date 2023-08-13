using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Car.Renting.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModelType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModelYear = table.Column<int>(type: "int", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DrivingLicenseNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdvancedPayment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingCars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingCars_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookingCars_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentedCars",
                columns: table => new
                {
                    BookingCarsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RentDuration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentedCars", x => new { x.CarId, x.BookingCarsId });
                    table.ForeignKey(
                        name: "FK_RentedCars_BookingCars_BookingCarsId",
                        column: x => x.BookingCarsId,
                        principalTable: "BookingCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrandName", "ModelName", "ModelType", "ModelYear", "Power" },
                values: new object[,]
                {
                    { new Guid("1485c142-aabb-4639-88eb-0bcbd66067da"), "Tesla", "Tesla Model 3", "Sedan", 2023, 358 },
                    { new Guid("3c70c936-e544-45ab-8c30-f4413eeee98f"), "Toyota", "Toyota Camry", "Sedan", 2023, 203 },
                    { new Guid("b54ff3d1-fe99-435e-b15d-3b20eb70d542"), "Honda", "Honda Civic", "Sedan", 2023, 174 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AdvancedPayment", "DrivingLicenseNo", "Name", "Nationality" },
                values: new object[,]
                {
                    { new Guid("c7402551-e051-42c8-ab7c-0895fddb9a5d"), "", "1234567890", "John Doe", "American" },
                    { new Guid("e0221140-2ada-4c62-96ad-d19905577b0f"), "", "9876543210", "Jane Doe", "Canadian" },
                    { new Guid("f632f9ea-3696-4f29-ad22-2f04de736bf2"), "", "0123456789", "Peter Smith", "British" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingCars_CarId",
                table: "BookingCars",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingCars_CustomerId",
                table: "BookingCars",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RentedCars_BookingCarsId",
                table: "RentedCars",
                column: "BookingCarsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentedCars");

            migrationBuilder.DropTable(
                name: "BookingCars");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
