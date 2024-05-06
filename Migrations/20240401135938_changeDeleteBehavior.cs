using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookmarkWeb.API.Migrations
{
    /// <inheritdoc />
    public partial class changeDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_messages_Conversations_conversation_id",
                table: "messages");

            migrationBuilder.AddForeignKey(
                name: "FK_messages_Conversations_conversation_id",
                table: "messages",
                column: "conversation_id",
                principalTable: "Conversations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_messages_Conversations_conversation_id",
                table: "messages");

            migrationBuilder.AddForeignKey(
                name: "FK_messages_Conversations_conversation_id",
                table: "messages",
                column: "conversation_id",
                principalTable: "Conversations",
                principalColumn: "id");
        }
    }
}
