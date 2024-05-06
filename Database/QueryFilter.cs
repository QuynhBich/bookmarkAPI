using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookmarkWeb.API.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookmarkWeb.API.Database
{
    public class QueryFilter
    {
        public static ModelBuilder HasQueryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApiKey>().HasQueryFilter(x => !x.DelFlag);
            modelBuilder.Entity<Bookmark>().HasQueryFilter(x => !x.DelFlag);
            modelBuilder.Entity<CallApiLog>().HasQueryFilter(x => !x.DelFlag);
            modelBuilder.Entity<Folder>().HasQueryFilter(x => !x.DelFlag);
            modelBuilder.Entity<Message>().HasQueryFilter(x => !x.DelFlag);
            modelBuilder.Entity<RolesOfUser>().HasQueryFilter(x => !x.DelFlag);
            modelBuilder.Entity<User>().HasQueryFilter(x => !x.DelFlag);
            modelBuilder.Entity<UserToken>().HasQueryFilter(x => !x.DelFlag);
            return modelBuilder;
        }
    }
}