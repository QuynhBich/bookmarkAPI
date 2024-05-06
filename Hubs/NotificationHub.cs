using System.Collections.Concurrent;
using System.Security.Claims;
using BookmarkWeb.API.Filters;
using BookmarkWeb.API.Models.Chats.Schemas;
using BookmarkWeb.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace BookmarkWeb.API.Hubs
{
    [SetAppState]
    [Authorize]
    public class NotificationHub: Hub
    {
        public static readonly string ERROR = "Error";
        public static readonly string CONNECTED = "Connected";
        public static readonly string DISCONNECTED = "Disconnected";
        public static readonly string ADDED_TO_GROUP = "AddedToGroup";
        public static readonly string REMOVED_FROM_GROUP = "RemovedFromGroup";
        public static readonly string GPT_REPLY = "GptReply";
        public static readonly string GPT_WRITE_REPLY = "GptWriteReply";
        public static readonly string SAVE_MESSAGE = "SaveMessage";
        public static readonly string UPDATE_MESSAGE = "UpdateMessage";

        private static readonly ConcurrentDictionary<string, HubUser> Users = new ConcurrentDictionary<string, HubUser>();

        public async override Task OnConnectedAsync()
        {
            string username = await GetUsername();
            string connectionId = Context.ConnectionId;
            HubUser hubUser = Users.GetOrAdd(username, _ => new HubUser
            {
                Username = username,
                ConnectionIds = new HashSet<string>()
            });

            if (hubUser.ConnectionIds != null)
            {
                lock (hubUser.ConnectionIds)
                {
                    hubUser.ConnectionIds.Add(connectionId);
                }
            }
            await base.OnConnectedAsync();
            await Clients.Caller.SendAsync(CONNECTED, hubUser, "Connected successfully!");
        }

        public async override Task OnDisconnectedAsync(Exception exception)
        {

            string username = await GetUsername();
            string connectionId = Context.ConnectionId;

            HubUser hubUser;
            Users.TryGetValue(username, out hubUser);

            if (hubUser.ConnectionIds != null)
            {
                lock (hubUser.ConnectionIds)
                {
                    hubUser.ConnectionIds.RemoveWhere(cid => cid.Equals(connectionId));

                    if (!hubUser.ConnectionIds.Any())
                    {
                        HubUser removedUser;
                        Users.TryRemove(username, out removedUser);
                    }
                }
            }
            await base.OnDisconnectedAsync(exception);
            await Clients.Caller.SendAsync(DISCONNECTED, hubUser, "Disconnected successfully!");
        }
        public async Task OnSendMessage(Conversation data)
        {
            try
            {
                string username = await GetUsername();
                Users.TryGetValue(username, out HubUser hubUser);
                var conversation = hubUser.Conventions.FirstOrDefault(x => x.Id == data.ConversationId);
                var chatService = Context.GetHttpContext().RequestServices.GetService<IChatService>();
                if (data.Message is null)
                {
                    data.Reply.Content = await chatService.SummaryFileAsync(data.Bookmark.BookmarkUrl, data.Reply.Id);
                }
                else
                {
                    data.Reply.Content = await chatService.SendChatAsync(data.Bookmark.BookmarkUrl, data.Message.Content, data.Reply.Id, data.IsExpanded);
                }
            }
            catch (Exception e)
            {
                data.Reply.Content = "Sorry, i can not reply this message. Error: " + e.Message;
            }
            await Clients.Users(data.User.Username).SendAsync(GPT_REPLY, data);
        }

        private async Task<string> GetUsername()
        {
            string username = "";
            try
            {
                ClaimsPrincipal user = Context.User;
                if (user != null && user.Identity != null && user.Identity.IsAuthenticated)
                {
                    var identity = user.Identity as ClaimsIdentity;
                    username = identity.Claims.Where(p => p.Type == "Username").FirstOrDefault().Value ?? "";
                }
            }
            catch (Exception e)
            {
                await Clients.Caller.SendAsync(ERROR, e);
            }
            return username ?? "";
        }
    }
}