using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookmarkWeb.API.Commons.Enums
{
    public class MSG_NO
    {
        /// <summary>
        /// Email không đúng định dạng.
        /// </summary>
        public static readonly string EMAIL_INVALIDATE = "E002";
        /// <summary>
        /// Tài khoản không tồn tại.
        /// </summary>
        public static readonly string USERNAME_NOT_CORRECT = "E012";
        /// <summary>
        /// Mật khẩu không đúng.
        /// </summary>
        public static readonly string PASSWORD_NOT_CORRECT = "E013";
        /// <summary>
        /// Tài khoản hoặc mật khẩu không chính xác.
        /// </summary>
        public static readonly string USERNAME_OR_PASSWORD_NOT_CORRECT = "E014";
        /// <summary>
        /// Tên người dùng này đã được đăng ký. Vui lòng sử dụng tên người dùng khác!
        /// </summary>
        public static readonly string USERNAME_HAD_USED = "E015";

        /// <summary>
        /// Hệ thống có lỗi, vui lòng thử lại sau.
        /// </summary>
        public static readonly string SERVER_ERROR = "E500";
    }
}