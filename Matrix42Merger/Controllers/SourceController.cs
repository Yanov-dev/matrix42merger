﻿using System.Threading.Tasks;
using System.Web.Http;
using Matrix42Merger.Dto;
using Matrix42Merger.Repositories;
using Matrix42Merger.Services.AuthService;
using Unity.Attributes;

namespace Matrix42Merger.Controllers
{
    [Route("api/source")]
    public class SourceController : ApiController
    {
        [Dependency]
        public ISourcesRepository SourcesRepository { get; set; }

        [HttpPost]
        public async Task Post(SourceDto sourceDto)
        {
            //SourcesRepository.Add();
        }
    }
}