using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Matrix42Merger.Dto;
using Newtonsoft.Json;

namespace Matrix42Merger.Spamer
{
    public class HostSpamer
    {
        private const string BaseUrl = "http://localhost:52428";
        private readonly string _sourcePath;
        private readonly int _targetSourceId;

        public HostSpamer(string sourcePath, int targetSourceId)
        {
            _sourcePath = sourcePath;
            _targetSourceId = targetSourceId;
        }

        public void Start()
        {
            var rawData = File.ReadAllText(_sourcePath);
            var sources = JsonConvert.DeserializeObject<List<SourceDto>>(rawData);

            sources.ForEach(e => e.TargetSource = _targetSourceId);

            var httpClient = new HttpClient();
            var requestLoginDictionary = new Dictionary<string, string>
            {
                ["username"] = "1",
                ["password"] = "1"
            };

            var loginInfo = new UserLoginInfo
            {
                UserName = "1",
                Password = "1"
            };

            var response = httpClient.PostAsync(
                $"{BaseUrl}/api/account",
                new StringContent(
                    JsonConvert.SerializeObject(loginInfo),
                    Encoding.UTF8,
                    "application/json")).Result;

            var content = response.Content.ReadAsStringAsync().Result;

            var loginResult = JsonConvert.DeserializeObject<LoginResult>(content);

            var token = loginResult.AccessToken;
            httpClient.DefaultRequestHeaders.Add("token", token);
            foreach (var source in sources)
            {
                response = httpClient.PostAsync(
                    $"{BaseUrl}/api/source",
                    new StringContent(
                        JsonConvert.SerializeObject(source),
                        Encoding.UTF8,
                        "application/json")).Result;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    Console.WriteLine($"Error - {response.StatusCode}");
                    return;
                }
            }
        }
    }
}