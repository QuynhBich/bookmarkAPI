using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookmarkWeb.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRollTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "del_flag",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "deleted_by",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "Roles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "created_at",
                table: "Roles",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                comment: "Data creation time");

            migrationBuilder.AddColumn<long>(
                name: "created_by",
                table: "Roles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                comment: "Data creator id");

            migrationBuilder.AddColumn<bool>(
                name: "del_flag",
                table: "Roles",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                comment: "Flag check deleted data");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "deleted_at",
                table: "Roles",
                type: "datetime(6)",
                nullable: true,
                comment: "Data deleted time");

            migrationBuilder.AddColumn<long>(
                name: "deleted_by",
                table: "Roles",
                type: "bigint",
                nullable: true,
                comment: "Data deleter id");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "updated_at",
                table: "Roles",
                type: "datetime(6)",
                nullable: true,
                comment: "Data updated time");

            migrationBuilder.AddColumn<long>(
                name: "updated_by",
                table: "Roles",
                type: "bigint",
                nullable: true,
                comment: "Data updater id");
        }
    }
}
