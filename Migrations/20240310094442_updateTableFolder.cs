using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookmarkWeb.API.Migrations
{
    /// <inheritdoc />
    public partial class updateTableFolder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conversation_folders_folder_id",
                table: "Conversation");

            migrationBuilder.DropIndex(
                name: "IX_Conversation_folder_id",
                table: "Conversation");

            migrationBuilder.DropColumn(
                name: "folder_id",
                table: "Conversation");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "folders",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "folder_id",
                table: "Bookmarks",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_folder_id",
                table: "Bookmarks",
                column: "folder_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_folders_folder_id",
                table: "Bookmarks",
                column: "folder_id",
                principalTable: "folders",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_folders_folder_id",
                table: "Bookmarks");

            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_folder_id",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "folder_id",
                table: "Bookmarks");

            migrationBuilder.UpdateData(
                table: "folders",
                keyColumn: "description",
                keyValue: null,
                column: "description",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "folders",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "folder_id",
                table: "Conversation",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Conversation_folder_id",
                table: "Conversation",
                column: "folder_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Conversation_folders_folder_id",
                table: "Conversation",
                column: "folder_id",
                principalTable: "folders",
                principalColumn: "id");
        }
    }
}
