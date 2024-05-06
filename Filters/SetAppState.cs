using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookmarkWeb.API.Models;
using BookmarkWeb.API.Models.Common.Schemas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookmarkWeb.API.Filters
{
    public class SetAppState: ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                IAppStateModel _appStateModel = filterContext.HttpContext.RequestServices.GetService<IAppStateModel>();
                if (_appStateModel == null)
                {
                    filterContext.Result = new BadRequestObjectResult("App state model is required");
                    return;
                }
                AppState.Instance.CurrentUser = _appStateModel.GetUser();
            }
            catch (Exception e)
            {
                filterContext.Result = new BadRequestObjectResult(e.Message);
                return;
            }
            base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
            try
            {
            }
            catch
            {
            }
        }
    }
}