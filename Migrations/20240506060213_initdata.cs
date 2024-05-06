using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookmarkWeb.API.Migrations
{
    /// <inheritdoc />
    public partial class initdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "api_keys",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "Primary key auto-increment")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    key = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    from = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    to = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false, comment: "Data creation time"),
                    created_by = table.Column<long>(type: "bigint", nullable: false, comment: "Data creator id"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true, comment: "Data updated time"),
                    updated_by = table.Column<long>(type: "bigint", nullable: true, comment: "Data updater id"),
                    deleted_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true, comment: "Data deleted time"),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true, comment: "Data deleter id"),
                    del_flag = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "Flag check deleted data")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_api_keys", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "call_api_logs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    url = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    query_string = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    body = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    response = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    @class = table.Column<string>(name: "class", type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    method = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    api_method = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_call_out = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    count_recall = table.Column<int>(type: "int", nullable: false),
                    recalling = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false, comment: "Data creation time"),
                    created_by = table.Column<long>(type: "bigint", nullable: false, comment: "Data creator id"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true, comment: "Data updated time"),
                    updated_by = table.Column<long>(type: "bigint", nullable: true, comment: "Data updater id"),
                    deleted_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true, comment: "Data deleted time"),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true, comment: "Data deleter id"),
                    del_flag = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "Flag check deleted data")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_call_api_logs", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(21)", maxLength: 21, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "Primary key auto-increment")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_login = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    last_logout = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false, comment: "Data creation time"),
                    created_by = table.Column<long>(type: "bigint", nullable: false, comment: "Data creator id"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true, comment: "Data updated time"),
                    updated_by = table.Column<long>(type: "bigint", nullable: true, comment: "Data updater id"),
                    deleted_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true, comment: "Data deleted time"),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true, comment: "Data deleter id"),
                    del_flag = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "Flag check deleted data")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Primary key", collation: "ascii_general_ci"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    bookmark_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false, comment: "Data creation time"),
                    created_by = table.Column<long>(type: "bigint", nullable: false, comment: "Data creator id"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true, comment: "Data updated time"),
                    updated_by = table.Column<long>(type: "bigint", nullable: true, comment: "Data updater id"),
                    deleted_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true, comment: "Data deleted time"),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true, comment: "Data deleter id"),
                    del_flag = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "Flag check deleted data")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Conversations_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "folders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Primary key", collation: "ascii_general_ci"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false, comment: "Data creation time"),
                    created_by = table.Column<long>(type: "bigint", nullable: false, comment: "Data creator id"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true, comment: "Data updated time"),
                    updated_by = table.Column<long>(type: "bigint", nullable: true, comment: "Data updater id"),
                    deleted_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true, comment: "Data deleted time"),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true, comment: "Data deleter id"),
                    del_flag = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "Flag check deleted data")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_folders", x => x.id);
                    table.ForeignKey(
                        name: "FK_folders_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RolesOfUsers",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    role_id = table.Column<string>(type: "varchar(21)", maxLength: 21, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false, comment: "Data creation time"),
                    created_by = table.Column<long>(type: "bigint", nullable: false, comment: "Data creator id"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true, comment: "Data updated time"),
                    updated_by = table.Column<long>(type: "bigint", nullable: true, comment: "Data updater id"),
                    deleted_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true, comment: "Data deleted time"),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true, comment: "Data deleter id"),
                    del_flag = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "Flag check deleted data")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesOfUsers", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "FK_RolesOfUsers_Roles_role_id",
                        column: x => x.role_id,
                        principalTable: "Roles",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_RolesOfUsers_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_tokens",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, comment: "Primary key auto-increment")
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    jwt_token = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    refresh_token = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    validate_token = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    timeout = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false, comment: "Data creation time"),
                    created_by = table.Column<long>(type: "bigint", nullable: false, comment: "Data creator id"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true, comment: "Data updated time"),
                    updated_by = table.Column<long>(type: "bigint", nullable: true, comment: "Data updater id"),
                    deleted_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true, comment: "Data deleted time"),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true, comment: "Data deleter id"),
                    del_flag = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "Flag check deleted data")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_tokens", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_tokens_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Primary key", collation: "ascii_general_ci"),
                    conversation_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    isNoted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false, comment: "Data creation time"),
                    created_by = table.Column<long>(type: "bigint", nullable: false, comment: "Data creator id"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true, comment: "Data updated time"),
                    updated_by = table.Column<long>(type: "bigint", nullable: true, comment: "Data updater id"),
                    deleted_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true, comment: "Data deleted time"),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true, comment: "Data deleter id"),
                    del_flag = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "Flag check deleted data")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.id);
                    table.ForeignKey(
                        name: "FK_messages_Conversations_conversation_id",
                        column: x => x.conversation_id,
                        principalTable: "Conversations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_messages_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bookmarks",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Primary key", collation: "ascii_general_ci"),
                    conversation_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    folder_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    domain = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    note = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    image = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: false, comment: "Data creation time"),
                    created_by = table.Column<long>(type: "bigint", nullable: false, comment: "Data creator id"),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true, comment: "Data updated time"),
                    updated_by = table.Column<long>(type: "bigint", nullable: true, comment: "Data updater id"),
                    deleted_at = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true, comment: "Data deleted time"),
                    deleted_by = table.Column<long>(type: "bigint", nullable: true, comment: "Data deleter id"),
                    del_flag = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "Flag check deleted data")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookmarks", x => x.id);
                    table.ForeignKey(
                        name: "FK_Bookmarks_Conversations_conversation_id",
                        column: x => x.conversation_id,
                        principalTable: "Conversations",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Bookmarks_folders_folder_id",
                        column: x => x.folder_id,
                        principalTable: "folders",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Bookmarks_users_user_id",
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
                name: "IX_Bookmarks_folder_id",
                table: "Bookmarks",
                column: "folder_id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookmarks_user_id",
                table: "Bookmarks",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_user_id",
                table: "Conversations",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_folders_user_id",
                table: "folders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_messages_conversation_id",
                table: "messages",
                column: "conversation_id");

            migrationBuilder.CreateIndex(
                name: "IX_messages_user_id",
                table: "messages",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_RolesOfUsers_role_id",
                table: "RolesOfUsers",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_tokens_user_id",
                table: "user_tokens",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_email",
                table: "users",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "IX_users_username",
                table: "users",
                column: "username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "api_keys");

            migrationBuilder.DropTable(
                name: "Bookmarks");

            migrationBuilder.DropTable(
                name: "call_api_logs");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "RolesOfUsers");

            migrationBuilder.DropTable(
                name: "user_tokens");

            migrationBuilder.DropTable(
                name: "folders");

            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
