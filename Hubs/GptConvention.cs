using OpenAI_API.Chat;
namespace BookmarkWeb.API.Hubs
{
    public class GptConvention
    {
        public string Id { set; get; }
		public Conversation Chat { set; get; }
    }
}