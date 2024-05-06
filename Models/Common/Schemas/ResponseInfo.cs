using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookmarkWeb.API.Commons;

namespace BookmarkWeb.API.Models.Common.Schemas
{
    public class ResponseInfo
    {
        public int Code { set; get; }

        public string MsgNo { set; get; }

        public Dictionary<string, string> ListError { set; get; }

        public Dictionary<string, string> Data { set; get; }

        public ResponseInfo()
        {
            Code = CodeResponse.OK;
            MsgNo = "";
            Data = new Dictionary<string, string>();
        }

        public void Exception(Exception e)
        {
            Code = CodeResponse.SERVER_ERROR;
            MsgNo = "E500";
            Data.Add("error", e.Message);
        }
    }
}