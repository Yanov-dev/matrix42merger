using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Matrix42Merger.Dto;
using Newtonsoft.Json;

namespace Matrix42Merger.Spamer
{
    public class HostSpamer
    {
        private readonly string _sourcePath;
        private readonly int _targetSourceId;

        private const string BaseUrl = "http://localhost:52428";

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
                ["password"] = "1",
            };

            var response = httpClient.PostAsync($"{BaseUrl}/api/account", new FormUrlEncodedContent(requestLoginDictionary)).Result;
        }
    }
}
