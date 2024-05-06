using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookmarkWeb.API.Migrations
{
    /// <inheritdoc />
    public partial class AddConversationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_folders_folder_id",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_messages_Bookmarks_bookmarkId",
                table: "messages");

            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_folder_id",
                table: "Bookmarks");

            migrationBuilder.RenameColumn(
                name: "bookmarkId",
                table: "messages",
                newName: "conversation_id");

            migrationBuilder.RenameIndex(
                name: "IX_messages_bookmarkId",
                table: "messages",
                newName: "IX_messages_conversation_id");

            migrationBuilder.RenameColumn(
                name: "folder_id",
                table: "Bookmarks",
                newName: "conversation_id");

            migrationBuilder.AddColumn<long>(
                name: "user_id",
                table: "Bookmarks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Conversation",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Primary key", collation: "ascii_general_ci"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    folder_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false, comment: "Data creation time"),
                    created_by = table.Column<long>(type: "bigint", nullable: false, comment: "Data creator id"),
                    created_ip = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false, comment: "Data creator IP")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true, comment: "Data updated time"),
                    updated_by = table.Column<long>(type: "bigint", nullable: true, comment: "Data updater id"),
                    updated_ip = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false, comment: "Data updater IP")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    deleted_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true, comment: "Data deleted time"),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true, comment: "Data deleter id"),
                    deleted_ip = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false, comment: "Data deleter IP")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    del_flag = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "Flag check deleted data")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversation", x => x.id);
                    table.ForeignKey(
                        name: "FK_Conversation_folders_folder_id",
                        column: x => x.folder_id,
                        principalTable: "folders",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Conversation_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_conversation_id",
                table: "Bookmarks",
                column: "conversation_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_user_id",
                table: "Bookmarks",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Conversation_folder_id",
                table: "Conversation",
                column: "folder_id");

            migrationBuilder.CreateIndex(
                name: "IX_Conversation_user_id",
                table: "Conversation",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Conversation_conversation_id",
                table: "Bookmarks",
                column: "conversation_id",
                principalTable: "Conversation",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_users_user_id",
                table: "Bookmarks",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_messages_Conversation_conversation_id",
                table: "messages",
                column: "conversation_id",
                principalTable: "Conversation",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Conversation_conversation_id",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_users_user_id",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_messages_Conversation_conversation_id",
                table: "messages");

            migrationBuilder.DropTable(
                name: "Conversation");

            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_conversation_id",
                table: "Bookmarks");

            migrationBuilder.DropIndex(
                name: "IX_Bookmarks_user_id",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Bookmarks");

            migrationBuilder.RenameColumn(
                name: "conversation_id",
                table: "messages",
                newName: "bookmarkId");

            migrationBuilder.RenameIndex(
                name: "IX_messages_conversation_id",
                table: "messages",
                newName: "IX_messages_bookmarkId");

            migrationBuilder.RenameColumn(
                name: "conversation_id",
                table: "Bookmarks",
                newName: "folder_id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_messages_Bookmarks_bookmarkId",
                table: "messages",
                column: "bookmarkId",
                principalTable: "Bookmarks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
