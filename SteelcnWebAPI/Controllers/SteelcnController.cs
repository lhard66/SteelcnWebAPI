using SteelcnWebAPI.Common;
using SteelcnWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace SteelcnWebAPI.Controllers
{
    public class SteelcnController : Controller
    {
        // GET: Steelcn
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowList()
        {
            string strUrl = "http://hq.steelcn.cn/NewsList.aspx?pItemId=4&itemId=400";
            string strContent = WebUtinity.SendRequest(strUrl, Encoding.UTF8);
            List<NewListModels> listNews = new List<NewListModels>();
            string strPatter= "<span>(\\d{2}-\\d{2})</span><a href=\"(/news/\\d{6}.html)\" target=\"_blank\">(.*)</a>";
            MatchCollection matches = Regex.Matches(strContent, strPatter);
            foreach (Match match in matches)
            {
                listNews.Add(new NewListModels() { Title = match.Groups[3].Value, Date = match.Groups[1].Value, Url = match.Groups[2].Value });
            }

            return Json(listNews,JsonRequestBehavior.AllowGet);

            //NewListModels model = new NewListModels() { Title = "文章标题", Date = "06-03", Url = "baidu.com" };
            //return Json(model,JsonRequestBehavior.AllowGet);

            
        }
        public string GetArticle(string Url)
        {
            string strUrl = "http://hq.steelcn.cn" + Url;
            string strContent = WebUtinity.SendRequest(strUrl, Encoding.UTF8);
            string strPatter = "<div id=\"mycon\">(.*)推荐经销商";
            strContent = strContent.Replace("\n"," ");
            Match match = Regex.Match(strContent, strPatter);
            return match.Groups[1].Value;
        }

    }
}