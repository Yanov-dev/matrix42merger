using AutoMapper;
using Matrix42merger.Domain;
using Matrix42Merger.Dbo;
using Matrix42Merger.Dto;

namespace Matrix42Merger.App_Start
{
    public static class MapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize(e =>
            {
                e.CreateMap<SourceDto, Source>(MemberList.Destination);
                e.CreateMap<Source, SourceDbModel>(MemberList.Destination);
                e.CreateMap<Source, MergedEntity>(MemberList.Destination);

                e.CreateMap<MergedEntity, MergedEntityDbModel>(MemberList.Destination);
            });
        }
    }
}