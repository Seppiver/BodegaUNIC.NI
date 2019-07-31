using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace ordenespago2019.EF
{
    public class OAuth
    {
        public static string office365Url { get; } = "https://login.microsoftonline.com/common/oauth2/v2.0/token";

        public async Task<string> tokinezoffice(string code,string metodo)
        {
            var request = (HttpWebRequest)WebRequest.Create(office365Url);

            var postData = "client_id=35eb8651-a334-4c6a-b792-9b6470ab03a5";
            postData += "&client_secret=jgdFCYU2[?zgjmWNV9903%{";
            postData += "&code=" + code;
            postData += "&redirect_uri=https%3A%2F%2Flocalhost:5001%2F"+metodo;
            postData += "&grant_type=authorization_code";
            byte[] postBytes = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postBytes.Length;

            Stream requestStream =  request.GetRequestStream();
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            JObject json = JObject.Parse(responseString);
            return  json["access_token"].ToString();

        }

        public async Task<string> emailreader(string tokenoffice)
        {
            var request2 = (HttpWebRequest)WebRequest.Create("https://graph.microsoft.com/v1.0/me");
            var html = "";
            request2.Method = "GET";
            request2.ContentType = "application/json";
            request2.Headers.Add("Authorization", "Bearer " + tokenoffice);
            //request2.AutomaticDecompression = DecompressionMethods.GZip;
            using (HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse())
            using (Stream stream2 = response2.GetResponseStream())
            using (StreamReader reader2 = new StreamReader(stream2))
            {
                html = reader2.ReadToEnd();
            }
            JObject json = JObject.Parse(html);
            return json["mail"].ToString();
        }

       }
}
