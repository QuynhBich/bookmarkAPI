using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using BookmarkWeb.API.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookmarkWeb.API.Database
{
    public class DataContext: DbContext
    {
        private readonly IHttpContextAccessor _context;

        public DataContext(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DataContext(DbContextOptions<DataContext> options, IHttpContextAccessor context) : base(options)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public DbConnection GetConnection()
        {
            DbConnection _connection = Database.GetDbConnection();
            _connection.Close();
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            return _connection;

        }

        public virtual DbSet<ApiKey> ApiKeys { get; set; }
        public virtual DbSet<Bookmark> Bookmarks { get; set; }
        public virtual DbSet<CallApiLog> CallApiLogs { get; set; }
        public virtual DbSet<Folder> Folders { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RolesOfUser> RolesOfUsers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserToken> UserTokens { get; set; }
        public virtual DbSet<Conversation> Conversations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            QueryFilter.HasQueryFilter(modelBuilder);
            ModelCreate.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }

        private void OnBeforeSaving()
        {
            if (ChangeTracker.HasChanges())
            {
                DateTimeOffset now = DateTimeOffset.Now;
                foreach (var entry in ChangeTracker.Entries())
                {
                    try
                    {
                        if (entry.Entity is Table root)
                        {
                            switch (entry.State)
                            {
                                case EntityState.Added:
                                    {

                                        root.CreatedAt = now;
                                        root.UpdatedAt = root.CreatedAt;
                                        root.UpdatedBy = root.CreatedBy;
                                        root.DelFlag = false;
                                        break;
                                    }
                                case EntityState.Modified:
                                    {
                                        root.UpdatedAt = now;
                                        break;
                                    }
                                case EntityState.Deleted:
                                    {
                                        if (!root.ForceDel)
                                        {
                                            entry.State = EntityState.Modified;
                                            root.UpdatedAt = now;
                                        }
                                        break;
                                    }
                            }
                        }
                    }
                    catch { }
                }
            }
        }

        public async Task RollbackAsync(IDbContextTransaction transaction)
        {
            if (transaction != null)
            {
                await transaction.RollbackAsync();
            }
        }

        public void Rollback(IDbContextTransaction transaction)
        {
            if (transaction != null)
            {
                transaction.Rollback();
            }
        }
    }
}