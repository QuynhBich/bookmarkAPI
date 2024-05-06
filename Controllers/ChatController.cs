using System.Net;
using BookmarkWeb.API.Models.Chats;
using BookmarkWeb.API.Models.Chats.Schemas;
using BookmarkWeb.API.Models.Common.Schemas;
using BookmarkWeb.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookmarkWeb.API.Controllers
{
    [Route("chats")]
    [Filters.SetAppState]
    public class ChatController: ControllerBase
    {
        private readonly IChatsModel _chatsModel;
        private readonly IChatService _chatService;

        public ChatController(
            IChatsModel chatsModel,
            IServiceProvider provider,
            IChatService chatService
        )
        {
            _chatsModel = chatsModel ?? throw new ArgumentNullException(nameof(chatsModel));
            _chatService = chatService;
        }

        // [HttpGet]
        // public async Task<string> Demo()
        // {
        //     var result = await _chatService.SummaryFileAsync("abc", "abc");
        //     return result;
        // }

        [HttpPost("save-message")]
        [Authorize]
        public async Task OnSaveMessage([FromBody]Conversation data)
        {
            ResponseInfo result = new();
            try {
                result = await _chatsModel.SaveMessage(data);
            }
            catch (Exception e)
            {
                result.Exception(e);
            }
        }

        [HttpPost("create-new-conversation")]
        [Authorize]
        public async Task CreateNewConversation(Conversation data)
        {
            ResponseInfo result = new();
            try {
                result = await _chatsModel.CreateNewConversation(data);
            }
            catch (Exception e)
            {
                result.Exception(e);
            }
        }

        [HttpGet("get-messages/{conversationId}")]
        [Authorize]
        public async Task<IActionResult> GetMessage([FromRoute]string conversationId)
        {
            try {
                return Ok(await _chatsModel.GetMessage(conversationId));
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Error = e.Message });
            }
        }

        [HttpGet("get-storage-messages")]
        [Authorize]
        public async Task<IActionResult> GetStorageMessage()
        {
            try {
                return Ok(await _chatsModel.GetStorageMessage());
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Error = e.Message });
            }
        }

        [HttpPost("delete-conversation/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteConversation (string id)
        {
            try
            {
                return Ok(await _chatsModel.DeleteConversation(id));
            } 
            catch (Exception e)
            {
                return StatusCode(500, new { Error = e.Message });
            }
        }

        [HttpPost("update-notepad")]
        [Authorize]
        public async Task<IActionResult> UpdateNotepad ([FromBody]InputMessage inputMessage)
        {
            try
            {
                return Ok(await _chatsModel.UpdateNotePad(inputMessage));
            } 
            catch (Exception e)
            {
                return StatusCode(500, new { Error = e.Message });
            }
        }

        [HttpPost("highlight-message")]
        [Authorize]
        public async Task<IActionResult> HighlightMessage ([FromBody]InputMessage inputMessage)
        {
            try
            {
                return Ok(await _chatsModel.Highlight(inputMessage));
            } 
            catch (Exception e)
            {
                return StatusCode(500, new { Error = e.Message });
            }
        }

        [HttpPost("delete/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteStorageMessage (string id)
        {
            try
            {
                return Ok(await _chatsModel.DeleteStorageMessage(id));
            } 
            catch (Exception e)
            {
                return StatusCode(500, new { Error = e.Message });
            }
        }
    }
}