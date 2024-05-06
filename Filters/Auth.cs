using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookmarkWeb.API.Filters
{
    public class Auth
    {
        public Auth()
        {
        }
        /// <summary>
        /// Ghi đè phương thức dùng để lọc request.
        /// <para>Author: QuyPN</para>
        /// <para>Created: 08/08/2020</para>
        /// </summary>
        /// <param name="filterContext">Data của 1 request.</param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var user = context.HttpContext.User;

                if (!user.Identity.IsAuthenticated)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }
            }
            catch (Exception e)
            {
                context.Result = new BadRequestObjectResult(e.Message);
                return;
            }
        }
    }
}