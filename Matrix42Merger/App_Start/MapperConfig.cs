using AutoMapper;
using Matrix42merger.Domain;
using Matrix42Merger.Dbo;
using Matrix42Merger.Dto;

namespace Matrix42Merger.App_Start
{
    public static class MapperConfig
    {
        private static readonly object _lock = new object();
        private static bool _registered;

        public static void Register()
        {
            lock (_lock)
            {
                if (_registered)
                    return;

                _registered = true;

                Mapper.Initialize(e =>
                {
                    e.CreateMap<SourceDto, Source>(MemberList.Destination);
                    e.CreateMap<Source, SourceDbModel>(MemberList.Destination);
                    e.CreateMap<Source, MergedEntity>(MemberList.Destination);
                    e.CreateMap<Source, MergedEntityDbModel>(MemberList.Destination);
                    e.CreateMap<MergedEntity, MergedEntityDbModel>(MemberList.Destination);
                });
            }
        }
    }
}