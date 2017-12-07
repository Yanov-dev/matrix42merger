using System.Web.Http;
using AutoMapper;
using Matrix42Merger.Dto;
using Matrix42Merger.Models;

namespace Matrix42Merger
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes

            Mapper.Initialize(e => e.CreateMap<SourceDto, Source>());
            //Mapper.Initialize(e => e.CreateMap<Source, SourceDbModel>());


            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
            );
        }
    }
}