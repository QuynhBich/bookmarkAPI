using System.Runtime.CompilerServices;
using BookmarkWeb.API.Commons;
using BookmarkWeb.API.Database.Entities;
using BookmarkWeb.API.Hubs;
using BookmarkWeb.API.Models.Chats.Schemas;
using BookmarkWeb.API.Models.Common.Schemas;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookmarkWeb.API.Models.Chats
{
    public interface IChatsModel
    {
        Task<ResponseInfo> SaveMessage(Schemas.Conversation data);
        Task<ResponseInfo> CreateNewConversation(Schemas.Conversation data);
        Task<List<InputMessage>> GetMessage(string conversationId);
        Task<ResponseInfo> DeleteConversation (string conversationId);
        Task<ResponseInfo> UpdateNotePad(InputMessage inputMessage);
        Task<ResponseInfo> Highlight(InputMessage inputMessage);
        Task<List<InputMessage>> GetStorageMessage();
        Task<ResponseInfo> DeleteStorageMessage(string id);
    }
    public class ChatsModel : BaseModel, IChatsModel
    {
        private string _className = "";
        private readonly IHubContext<NotificationHub> _notificationHub;
        private readonly ILogger<ChatsModel> _logger;

        public ChatsModel(
            IHubContext<NotificationHub> notificationHub,
            ILogger<ChatsModel> logger,
            IServiceProvider provider
        ) : base(provider)
        {
            _notificationHub = notificationHub ?? throw new ArgumentNullException(nameof(notificationHub));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _className = GetType().Name;
        }
        static string GetActualAsyncMethodName([CallerMemberName] string name = null) => name;
        public async Task<ResponseInfo> CreateNewConversation(Schemas.Conversation data)
        {
            ResponseInfo response = new ResponseInfo();
            IDbContextTransaction transaction = null;
            string method = GetActualAsyncMethodName();
            try
            {
                _logger.LogInformation($"[{_className}][{method}] Start");
                var userId = AppState.Instance.CurrentUser.Id;
                _ = Guid.TryParse(data.ConversationId, out Guid conversationId);
                _ = Guid.TryParse(data.Bookmark.BookmarkId, out Guid bookmarkId);
                transaction = await _context.Database.BeginTransactionAsync();
                var conversation = new Database.Entities.Conversation()
                {
                    Id = conversationId,
                    Name = data.Name,
                    Description = "",
                    BookmarkId = bookmarkId,
                };
                if (data.Name.Length > 50)
                {
                    conversation.Name = data.Name.Substring(0, 50);
                }

                _context.Conversations.Add(conversation);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                _logger.LogInformation($"[{_className}][{method}] End");
            }
            catch (Exception e)
            {
                await _context.RollbackAsync(transaction);
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                response.Exception(e);

                throw;
            }

            return response;
        }

        public async Task<ResponseInfo> SaveMessage(Schemas.Conversation data)
        {
            ResponseInfo response = new ResponseInfo();
            IDbContextTransaction transaction = null;
            string method = GetActualAsyncMethodName();
            try
            {
                _logger.LogInformation($"[{_className}][{method}] Start");
                var userId = AppState.Instance.CurrentUser.Id;
                
                transaction = await _context.Database.BeginTransactionAsync();
                _ = Guid.TryParse(data.ConversationId, out Guid conversationId);
                _ = Guid.TryParse(data.Bookmark.BookmarkId, out Guid bookmarkId);
                var conversation = await _context.Conversations.FirstOrDefaultAsync(x => x.BookmarkId.ToString() == data.Bookmark.BookmarkId);
                if (conversation != null)
                {
                    conversation.Description = data.Reply.Content.Length > 100 ? $"{data.Reply.Content.Substring(0, 97)}..." : data.Reply.Content;
                } else {
                    conversation = new Database.Entities.Conversation()
                    {
                        Id = conversationId,
                        Name = data.Name,
                        Description = "",
                        BookmarkId = bookmarkId,
                        UserId = userId
                    };
                    if (data.Name.Length > 50)
                    {
                        conversation.Name = data.Name.Substring(0, 50);
                    }

                    _context.Conversations.Add(conversation);
                    await _context.SaveChangesAsync();

                    var bookmark = await _context.Bookmarks.FirstOrDefaultAsync(x => x.Id == bookmarkId);
                    bookmark.ConversationId = conversationId;
                    await _context.SaveChangesAsync();
                }
                if (data.Message is not null)
                {
                    _ = Guid.TryParse(data.Message?.Id, out Guid messageId);
                    _context.Messages.Add(new Message()
                    {
                        Id = messageId,
                        ConversationId = conversation.Id,
                        Content = data.Message.Content,
                        UserId = userId,
                    });
                    await _context.SaveChangesAsync();
                }
                _ = Guid.TryParse(data.Reply.Id, out Guid replyId);
                _context.Messages.Add(new Message()
                {
                    Id = replyId,
                    ConversationId = conversation.Id,
                    Content = data.Reply.Content,
                    UserId = null,
                });
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                _logger.LogInformation($"[{_className}][{method}] End");
            }
            catch (Exception e)
            {
                await _context.RollbackAsync(transaction);
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                response.Exception(e);
            }
            return response;
        }

        public async Task<List<InputMessage>> GetMessage(string conversationId)
        {
            string method = GetActualAsyncMethodName();
            try{
                _logger.LogInformation($"[{_className}][{method}] Start");
                List<InputMessage> result = new();
                result = await _context.Messages.Where(x => x.ConversationId.ToString() == conversationId).OrderBy(x => x.CreatedAt)
                .Select(x => new InputMessage
                            {
                                Id = x.Id.ToString(),
                                Content = x.Content,
                                IsMy = x.UserId != null,
                                IsNoted = x.IsNoted,
                                Note = x.Note,
                            }
                        ).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                throw;
            }
        }

        public async Task<List<InputMessage>> GetStorageMessage()
        {
            string method = GetActualAsyncMethodName();
            try{
                _logger.LogInformation($"[{_className}][{method}] Start");
                List<InputMessage> result = new();
                result = await _context.Messages.Where(x => x.IsNoted).OrderBy(x => x.UpdatedAt)
                .Select(x => new InputMessage
                            {
                                Id = x.Id.ToString(),
                                Content = x.Content,
                                IsMy = x.UserId != null,
                                IsNoted = x.IsNoted,
                                Note = x.Note,
                                UpdatedAt = x.UpdatedAt
                            }
                        ).ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                throw;
            }
        }

        public async Task<ResponseInfo> DeleteConversation(string conversationId)
        {
            ResponseInfo response = new();
            IDbContextTransaction transaction = null;
            string method = GetActualAsyncMethodName();
            try
            {
                _logger.LogInformation($"[{_className}][{method}] Start");
                transaction = await _context.Database.BeginTransactionAsync();
                var conversation = await _context.Conversations.FirstOrDefaultAsync(x => x.Id.ToString() == conversationId);
                if (conversation is not null)
                {
                    var bookmark = await _context.Bookmarks.FirstOrDefaultAsync(x => x.ConversationId.ToString() == conversationId);
                    if (bookmark is not null)
                    {
                        bookmark.ConversationId = null;
                        _context.Update(bookmark);
                    }
                    _context.Conversations.Remove(conversation);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    _logger.LogInformation($"[{_className}][{method}] End");
                }
            } catch(Exception e)
            {
                await _context.RollbackAsync(transaction);
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                response.Exception(e);

                throw;
            }

            return response;
        }

        public async Task<ResponseInfo> DeleteStorageMessage(string id)
        {
            ResponseInfo response = new();
            IDbContextTransaction transaction = null;
            string method = GetActualAsyncMethodName();
            try
            {
                _logger.LogInformation($"[{_className}][{method}] Start");
                transaction = await _context.Database.BeginTransactionAsync();
                var message = await _context.Messages.FirstOrDefaultAsync(x => x.Id.ToString() == id);
                if (message is not null)
                {
                    _context.Messages.Remove(message);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    _logger.LogInformation($"[{_className}][{method}] End");
                }
            } catch(Exception e)
            {
                await _context.RollbackAsync(transaction);
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                response.Exception(e);

                throw;
            }
            return response;
        }

        public async Task<ResponseInfo> UpdateNotePad(InputMessage inputMessage)
        {
            ResponseInfo response = new();
            IDbContextTransaction transaction = null;
            string method = GetActualAsyncMethodName();
            try
            {
                _logger.LogInformation($"[{_className}][{method}] Start");
                transaction = await _context.Database.BeginTransactionAsync();
                var message = await _context.Messages.FirstOrDefaultAsync(x => x.Id.ToString() == inputMessage.Id);
                if (message is not null)
                {
                    message.Note = inputMessage.Note;
                    _context.Messages.Update(message);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    _logger.LogInformation($"[{_className}][{method}] End");
                }
            } catch(Exception e)
            {
                await _context.RollbackAsync(transaction);
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                response.Exception(e);

                throw;
            }
            return response;
        }

        public async Task<ResponseInfo> Highlight(InputMessage inputMessage)
        {
            ResponseInfo response = new();
            IDbContextTransaction transaction = null;
            string method = GetActualAsyncMethodName();
            try
            {
                _logger.LogInformation($"[{_className}][{method}] Start");
                transaction = await _context.Database.BeginTransactionAsync();
                var message = await _context.Messages.FirstOrDefaultAsync(x => x.Id.ToString() == inputMessage.Id);
                if (message is not null)
                {
                    message.IsNoted = inputMessage.IsNoted;
                    _context.Messages.Update(message);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    _logger.LogInformation($"[{_className}][{method}] End");
                }
            } catch(Exception e)
            {
                await _context.RollbackAsync(transaction);
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                response.Exception(e);

                throw;
            }
            return response;
        }
    }
}