﻿// <auto-generated />
using System;
using BookmarkWeb.API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookmarkWeb.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240506060213_initdata")]
    partial class initdata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BookmarkWeb.API.Database.Entities.ApiKey", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasColumnOrder(1)
                        .HasComment("Primary key auto-increment");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at")
                        .HasComment("Data creation time");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by")
                        .HasComment("Data creator id");

                    b.Property<bool>("DelFlag")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("del_flag")
                        .HasComment("Flag check deleted data");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_at")
                        .HasComment("Data deleted time");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("deleted_by")
                        .HasComment("Data deleter id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("description");

                    b.Property<DateTimeOffset?>("From")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("from");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("key");

                    b.Property<DateTimeOffset?>("To")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("to");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at")
                        .HasComment("Data updated time");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by")
                        .HasComment("Data updater id");

                    b.HasKey("Id");

                    b.ToTable("api_keys");
                });

            modelBuilder.Entity("BookmarkWeb.API.Database.Entities.Bookmark", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id")
                        .HasColumnOrder(1)
                        .HasComment("Primary key");

                    b.Property<Guid?>("ConversationId")
                        .HasColumnType("char(36)")
                        .HasColumnName("conversation_id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at")
                        .HasComment("Data creation time");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by")
                        .HasComment("Data creator id");

                    b.Property<bool>("DelFlag")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("del_flag")
                        .HasComment("Flag check deleted data");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_at")
                        .HasComment("Data deleted time");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("deleted_by")
                        .HasComment("Data deleter id");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("description");

                    b.Property<string>("Domain")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("domain");

                    b.Property<Guid?>("FolderId")
                        .IsRequired()
                        .HasColumnType("char(36)")
                        .HasColumnName("folder_id");

                    b.Property<string>("Image")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)")
                        .HasColumnName("image");

                    b.Property<string>("Note")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("note");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("title");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at")
                        .HasComment("Data updated time");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by")
                        .HasComment("Data updater id");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("url");

                    b.Property<long?>("UserId")
                        .IsRequired()
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("ConversationId")
                        .IsUnique();

                    b.HasIndex("FolderId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookmarks");
                });

            modelBuilder.Entity("BookmarkWeb.API.Database.Entities.CallApiLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id")
                        .HasColumnOrder(1);

                    b.Property<string>("ApiMethod")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("api_method");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("body");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("class");

                    b.Property<int>("CountRecall")
                        .HasColumnType("int")
                        .HasColumnName("count_recall");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at")
                        .HasComment("Data creation time");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by")
                        .HasComment("Data creator id");

                    b.Property<bool>("DelFlag")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("del_flag")
                        .HasComment("Flag check deleted data");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_at")
                        .HasComment("Data deleted time");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("deleted_by")
                        .HasComment("Data deleter id");

                    b.Property<bool>("IsCallOut")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_call_out");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("method");

                    b.Property<string>("QueryString")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("query_string");

                    b.Property<bool>("Recalling")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("recalling");

                    b.Property<string>("Response")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("response");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("status");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at")
                        .HasComment("Data updated time");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by")
                        .HasComment("Data updater id");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("url");

                    b.HasKey("Id");

                    b.ToTable("call_api_logs");
                });

            modelBuilder.Entity("BookmarkWeb.API.Database.Entities.Conversation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id")
                        .HasColumnOrder(1)
                        .HasComment("Primary key");

                    b.Property<Guid?>("BookmarkId")
                        .HasColumnType("char(36)")
                        .HasColumnName("bookmark_id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at")
                        .HasComment("Data creation time");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by")
                        .HasComment("Data creator id");

                    b.Property<bool>("DelFlag")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("del_flag")
                        .HasComment("Flag check deleted data");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_at")
                        .HasComment("Data deleted time");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("deleted_by")
                        .HasComment("Data deleter id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at")
                        .HasComment("Data updated time");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by")
                        .HasComment("Data updater id");

                    b.Property<long?>("UserId")
                        .IsRequired()
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Conversations");
                });

            modelBuilder.Entity("BookmarkWeb.API.Database.Entities.Folder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id")
                        .HasColumnOrder(1)
                        .HasComment("Primary key");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at")
                        .HasComment("Data creation time");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by")
                        .HasComment("Data creator id");

                    b.Property<bool>("DelFlag")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("del_flag")
                        .HasComment("Flag check deleted data");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_at")
                        .HasComment("Data deleted time");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("deleted_by")
                        .HasComment("Data deleter id");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at")
                        .HasComment("Data updated time");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by")
                        .HasComment("Data updater id");

                    b.Property<long?>("UserId")
                        .IsRequired()
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("folders");
                });

            modelBuilder.Entity("BookmarkWeb.API.Database.Entities.Message", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id")
                        .HasColumnOrder(1)
                        .HasComment("Primary key");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("content");

                    b.Property<Guid>("ConversationId")
                        .HasColumnType("char(36)")
                        .HasColumnName("conversation_id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at")
                        .HasComment("Data creation time");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by")
                        .HasComment("Data creator id");

                    b.Property<bool>("DelFlag")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("del_flag")
                        .HasComment("Flag check deleted data");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_at")
                        .HasComment("Data deleted time");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("deleted_by")
                        .HasComment("Data deleter id");

                    b.Property<bool>("IsNoted")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("isNoted");

                    b.Property<string>("Note")
                        .HasColumnType("longtext")
                        .HasColumnName("note");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at")
                        .HasComment("Data updated time");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by")
                        .HasComment("Data updater id");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("ConversationId");

                    b.HasIndex("UserId");

                    b.ToTable("messages");
                });

            modelBuilder.Entity("BookmarkWeb.API.Database.Entities.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(21)
                        .HasColumnType("varchar(21)")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BookmarkWeb.API.Database.Entities.RolesOfUser", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id")
                        .HasColumnOrder(1);

                    b.Property<string>("RoleId")
                        .HasMaxLength(21)
                        .HasColumnType("varchar(21)")
                        .HasColumnName("role_id")
                        .HasColumnOrder(2);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at")
                        .HasComment("Data creation time");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by")
                        .HasComment("Data creator id");

                    b.Property<bool>("DelFlag")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("del_flag")
                        .HasComment("Flag check deleted data");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_at")
                        .HasComment("Data deleted time");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("deleted_by")
                        .HasComment("Data deleter id");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at")
                        .HasComment("Data updated time");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by")
                        .HasComment("Data updater id");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolesOfUsers");
                });

            modelBuilder.Entity("BookmarkWeb.API.Database.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasColumnOrder(1)
                        .HasComment("Primary key auto-increment");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at")
                        .HasComment("Data creation time");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by")
                        .HasComment("Data creator id");

                    b.Property<bool>("DelFlag")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("del_flag")
                        .HasComment("Flag check deleted data");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_at")
                        .HasComment("Data deleted time");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("deleted_by")
                        .HasComment("Data deleter id");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<DateTimeOffset?>("LastLogin")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("last_login");

                    b.Property<DateTimeOffset?>("LastLogout")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("last_logout");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phone");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at")
                        .HasComment("Data updated time");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by")
                        .HasComment("Data updater id");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.HasIndex("Username");

                    b.ToTable("users");
                });

            modelBuilder.Entity("BookmarkWeb.API.Database.Entities.UserToken", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .HasColumnOrder(1)
                        .HasComment("Primary key auto-increment");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at")
                        .HasComment("Data creation time");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by")
                        .HasComment("Data creator id");

                    b.Property<bool>("DelFlag")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("del_flag")
                        .HasComment("Flag check deleted data");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("deleted_at")
                        .HasComment("Data deleted time");

                    b.Property<long?>("DeletedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("deleted_by")
                        .HasComment("Data deleter id");

                    b.Property<string>("JwtToken")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("jwt_token");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("refresh_token");

                    b.Property<DateTimeOffset?>("Timeout")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("timeout");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at")
                        .HasComment("Data updated time");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint")
                        .HasColumnName("updated_by")
                        .HasComment("Data updater id");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.Property<string>("ValidateToken")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("validate_token");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("user_tokens");
                });

            modelBuilder.Entity("BookmarkWeb.API.Database.Entities.Bookmark", b =>
                {
                    b.HasOne("BookmarkWeb.API.Database.Entities.Conversation", "Conversation")
                        .WithOne("Bookmark")
                        .HasForeignKey("BookmarkWeb.API.Database.Entities.Bookmark", "ConversationId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("BookmarkWeb.API.Database.Entities.Folder", "Folder")
                        .WithMany("Bookmarks")
                        .HasForeignKey("FolderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BookmarkWeb.API.Database.Entities.User", "User")
                        .WithMany("Bookmarks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Conversation");

                    b.Navigation("Folder");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookmarkWeb.API.Database.Entities.Conversation", b =>
                {
                    b.HasOne("BookmarkWeb.API.Database.Entities.User", "User")
                        .WithMany("Conversations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookmarkWeb.API.Database.Entities.Folder", b =>
                {
                    b.HasOne("BookmarkWeb.API.Database.Entities.User", "User")
                        .WithMany("Folders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookmarkWeb.API.Database.Entities.Message", b =>
                {
                    b.HasOne("BookmarkWeb.API.Database.Entities.Conversation", "Conversation")
                        .WithMany("Messages")
                        .HasForeignKey("ConversationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookmarkWeb.API.Database.Entities.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Conversation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookmarkWeb.API.Database.Entities.RolesOfUser", b =>
                {
                    b.HasOne("BookmarkWeb.API.Database.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BookmarkWeb.API.Database.Entities.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookmarkWeb.API.Database.Entities.UserToken", b =>
                {
                    b.HasOne("BookmarkWeb.API.Database.Entities.User", "User")
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookmarkWeb.API.Database.Entities.Conversation", b =>
                {
                    b.Navigation("Bookmark")
                        .IsRequired();

                    b.Navigation("Messages");
                });

            modelBuilder.Entity("BookmarkWeb.API.Database.Entities.Folder", b =>
                {
                    b.Navigation("Bookmarks");
                });

            modelBuilder.Entity("BookmarkWeb.API.Database.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BookmarkWeb.API.Database.Entities.User", b =>
                {
                    b.Navigation("Bookmarks");

                    b.Navigation("Conversations");

                    b.Navigation("Folders");

                    b.Navigation("Messages");

                    b.Navigation("Roles");

                    b.Navigation("Tokens");
                });
#pragma warning restore 612, 618
        }
    }
}
