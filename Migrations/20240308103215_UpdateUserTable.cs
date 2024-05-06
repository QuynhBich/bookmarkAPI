using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookmarkWeb.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_ip",
                table: "users");

            migrationBuilder.DropColumn(
                name: "deleted_ip",
                table: "users");

            migrationBuilder.DropColumn(
                name: "updated_ip",
                table: "users");

            migrationBuilder.DropColumn(
                name: "created_ip",
                table: "user_tokens");

            migrationBuilder.DropColumn(
                name: "deleted_ip",
                table: "user_tokens");

            migrationBuilder.DropColumn(
                name: "updated_ip",
                table: "user_tokens");

            migrationBuilder.DropColumn(
                name: "created_ip",
                table: "RolesOfUsers");

            migrationBuilder.DropColumn(
                name: "deleted_ip",
                table: "RolesOfUsers");

            migrationBuilder.DropColumn(
                name: "updated_ip",
                table: "RolesOfUsers");

            migrationBuilder.DropColumn(
                name: "created_ip",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "deleted_ip",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "updated_ip",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "created_ip",
                table: "messages");

            migrationBuilder.DropColumn(
                name: "deleted_ip",
                table: "messages");

            migrationBuilder.DropColumn(
                name: "updated_ip",
                table: "messages");

            migrationBuilder.DropColumn(
                name: "created_ip",
                table: "folders");

            migrationBuilder.DropColumn(
                name: "deleted_ip",
                table: "folders");

            migrationBuilder.DropColumn(
                name: "updated_ip",
                table: "folders");

            migrationBuilder.DropColumn(
                name: "created_ip",
                table: "Conversation");

            migrationBuilder.DropColumn(
                name: "deleted_ip",
                table: "Conversation");

            migrationBuilder.DropColumn(
                name: "updated_ip",
                table: "Conversation");

            migrationBuilder.DropColumn(
                name: "created_ip",
                table: "call_api_logs");

            migrationBuilder.DropColumn(
                name: "deleted_ip",
                table: "call_api_logs");

            migrationBuilder.DropColumn(
                name: "updated_ip",
                table: "call_api_logs");

            migrationBuilder.DropColumn(
                name: "created_ip",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "deleted_ip",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "updated_ip",
                table: "Bookmarks");

            migrationBuilder.DropColumn(
                name: "created_ip",
                table: "api_keys");

            migrationBuilder.DropColumn(
                name: "deleted_ip",
                table: "api_keys");

            migrationBuilder.DropColumn(
                name: "updated_ip",
                table: "api_keys");

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "users",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "users",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "phone",
                keyValue: null,
                column: "phone",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "phone",
                table: "users",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "email",
                keyValue: null,
                column: "email",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "users",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "created_ip",
                table: "users",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data creator IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "deleted_ip",
                table: "users",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data deleter IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "updated_ip",
                table: "users",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data updater IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "created_ip",
                table: "user_tokens",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data creator IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "deleted_ip",
                table: "user_tokens",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data deleter IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "updated_ip",
                table: "user_tokens",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data updater IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "created_ip",
                table: "RolesOfUsers",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data creator IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "deleted_ip",
                table: "RolesOfUsers",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data deleter IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "updated_ip",
                table: "RolesOfUsers",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data updater IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "created_ip",
                table: "Roles",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data creator IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "deleted_ip",
                table: "Roles",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data deleter IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "updated_ip",
                table: "Roles",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data updater IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "created_ip",
                table: "messages",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data creator IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "deleted_ip",
                table: "messages",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data deleter IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "updated_ip",
                table: "messages",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data updater IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "created_ip",
                table: "folders",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data creator IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "deleted_ip",
                table: "folders",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data deleter IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "updated_ip",
                table: "folders",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data updater IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "created_ip",
                table: "Conversation",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data creator IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "deleted_ip",
                table: "Conversation",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data deleter IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "updated_ip",
                table: "Conversation",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data updater IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "created_ip",
                table: "call_api_logs",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data creator IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "deleted_ip",
                table: "call_api_logs",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data deleter IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "updated_ip",
                table: "call_api_logs",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data updater IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "created_ip",
                table: "Bookmarks",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data creator IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "deleted_ip",
                table: "Bookmarks",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data deleter IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "updated_ip",
                table: "Bookmarks",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data updater IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "created_ip",
                table: "api_keys",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data creator IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "deleted_ip",
                table: "api_keys",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data deleter IP")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "updated_ip",
                table: "api_keys",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                comment: "Data updater IP")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
