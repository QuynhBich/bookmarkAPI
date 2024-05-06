using System.Runtime.CompilerServices;
using BookmarkWeb.API.Database.Entities;
using BookmarkWeb.API.Models.Bookmarks.Schemas;
using BookmarkWeb.API.Models.Common.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookmarkWeb.API.Models.Bookmarks
{
    public interface IBookmarkModel
    {
        Task<BookmarkDto> CreateNewBookmark(BookmarkCreateModel data);
        Task<List<BookmarkDto>> CreateBunkOfBookmarks(List<BookmarkCreateModel> data);
        Task<List<BookmarkDto>> GetListBookmark();
        Task<BookmarkDto> GetBookmarkById(string id);
        Task<ResponseInfo> DeleteBookmark (string id);
    }
    public class BookmarksModel : BaseModel, IBookmarkModel
    {
        private readonly ILogger<BookmarksModel> _logger;
        private string _className = "";
        public BookmarksModel(ILogger<BookmarksModel> logger, IServiceProvider provider) : base(provider)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _className = GetType().Name;
        }
        static string GetActualAsyncMethodName([CallerMemberName] string name = null) => name;

        public async Task<List<BookmarkDto>> CreateBunkOfBookmarks(List<BookmarkCreateModel> data)
        {
            ResponseInfo response = new();
            IDbContextTransaction transaction = null;
            string method = GetActualAsyncMethodName();
            Bookmark? bookmark;
            List<Bookmark> listBookmarks = new();
            List<BookmarkDto> listBookmarkDtos = new();
            try
            {
                _logger.LogInformation($"[{_className}][{method}] Start");
                var userId = AppState.Instance.CurrentUser.Id;
                transaction = await _context.Database.BeginTransactionAsync();
                foreach (var item in data)
                {
                    var newId = Guid.NewGuid();
                    bookmark = new Bookmark()
                    {
                        Id = newId,
                        UserId = userId,
                        Domain = item.Domain,
                        Url = item.Url,
                        Image = item.Image,
                        Note = item.Note,
                        FolderId = item.FolderId,
                        Description = item.Description,
                        Title = item.Title
                    };
                    
                    listBookmarks.Add(bookmark);

                    listBookmarkDtos.Add(new BookmarkDto() {
                        Id = bookmark.Id,
                        Url = bookmark.Url,
                        Domain = bookmark.Domain,
                        Image = bookmark.Image,
                        Note = bookmark.Note,
                        Description = bookmark.Description
                    });
                }

                _context.Bookmarks.AddRange(listBookmarks);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                _logger.LogInformation($"[{_className}][{method}] End");
            }
            catch (Exception e)
            {
                await _context.RollbackAsync(transaction);
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                response.Exception(e);

                throw new Exception();
            }

            return listBookmarkDtos;
        }

        public async Task<BookmarkDto> CreateNewBookmark(BookmarkCreateModel data)
        {
            ResponseInfo response = new();
            IDbContextTransaction transaction = null;
            string method = GetActualAsyncMethodName();
            Bookmark? bookmark;
            try
            {
                _logger.LogInformation($"[{_className}][{method}] Start");
                var userId = AppState.Instance.CurrentUser.Id;
                var newId = Guid.NewGuid();
                transaction = await _context.Database.BeginTransactionAsync();
                bookmark = new Bookmark()
                {
                    Id = newId,
                    UserId = userId,
                    Domain = data.Domain,
                    Url = data.Url,
                    Image = data.Image,
                    Note = data.Note,
                    FolderId = data.FolderId,
                    Description = data.Description,
                    Title = data.Title
                };

                _context.Bookmarks.Add(bookmark);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                _logger.LogInformation($"[{_className}][{method}] End");
            }
            catch (Exception e)
            {
                await _context.RollbackAsync(transaction);
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                response.Exception(e);

                throw new Exception();
            }

            return new BookmarkDto()
            {
                Id = bookmark.Id,
                Url = bookmark.Url,
                Domain = bookmark.Domain,
                Image = bookmark.Image,
                Note = bookmark.Note,
                Description = bookmark.Description
            };
        }

        public async Task<ResponseInfo> DeleteBookmark(string id)
        {
            ResponseInfo response = new();
            IDbContextTransaction transaction = null;
            string method = GetActualAsyncMethodName();
            try
            {
                _logger.LogInformation($"[{_className}][{method}] Start");
                transaction = await _context.Database.BeginTransactionAsync();
                var bookmark = await _context.Bookmarks.FirstOrDefaultAsync(x => x.Id.ToString() == id);
                if (bookmark is not null)
                {
                    var conversation = await _context.Conversations.FirstOrDefaultAsync(x => x.BookmarkId.ToString() == id);
                    if (conversation is not null)
                    {
                        _context.Conversations.Remove(conversation);
                        await _context.SaveChangesAsync();
                    }
                    _context.Bookmarks.Remove(bookmark);
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

        public async Task<BookmarkDto> GetBookmarkById(string id)
        {
            var bookmark = await _context.Bookmarks.FirstOrDefaultAsync(x => x.Id.ToString() == id);
            if (bookmark is not null) 
            {
                return new BookmarkDto() {
                    Id = bookmark.Id,
                    Url = bookmark.Url,
                    Domain = bookmark.Domain,
                    Image = bookmark.Image,
                    Note = bookmark.Note,
                    Description = bookmark.Description,
                    ConversationId = bookmark.ConversationId
                };
            }
            throw new Exception("Bookmark not found");
        }

        public async Task<List<BookmarkDto>> GetListBookmark()
        {
            string method = GetActualAsyncMethodName();
            try{
                _logger.LogInformation($"[{_className}][{method}] Start");
                List<BookmarkDto> result = new();
                var user = AppState.Instance.CurrentUser.Id;
                result = await _context.Bookmarks.Where(x => x.UserId == user).Select(x => new BookmarkDto(){
                    Id = x.Id,
                    Url = x.Url,
                    Description = x.Description,
                    Domain = x.Domain,
                    Image = x.Image,
                    Note = x.Note,
                    CreatedAt = x.CreatedAt,
                    Title = x.Title,
                    FolderId = x.FolderId,
                    ConversationId = x.ConversationId
                }).OrderByDescending(x => x.CreatedAt).ToListAsync();
                _logger.LogInformation($"[{_className}][{method}] End");

                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                throw;
            }
        }
    }
}