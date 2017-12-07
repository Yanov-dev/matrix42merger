using System.Web.Http;
using AutoMapper;
using Matrix42merger.Domain;
using Matrix42Merger.Dbo;
using Matrix42Merger.Dto;

namespace Matrix42Merger
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes

            Mapper.Initialize(e =>
            {
                e.CreateMap<SourceDto, Source>(MemberList.Destination);
                e.CreateMap<Source, SourceDbModel>(MemberList.Destination);
                e.CreateMap<Source, MergedEntity>(MemberList.Destination);

                e.CreateMap<MergedEntity, MergedEntityDbModel>(MemberList.Destination);
            });

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional}
            );
        }
    }
}