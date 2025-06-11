using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddArticleCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleBicycleCategories_Articles_ArticleId",
                table: "ArticleBicycleCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleBicycleCategories_Articles_ArticleId",
                table: "ArticleBicycleCategories",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleBicycleCategories_Articles_ArticleId",
                table: "ArticleBicycleCategories");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleBicycleCategories_Articles_ArticleId",
                table: "ArticleBicycleCategories",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id");
        }
    }
}
