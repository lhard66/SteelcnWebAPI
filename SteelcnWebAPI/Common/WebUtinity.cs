using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace SteelcnWebAPI.Common
{
    public static class WebUtinity
    {
        public static string SendRequest(string url,Encoding encoding)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            //System.Net.Http.HttpClient c = new System.Net.Http.HttpClient(); 建议使用此对象，因为支持异步操作
            
            webRequest.Method = "GET";
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader sr = new StreamReader(webResponse.GetResponseStream(), encoding);
            return sr.ReadToEnd();
        }
    }
}