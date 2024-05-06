using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookmarkWeb.API.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookmarkWeb.API.Database
{
    public class ModelCreate
    {
        public static ModelBuilder OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithOne(e => e.Role)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder
                .Entity<RolesOfUser>()
                .HasKey(e => new
                {
                    e.UserId,
                    e.RoleId
                });
            
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(e => e.Tokens)
                    .WithOne(e => e.User)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasMany(e => e.Roles)
                    .WithOne(e => e.User)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasMany(e => e.Folders)
                    .WithOne(e => e.User)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasMany(e => e.Messages)
                    .WithOne(e => e.User)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.NoAction);
                
                entity.HasMany(e => e.Bookmarks)
                    .WithOne(e => e.User)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.NoAction);
                
                entity.HasMany(e => e.Conversations)
                    .WithOne(e => e.User)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasIndex(e => e.Email);

                entity.HasIndex(e => e.Username);
            });

            modelBuilder.Entity<Folder>(entity =>
            {
                entity.HasMany(e => e.Bookmarks)
                    .WithOne(e => e.Folder)
                    .HasForeignKey(e => e.FolderId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasIndex(e => e.ConversationId);
                entity.Property(e => e.UserId).IsRequired(false);
                entity.Property(e => e.Note).IsRequired(false);
            });

            modelBuilder.Entity<Bookmark>(entity =>
            {
                entity.Property(e => e.ConversationId).IsRequired(false);
                entity.HasOne(e => e.Conversation)
                    .WithOne(e => e.Bookmark)
                    .HasForeignKey<Conversation>(e => e.BookmarkId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Conversation>(entity =>
            {
                entity.HasMany(e => e.Messages)
                    .WithOne(e => e.Conversation)
                    .HasForeignKey(e => e.ConversationId)
                    .OnDelete(DeleteBehavior.Cascade);
                
                entity.HasOne(e => e.Bookmark)
                    .WithOne(e => e.Conversation)
                    .HasForeignKey<Bookmark>(e => e.ConversationId)
                    .OnDelete(DeleteBehavior.NoAction);
            });


            return modelBuilder;
        }
    }
}