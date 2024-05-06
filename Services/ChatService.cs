using System.Text;
using BookmarkWeb.API.Hubs;
using BookmarkWeb.API.Models.Chats;
using BookmarkWeb.API.Models.Common.Schemas;
using Microsoft.AspNetCore.SignalR;

namespace BookmarkWeb.API.Services
{
    public interface IChatService
    {
        public Task<string> SummaryFileAsync(string conversationId, string replyId);
        public Task<string> SendChatAsync(string link, string question, string replyId, bool isExpanded = false);
    }
    public class ChatService : IChatService
    {
        private readonly IApiService _apiService;
        private readonly IHubContext<NotificationHub> _notificationHub;
        private readonly IChatsModel _chatsModel;
        public ChatService(
            IApiService apiService,
            IConfiguration configuration,
            IHubContext<NotificationHub> notificationHub)
        {
            var host = configuration.GetValue<string>("ChatService:Host");
            _apiService = apiService;
            _apiService.Setting(host);
            _notificationHub = notificationHub;
        }
        public async Task<string> SendChatAsync(string link, string question, string replyId, bool expanded = false)
        {
            return await SendMessageAsync(new {link, question, expanded }, replyId);
        }

        public async Task<string> SummaryFileAsync(string link, string replyId)
        {
            return await SendMessageAsync(new {link}, replyId);
        }

        private async Task<string> SendMessageAsync(object? body, string replyId)
        {
            // var response = await _apiService.PostAsync($"/chat/{conversationId}", body, isStreaming: true);
            var response = await _apiService.PostAsync($"/chat/abc", body, isStreaming: true);
            response.EnsureSuccessStatusCode();

            var username = AppState.Instance.CurrentUser.Username;
            string responseMessage = "";
            using (var contentStream = await response.Content.ReadAsStreamAsync())
            {
                // Process the content stream as needed
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = await contentStream.ReadAsync(buffer)) > 0)
                {
                    responseMessage += Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    await _notificationHub.Clients
                        .User(username)
                        .SendAsync(NotificationHub.GPT_WRITE_REPLY, new
                        {
                            id = replyId,
                            content = responseMessage
                        });
                }
            }
            return responseMessage;
        }
    }
}