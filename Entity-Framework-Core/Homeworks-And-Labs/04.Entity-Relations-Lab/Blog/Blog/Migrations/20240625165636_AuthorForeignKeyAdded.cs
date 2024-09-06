using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogDemo.Migrations
{
    public partial class AuthorForeignKeyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Authors_BlogId",
                schema: "blg",
                table: "Authors");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_AuthorId",
                schema: "blg",
                table: "Blog",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_BlogId",
                schema: "blg",
                table: "Authors",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blog_Authors_AuthorId",
                schema: "blg",
                table: "Blog",
                column: "AuthorId",
                principalSchema: "blg",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blog_Authors_AuthorId",
                schema: "blg",
                table: "Blog");

            migrationBuilder.DropIndex(
                name: "IX_Blog_AuthorId",
                schema: "blg",
                table: "Blog");

            migrationBuilder.DropIndex(
                name: "IX_Authors_BlogId",
                schema: "blg",
                table: "Authors");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_BlogId",
                schema: "blg",
                table: "Authors",
                column: "BlogId",
                unique: true,
                filter: "[BlogId] IS NOT NULL");
        }
    }
}
