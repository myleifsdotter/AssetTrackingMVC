using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetTrackingMVC.Data.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "HouseNumber", "PhoneNumber", "PostalCode", "StreetName" },
                values: new object[] { 1, "Malmö", "4", "+46 123 45 67 98", "21111", "Fina gatan" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "HouseNumber", "PhoneNumber", "PostalCode", "StreetName" },
                values: new object[] { 2, "Gijón", "4", "+34 123 45 67 98", "33203", "Calle Bonita" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "HouseNumber", "PhoneNumber", "PostalCode", "StreetName" },
                values: new object[] { 3, "Gainsville FL", "4", "+1 123 45 67 98", "32601", "Posh Street" });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "AddressId", "Country", "Currency" },
                values: new object[] { 1, 1, "Sweden", "SEK" });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "AddressId", "Country", "Currency" },
                values: new object[] { 2, 2, "Spain", "EUR" });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "Id", "AddressId", "Country", "Currency" },
                values: new object[] { 3, 3, "USA", "USD" });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "Brand", "Model", "OfficeId", "Price", "PurchaseDate", "Type" },
                values: new object[,]
                {
                    { 1, "iPhone", "8", 2, 970.0, new DateTime(2019, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile Phone" },
                    { 2, "HP", "Elitebook", 2, 1423.0, new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laptop Computer" },
                    { 3, "iPhone", "11", 2, 990.0, new DateTime(2022, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile Phone" },
                    { 4, "iPhone", "X", 1, 1245.0, new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile Phone" },
                    { 5, "Motorola", "Razr", 1, 970.0, new DateTime(2019, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile Phone" },
                    { 6, "HP", "Elitebook", 1, 588.0, new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laptop Computer" },
                    { 7, "Asus", "W234", 3, 1200.0, new DateTime(2019, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laptop Computer" },
                    { 8, "Lenovo", "Yoga 730", 3, 835.0, new DateTime(2021, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laptop Computer" },
                    { 9, "Lenovo", "Yoga 530", 3, 1030.0, new DateTime(2019, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laptop Computer" },
                    { 10, "Samsung", "Galaxy", 3, 1170.0, new DateTime(2018, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile Phone" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Offices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
