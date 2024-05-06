namespace BookmarkWeb.API.Models.Common.Schemas
{
    public class AppState
    {
        public static AppState Instance { get; protected set; } = new AppState();
        private User _curentUser;
        private IConfiguration _configuration;
        public AppState()
        {
            _curentUser = new User();
        }
        public virtual User CurrentUser
        {
            get
            {
                lock (_curentUser)
                {
                    return _curentUser;
                }
            }
            set
            {
                lock (_curentUser)
                {
                    _curentUser = value == null ? new User() : value;
                }
            }
        }
        public virtual IConfiguration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    return null;
                }
                lock (_configuration)
                {
                    return _configuration;
                }
            }
            set
            {
                if (_configuration != null)
                {
                    throw new Exception("Can't set once a value has already been set.");
                }
                _configuration = value;
            }
        }
    }
    
}