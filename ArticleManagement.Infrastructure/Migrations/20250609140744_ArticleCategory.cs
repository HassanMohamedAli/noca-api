using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ArticleCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArticleCategory",
                table: "Articles",
                newName: "ArticleCategoryId");

            migrationBuilder.CreateTable(
                name: "ArticleCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleCategoryId",
                table: "Articles",
                column: "ArticleCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_ArticleCategory_ArticleCategoryId",
                table: "Articles",
                column: "ArticleCategoryId",
                principalTable: "ArticleCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_ArticleCategory_ArticleCategoryId",
                table: "Articles");

            migrationBuilder.DropTable(
                name: "ArticleCategory");

            migrationBuilder.DropIndex(
                name: "IX_Articles_ArticleCategoryId",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "ArticleCategoryId",
                table: "Articles",
                newName: "ArticleCategory");
        }
    }
}
