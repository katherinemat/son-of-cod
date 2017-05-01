using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SonOfCod.Migrations
{
    public partial class editPageContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarketingPageContents");

            migrationBuilder.CreateTable(
                name: "PageContents",
                columns: table => new
                {
                    ContentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageLink = table.Column<string>(nullable: true),
                    Introduction = table.Column<string>(nullable: true),
                    Page = table.Column<string>(nullable: true),
                    Tagline = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageContents", x => x.ContentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PageContents");

            migrationBuilder.CreateTable(
                name: "MarketingPageContents",
                columns: table => new
                {
                    ContentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageLink = table.Column<string>(nullable: true),
                    Introduction = table.Column<string>(nullable: true),
                    Tagline = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketingPageContents", x => x.ContentId);
                });
        }
    }
}
