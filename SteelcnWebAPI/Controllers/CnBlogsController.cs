using SteelcnWebAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace SteelcnWebAPI.Controllers
{
    public class CnBlogsController : Controller
    {
        // GET: CnBlogs
        public ActionResult Index()
        {
            return View();
        }
        public string GetArticle(string strUrl)
        {
            string strContent = WebUtinity.SendRequest(strUrl, Encoding.UTF8);
            string strPatter1 = @"<!--done-->\s*<div id=""topics"">[\s\S]*<!--end: topics 文章、评论容器-->";
            Match match = Regex.Match(strContent, strPatter1);
            if (!match.Success)
            {
                string strPatter2 = @"<div id=""post_detail"">[\s\S]*<a name=""!comments""></a>";
                match = Regex.Match(strContent, strPatter2);
            }
            return match.Value;
        }
    }
}