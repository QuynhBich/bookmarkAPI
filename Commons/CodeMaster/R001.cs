using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookmarkWeb.API.Commons.CodeMaster
{
    public class R001
    {
        /// <summary>
        /// DEV : Role Developer
        /// </summary>
        public static class DEVELOPER
        {
            public static readonly string CODE = "DEV";
            public static readonly string NAME = "Lập trình viên";
        }

        /// <summary>
        /// ADMIN : Role Admin
        /// </summary>
        public static class ADMIN
        {
            public static readonly string CODE = "ADMIN";
            public static readonly string NAME = "Quản lý";
        }

        /// <summary>
        /// SELLER : Role SELLER
        /// </summary>
        public static class User
        {
            public static readonly string CODE = "USER";
            public static readonly string NAME = "Người dùng";
        }
    }
}