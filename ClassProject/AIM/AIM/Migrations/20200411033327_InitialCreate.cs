using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AIM.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerInfo",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Rank = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInfo", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "DodicLibrary",
                columns: table => new
                {
                    Dodic = table.Column<string>(nullable: false),
                    Nomenclature = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DodicLibrary", x => x.Dodic);
                });

            migrationBuilder.CreateTable(
                name: "LocalInventory",
                columns: table => new
                {
                    AmmoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocNumber = table.Column<string>(nullable: true),
                    Dodic = table.Column<string>(nullable: true),
                    Nomenclature = table.Column<string>(nullable: true),
                    LotNumber = table.Column<string>(nullable: true),
                    InitialQty = table.Column<int>(nullable: true),
                    CurrentQty = table.Column<int>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalInventory", x => x.AmmoId);
                });

            migrationBuilder.CreateTable(
                name: "LocalTransaction",
                columns: table => new
                {
                    Da5515Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    DocNumber = table.Column<string>(nullable: true),
                    RecUnit = table.Column<string>(nullable: true),
                    RecDate = table.Column<DateTime>(nullable: false),
                    Tidate = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    Da5515copy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalTransaction", x => x.Da5515Id);
                });

            migrationBuilder.CreateTable(
                name: "SingleInventory",
                columns: table => new
                {
                    Da3020Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: true),
                    Da5515id = table.Column<int>(nullable: true),
                    DocNumber = table.Column<string>(nullable: true),
                    Dodic = table.Column<string>(nullable: true),
                    Nomenclature = table.Column<string>(nullable: true),
                    LotNumber = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ActionTaken = table.Column<string>(nullable: true),
                    Qtylost = table.Column<int>(nullable: true),
                    Qtygained = table.Column<int>(nullable: true),
                    Balance = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleInventory", x => x.Da3020Id);
                });

            migrationBuilder.CreateTable(
                name: "SingleTransactionDetails",
                columns: table => new
                {
                    LineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Da5515Id = table.Column<int>(nullable: true),
                    Dodic = table.Column<string>(nullable: true),
                    Nomenclature = table.Column<string>(nullable: true),
                    LotNumber = table.Column<string>(nullable: true),
                    Qtyissued = table.Column<int>(nullable: true),
                    ResIssued = table.Column<string>(nullable: true),
                    Qtyreturned = table.Column<int>(nullable: true),
                    ResReturned = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleTransactionDetails", x => x.LineId);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Rank = table.Column<string>(nullable: true),
                    Privilege = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerInfo");

            migrationBuilder.DropTable(
                name: "DodicLibrary");

            migrationBuilder.DropTable(
                name: "LocalInventory");

            migrationBuilder.DropTable(
                name: "LocalTransaction");

            migrationBuilder.DropTable(
                name: "SingleInventory");

            migrationBuilder.DropTable(
                name: "SingleTransactionDetails");

            migrationBuilder.DropTable(
                name: "UserInfo");
        }
    }
}
