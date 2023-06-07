using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMedia.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class Init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_InnerCommentId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "InnerCommentId",
                table: "Comments",
                newName: "ReplyCommnetId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_InnerCommentId",
                table: "Comments",
                newName: "IX_Comments_ReplyCommnetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ReplyCommnetId",
                table: "Comments",
                column: "ReplyCommnetId",
                principalTable: "Comments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ReplyCommnetId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "ReplyCommnetId",
                table: "Comments",
                newName: "InnerCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ReplyCommnetId",
                table: "Comments",
                newName: "IX_Comments_InnerCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_InnerCommentId",
                table: "Comments",
                column: "InnerCommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }
    }
}
