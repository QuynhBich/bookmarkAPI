using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BookmarkWeb.API.Database;
using BookmarkWeb.API.Services;

namespace BookmarkWeb.API.Models
{
    public class BaseModel
    {
        protected readonly DataContext _context;
        protected ILogger _logger;
        protected readonly IIdentityService _identityService;

        public BaseModel()
        {
        }

        public BaseModel(
            IServiceProvider provider
        )
        {
            DataContext context = provider.GetService<DataContext>();
            _context = context ?? throw new ArgumentNullException(nameof(context));
            IIdentityService identityService = provider.GetService<IIdentityService>();
        }

        protected virtual void LogInfo(string message, [CallerMemberName] string method = null)
        {
            _logger?.LogInformation($"[{GetType().Name}.{method}] {message}");
        }

        protected virtual void LogError(string message, [CallerMemberName] string method = null)
        {
            _logger?.LogError($"[{GetType().Name}.{method}] Exception: {message}");
        }
    }
}