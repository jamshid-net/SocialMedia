using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class Init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_CommentId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Comments",
                newName: "InnerCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CommentId",
                table: "Comments",
                newName: "IX_Comments_InnerCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_InnerCommentId",
                table: "Comments",
                column: "InnerCommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_InnerCommentId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "InnerCommentId",
                table: "Comments",
                newName: "CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_InnerCommentId",
                table: "Comments",
                newName: "IX_Comments_CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_CommentId",
                table: "Comments",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }
    }
}
