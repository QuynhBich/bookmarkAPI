using System.Net;
using BookmarkWeb.API.Models.Common.Schemas;
using BookmarkWeb.API.Models.Folders;
using BookmarkWeb.API.Models.Folders.Schemas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookmarkWeb.API.Controllers
{
    [Route("folders")]
    [Filters.SetAppState]
    public class FolderController: ControllerBase
    {
        private readonly IFolderModel _folderModel;

        public FolderController(IFolderModel folderModel)
        {
            _folderModel = folderModel;
        }

        [HttpGet]
        [ProducesResponseType(typeof(FolderDto), (int)HttpStatusCode.OK)]
        [Authorize]
        public async Task<IActionResult> GetListBookmark()
        {
            try
            {
                return Ok(await _folderModel.GetListFolder());
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Error = e.Message });
            }
        }

        [HttpPost("create-folder")]
        [Authorize]
        public async Task<ActionResult<FolderDto>> CreateNewFolder(FolderCreateModel folder)
        {
            try
            {
                var response = await _folderModel.CreateNewFolder(folder);
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Error = e.Message });
            }
        }
    }
}