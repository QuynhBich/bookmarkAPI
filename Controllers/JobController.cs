using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookmarkWeb.API.Controllers
{
    [Route("jobs")]
    public class JobController: ControllerBase
    {

        public JobController()
        {
        }

        [HttpGet]
        public ActionResult AsyncJob()
        {
            return Ok();
        }
    }
}