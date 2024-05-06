using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookmarkWeb.API.Commons
{
    public class Helpers
    {
        /// <summary>
        /// Sinh chuỗi token ngẫu nhiên theo id account đăng nhập, độ dài mặc định 100 ký tự.
        /// <para>Author: QuyPN</para>
        /// <para>Created: 15/02/2020</para>
        /// </summary>
        /// <param name="str">Chuỗi không trùng nhau sẽ cộng thêm vào token</param>
        /// <param name="length">Dộ dài của token, mặc định 100 ký tự</param>
        /// <returns> Chuỗi token </returns>
        public static string RenderToken(string str, int length = 100)
        {
            string token = "";
            Random ran = new Random();
            string tmp = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_-";
            for (int i = 0; i < length; i++)
            {
                token += tmp.Substring(ran.Next(0, 63), 1);
            }
            token += str;
            return token;
        }
    }
}