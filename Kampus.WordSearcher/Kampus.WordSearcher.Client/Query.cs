using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using Flurl.Http;
using System.IO;
using System.Text;
using System.Net.Http.Headers;

namespace Kampus.WordSearcher.Client
{
    public class Query
    {
        readonly string Site;
        readonly string Token;
        private static readonly HttpClient client = new HttpClient();

        public Query(string site, string token)
        {
            Site = site;
            Token = token;
            client.DefaultRequestHeaders.Add("Authorization", "token " + Token);
        }

        public void Start()
        {
            string url = "/task/game/start";
            var response = client.PostAsync(Site + url, null).Result;
        }

        public void Finish()
        {
            string url = "/task/game/finish";
            var response = client.PostAsync(Site + url, null).Result;
        }

        public void Stats()
        {
            string url = "/task/game/stats";
            var response = client.GetAsync(Site + url).Result;
        }

        public void Move(string direction)
        {
            string url = "/task/move/" + direction;
            var response = client.PostAsync(Site + url, null).Result;
        }

        public void SurrenderWords()
        {
            string url = "/task/words/";
            client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, Site + url);
            request.Content = new StringContent("{\"кампус\",\"контур\"}",
                                                Encoding.UTF8,
                                                "application/json");
            var response = client.SendAsync(request).Result;
        }


    }
}