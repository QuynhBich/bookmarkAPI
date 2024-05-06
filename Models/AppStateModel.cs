using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookmarkWeb.API.Database;
using BookmarkWeb.API.Models.Common.Schemas;
using BookmarkWeb.API.Services;

namespace BookmarkWeb.API.Models
{
    public interface IAppStateModel
    {
        User GetUser(long userId = 0);
    }
    public class AppStateModel: IAppStateModel
    {
        private readonly IIdentityService _identityService;
        private readonly DataContext _context;
        public AppStateModel(
            IIdentityService identityService,
            DataContext context
        )
        {
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public User GetUser(long userId = 0)
        {
            try
            {
                if (userId == 0)
                {
                    userId = _identityService.GetUserId();
                }
                var user = _context.Users.Where(x => x.Id == userId)
                    .Select(x => new User()
                    {
                        Id = x.Id,
                        Username = x.Username,
                        Email = x.Email,
                        RoleId = x.Roles.Any() ? x.Roles.FirstOrDefault().RoleId : "USER"
                    }).FirstOrDefault();
                return user;
            }
            catch
            {
                return null;
            }
        }
    }
}