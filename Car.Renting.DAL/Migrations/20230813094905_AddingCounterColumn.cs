using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Car.Renting.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddingCounterColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("1485c142-aabb-4639-88eb-0bcbd66067da"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("3c70c936-e544-45ab-8c30-f4413eeee98f"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("b54ff3d1-fe99-435e-b15d-3b20eb70d542"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("c7402551-e051-42c8-ab7c-0895fddb9a5d"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("e0221140-2ada-4c62-96ad-d19905577b0f"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("f632f9ea-3696-4f29-ad22-2f04de736bf2"));

            migrationBuilder.AddColumn<int>(
                name: "Counter",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrandName", "ModelName", "ModelType", "ModelYear", "Power" },
                values: new object[,]
                {
                    { new Guid("151360ca-0ff1-4ad6-9d03-51c3ee9ed046"), "Tesla", "Tesla Model 3", "Sedan", 2023, 358 },
                    { new Guid("60d9b67f-ee5f-4277-88b1-8d2cb435feec"), "Toyota", "Toyota Camry", "Sedan", 2023, 203 },
                    { new Guid("b81f0e37-6fd1-477c-a3d1-501463a737b3"), "Honda", "Honda Civic", "Sedan", 2023, 174 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AdvancedPayment", "DrivingLicenseNo", "Name", "Nationality" },
                values: new object[,]
                {
                    { new Guid("8002ca5a-7693-4e15-9ae9-fb9efcad2852"), "", "0123456789", "Peter Smith", "British" },
                    { new Guid("a1cb2854-ec5d-4b35-afd2-f6d91a97a7e5"), "", "9876543210", "Jane Doe", "Canadian" },
                    { new Guid("c80b32f5-9f3f-47ab-9118-b2ce8ed20cff"), "", "1234567890", "John Doe", "American" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("151360ca-0ff1-4ad6-9d03-51c3ee9ed046"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("60d9b67f-ee5f-4277-88b1-8d2cb435feec"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("b81f0e37-6fd1-477c-a3d1-501463a737b3"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("8002ca5a-7693-4e15-9ae9-fb9efcad2852"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("a1cb2854-ec5d-4b35-afd2-f6d91a97a7e5"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("c80b32f5-9f3f-47ab-9118-b2ce8ed20cff"));

            migrationBuilder.DropColumn(
                name: "Counter",
                table: "Cars");

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
        }
    }
}
