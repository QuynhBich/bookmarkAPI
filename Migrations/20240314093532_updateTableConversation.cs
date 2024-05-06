using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookmarkWeb.API.Migrations
{
    /// <inheritdoc />
    public partial class updateTableConversation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Conversation_conversation_id",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Conversation_users_user_id",
                table: "Conversation");

            migrationBuilder.DropForeignKey(
                name: "FK_messages_Conversation_conversation_id",
                table: "messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conversation",
                table: "Conversation");

            migrationBuilder.RenameTable(
                name: "Conversation",
                newName: "Conversations");

            migrationBuilder.RenameIndex(
                name: "IX_Conversation_user_id",
                table: "Conversations",
                newName: "IX_Conversations_user_id");

            migrationBuilder.AddColumn<Guid>(
                name: "bookmark_id",
                table: "Conversations",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conversations",
                table: "Conversations",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Conversations_conversation_id",
                table: "Bookmarks",
                column: "conversation_id",
                principalTable: "Conversations",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Conversations_users_user_id",
                table: "Conversations",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_messages_Conversations_conversation_id",
                table: "messages",
                column: "conversation_id",
                principalTable: "Conversations",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookmarks_Conversations_conversation_id",
                table: "Bookmarks");

            migrationBuilder.DropForeignKey(
                name: "FK_Conversations_users_user_id",
                table: "Conversations");

            migrationBuilder.DropForeignKey(
                name: "FK_messages_Conversations_conversation_id",
                table: "messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conversations",
                table: "Conversations");

            migrationBuilder.DropColumn(
                name: "bookmark_id",
                table: "Conversations");

            migrationBuilder.RenameTable(
                name: "Conversations",
                newName: "Conversation");

            migrationBuilder.RenameIndex(
                name: "IX_Conversations_user_id",
                table: "Conversation",
                newName: "IX_Conversation_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conversation",
                table: "Conversation",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookmarks_Conversation_conversation_id",
                table: "Bookmarks",
                column: "conversation_id",
                principalTable: "Conversation",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Conversation_users_user_id",
                table: "Conversation",
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
    }
}
