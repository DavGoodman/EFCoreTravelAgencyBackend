using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreTravelAgency.Migrations
{
    /// <inheritdoc />
    public partial class seedinitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "InvoiceGroups",
                columns: new[] { "Id", "IssueDate" },
                values: new object[,]
                {
                    { new Guid("1ffc5531-24a6-49ba-a6c9-5c8cee51d649"), new DateTime(2015, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("611b9eed-ab46-46d8-a212-586ff7a2386d"), new DateTime(2016, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b0382f47-c34a-4d42-bfb6-d39a25b88afb"), new DateTime(2015, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "InvoiceGroupId" },
                values: new object[,]
                {
                    { new Guid("30f2b9b1-c7af-4c86-bd21-21d7f4a98146"), null },
                    { new Guid("b2f53c24-4565-406f-8a6d-1fe2c7666dc7"), null },
                    { new Guid("b70b0fbb-37ea-4cbe-8fab-d7014355aa75"), null },
                    { new Guid("d03add67-9ffc-4a66-86b4-e680281a4b41"), null }
                });

            migrationBuilder.InsertData(
                table: "TravelAgentsInfo",
                columns: new[] { "TravelAgent", "TotalNumberOfNights" },
                values: new object[,]
                {
                    { "Chuck McGill", 0 },
                    { "Howard Hamlin", 44 },
                    { "James McGill", 13 },
                    { "Kim Wexler", 14 }
                });

            migrationBuilder.InsertData(
                table: "InvoiceGroupLinks",
                columns: new[] { "InvoiceGroupId", "InvoiceId" },
                values: new object[,]
                {
                    { new Guid("1ffc5531-24a6-49ba-a6c9-5c8cee51d649"), new Guid("30f2b9b1-c7af-4c86-bd21-21d7f4a98146") },
                    { new Guid("1ffc5531-24a6-49ba-a6c9-5c8cee51d649"), new Guid("b2f53c24-4565-406f-8a6d-1fe2c7666dc7") },
                    { new Guid("611b9eed-ab46-46d8-a212-586ff7a2386d"), new Guid("30f2b9b1-c7af-4c86-bd21-21d7f4a98146") },
                    { new Guid("611b9eed-ab46-46d8-a212-586ff7a2386d"), new Guid("b70b0fbb-37ea-4cbe-8fab-d7014355aa75") },
                    { new Guid("611b9eed-ab46-46d8-a212-586ff7a2386d"), new Guid("d03add67-9ffc-4a66-86b4-e680281a4b41") },
                    { new Guid("b0382f47-c34a-4d42-bfb6-d39a25b88afb"), new Guid("b2f53c24-4565-406f-8a6d-1fe2c7666dc7") },
                    { new Guid("b0382f47-c34a-4d42-bfb6-d39a25b88afb"), new Guid("b70b0fbb-37ea-4cbe-8fab-d7014355aa75") },
                    { new Guid("b0382f47-c34a-4d42-bfb6-d39a25b88afb"), new Guid("d03add67-9ffc-4a66-86b4-e680281a4b41") }
                });

            migrationBuilder.InsertData(
                table: "Observations",
                columns: new[] { "Id", "GuestName", "InvoiceId", "NumberOfNights", "TravelAgent" },
                values: new object[,]
                {
                    { new Guid("12975222-c271-4213-b394-64ea4096fb38"), "John Smith", new Guid("30f2b9b1-c7af-4c86-bd21-21d7f4a98146"), 14, "Kim Wexler" },
                    { new Guid("218a7b4f-d633-4400-9654-434542bd63d4"), "Walter White", new Guid("b2f53c24-4565-406f-8a6d-1fe2c7666dc7"), 5, "James McGill" },
                    { new Guid("257ad6cc-9e05-48c3-aeb9-c3f421603af1"), "Michael Ehrmantraut", new Guid("b70b0fbb-37ea-4cbe-8fab-d7014355aa75"), 30, "Howard Hamlin" },
                    { new Guid("62f5cffd-659c-4e23-ae2f-ba9056d397a6"), "Walter White", new Guid("b2f53c24-4565-406f-8a6d-1fe2c7666dc7"), 3, "James McGill" },
                    { new Guid("8c00db50-3a8b-4c4c-b363-50f33afd6065"), "Gustavo Fring", new Guid("d03add67-9ffc-4a66-86b4-e680281a4b41"), 5, "James McGill" },
                    { new Guid("cb7fd10f-12cc-433d-ba28-4a26e8fcb825"), "Gustavo Fring", new Guid("d03add67-9ffc-4a66-86b4-e680281a4b41"), 14, "Howard Hamlin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InvoiceGroupLinks",
                keyColumns: new[] { "InvoiceGroupId", "InvoiceId" },
                keyValues: new object[] { new Guid("1ffc5531-24a6-49ba-a6c9-5c8cee51d649"), new Guid("30f2b9b1-c7af-4c86-bd21-21d7f4a98146") });

            migrationBuilder.DeleteData(
                table: "InvoiceGroupLinks",
                keyColumns: new[] { "InvoiceGroupId", "InvoiceId" },
                keyValues: new object[] { new Guid("1ffc5531-24a6-49ba-a6c9-5c8cee51d649"), new Guid("b2f53c24-4565-406f-8a6d-1fe2c7666dc7") });

            migrationBuilder.DeleteData(
                table: "InvoiceGroupLinks",
                keyColumns: new[] { "InvoiceGroupId", "InvoiceId" },
                keyValues: new object[] { new Guid("611b9eed-ab46-46d8-a212-586ff7a2386d"), new Guid("30f2b9b1-c7af-4c86-bd21-21d7f4a98146") });

            migrationBuilder.DeleteData(
                table: "InvoiceGroupLinks",
                keyColumns: new[] { "InvoiceGroupId", "InvoiceId" },
                keyValues: new object[] { new Guid("611b9eed-ab46-46d8-a212-586ff7a2386d"), new Guid("b70b0fbb-37ea-4cbe-8fab-d7014355aa75") });

            migrationBuilder.DeleteData(
                table: "InvoiceGroupLinks",
                keyColumns: new[] { "InvoiceGroupId", "InvoiceId" },
                keyValues: new object[] { new Guid("611b9eed-ab46-46d8-a212-586ff7a2386d"), new Guid("d03add67-9ffc-4a66-86b4-e680281a4b41") });

            migrationBuilder.DeleteData(
                table: "InvoiceGroupLinks",
                keyColumns: new[] { "InvoiceGroupId", "InvoiceId" },
                keyValues: new object[] { new Guid("b0382f47-c34a-4d42-bfb6-d39a25b88afb"), new Guid("b2f53c24-4565-406f-8a6d-1fe2c7666dc7") });

            migrationBuilder.DeleteData(
                table: "InvoiceGroupLinks",
                keyColumns: new[] { "InvoiceGroupId", "InvoiceId" },
                keyValues: new object[] { new Guid("b0382f47-c34a-4d42-bfb6-d39a25b88afb"), new Guid("b70b0fbb-37ea-4cbe-8fab-d7014355aa75") });

            migrationBuilder.DeleteData(
                table: "InvoiceGroupLinks",
                keyColumns: new[] { "InvoiceGroupId", "InvoiceId" },
                keyValues: new object[] { new Guid("b0382f47-c34a-4d42-bfb6-d39a25b88afb"), new Guid("d03add67-9ffc-4a66-86b4-e680281a4b41") });

            migrationBuilder.DeleteData(
                table: "Observations",
                keyColumn: "Id",
                keyValue: new Guid("12975222-c271-4213-b394-64ea4096fb38"));

            migrationBuilder.DeleteData(
                table: "Observations",
                keyColumn: "Id",
                keyValue: new Guid("218a7b4f-d633-4400-9654-434542bd63d4"));

            migrationBuilder.DeleteData(
                table: "Observations",
                keyColumn: "Id",
                keyValue: new Guid("257ad6cc-9e05-48c3-aeb9-c3f421603af1"));

            migrationBuilder.DeleteData(
                table: "Observations",
                keyColumn: "Id",
                keyValue: new Guid("62f5cffd-659c-4e23-ae2f-ba9056d397a6"));

            migrationBuilder.DeleteData(
                table: "Observations",
                keyColumn: "Id",
                keyValue: new Guid("8c00db50-3a8b-4c4c-b363-50f33afd6065"));

            migrationBuilder.DeleteData(
                table: "Observations",
                keyColumn: "Id",
                keyValue: new Guid("cb7fd10f-12cc-433d-ba28-4a26e8fcb825"));

            migrationBuilder.DeleteData(
                table: "TravelAgentsInfo",
                keyColumn: "TravelAgent",
                keyValue: "Chuck McGill");

            migrationBuilder.DeleteData(
                table: "InvoiceGroups",
                keyColumn: "Id",
                keyValue: new Guid("1ffc5531-24a6-49ba-a6c9-5c8cee51d649"));

            migrationBuilder.DeleteData(
                table: "InvoiceGroups",
                keyColumn: "Id",
                keyValue: new Guid("611b9eed-ab46-46d8-a212-586ff7a2386d"));

            migrationBuilder.DeleteData(
                table: "InvoiceGroups",
                keyColumn: "Id",
                keyValue: new Guid("b0382f47-c34a-4d42-bfb6-d39a25b88afb"));

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("30f2b9b1-c7af-4c86-bd21-21d7f4a98146"));

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("b2f53c24-4565-406f-8a6d-1fe2c7666dc7"));

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("b70b0fbb-37ea-4cbe-8fab-d7014355aa75"));

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: new Guid("d03add67-9ffc-4a66-86b4-e680281a4b41"));

            migrationBuilder.DeleteData(
                table: "TravelAgentsInfo",
                keyColumn: "TravelAgent",
                keyValue: "Howard Hamlin");

            migrationBuilder.DeleteData(
                table: "TravelAgentsInfo",
                keyColumn: "TravelAgent",
                keyValue: "James McGill");

            migrationBuilder.DeleteData(
                table: "TravelAgentsInfo",
                keyColumn: "TravelAgent",
                keyValue: "Kim Wexler");
        }
    }
}
