using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreTravelAgency.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelAgentsInfo",
                columns: table => new
                {
                    TravelAgent = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalNumberOfNights = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelAgentsInfo", x => x.TravelAgent);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_InvoiceGroups_InvoiceGroupId",
                        column: x => x.InvoiceGroupId,
                        principalTable: "InvoiceGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceGroupLinks",
                columns: table => new
                {
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceGroupLinks", x => new { x.InvoiceGroupId, x.InvoiceId });
                    table.ForeignKey(
                        name: "FK_InvoiceGroupLinks_InvoiceGroups_InvoiceGroupId",
                        column: x => x.InvoiceGroupId,
                        principalTable: "InvoiceGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceGroupLinks_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Observations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfNights = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TravelAgent = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Observations_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Observations_TravelAgentsInfo_TravelAgent",
                        column: x => x.TravelAgent,
                        principalTable: "TravelAgentsInfo",
                        principalColumn: "TravelAgent",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceGroupLinks_InvoiceId",
                table: "InvoiceGroupLinks",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceGroupId",
                table: "Invoices",
                column: "InvoiceGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_InvoiceId",
                table: "Observations",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Observations_TravelAgent",
                table: "Observations",
                column: "TravelAgent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceGroupLinks");

            migrationBuilder.DropTable(
                name: "Observations");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "TravelAgentsInfo");

            migrationBuilder.DropTable(
                name: "InvoiceGroups");
        }
    }
}
