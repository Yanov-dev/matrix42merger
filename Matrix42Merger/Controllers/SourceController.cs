﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Matrix42merger.Domain;
using Matrix42Merger.Dto;
using Matrix42Merger.Processors;
using Matrix42Merger.Repositories.MergedEntities;
using Unity.Attributes;

namespace Matrix42Merger.Controllers
{
    [JwtAuthorize]
    [Route("api/source")]
    public class SourceController : ApiController
    {
        [Dependency]
        public ISourceProcessor SourceProcessor { get; set; }

        [Dependency]
        public IMergedEntitiesRepository MergedEntitiesRepository { get; set; }

        [HttpPost]
        public async Task Post(SourceDto sourceDto)
        {
            var mutex = new Mutex();

            mutex.WaitOne();

            var source = Mapper.Map<Source>(sourceDto);
            await SourceProcessor.Add(source).ConfigureAwait(false);

            mutex.ReleaseMutex();
        }

        public async Task<List<MergedEntity>> GetAllData()
        {
            return await MergedEntitiesRepository.GetAll().ConfigureAwait(false);
        }
    }
}