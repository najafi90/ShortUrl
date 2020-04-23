using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShortUrl.DataLayer.Migrations
{
    public partial class FirstUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Urls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainUrlAddress = table.Column<string>(maxLength: 1024, nullable: true),
                    ShortAddress = table.Column<string>(maxLength: 64, nullable: true),
                    CounterViews = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urls", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Urls_ShortAddress",
                table: "Urls",
                column: "ShortAddress",
                unique: true,
                filter: "[ShortAddress] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Urls");
        }
    }
}
