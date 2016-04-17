using AutoMapper;
using TombRaider.API.PoznanApiRepresentations;
using TombRaider.API.Core;

namespace TombRaider.API.Automapper
{
    public static class AutomapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<GeographicalInfo, Coordinates>()
                 .ForMember(dest => dest.Latitude, options => options.MapFrom(source => source.Coordinates[0]))
                 .ForMember(dest => dest.Longtitude, options => options.MapFrom(source => source.Coordinates[1]))
                 .ForMember(dest => dest.Type, options => options.MapFrom(source => source.Type));

            Mapper.CreateMap<Feature, Grave>()
                .ForMember(dest => dest.Name, options => options.MapFrom(source => ((source.Properties)).g_name))
                .ForMember(dest => dest.Surname, options => options.MapFrom(source => (source.Properties).g_surname))
                .ForMember(dest => dest.CementaryId, options => options.MapFrom(source => (source.Properties).cm_id))
                .ForMember(dest => dest.DateBurial, options => options.MapFrom(source => (source.Properties).g_date_burial))
                .ForMember(dest => dest.DateDeath, options => options.MapFrom(source => (source.Properties).g_date_death))
                .ForMember(dest => dest.Id, options => options.MapFrom(source => source.Id))
                .ForMember(dest => dest.Field, options => options.MapFrom(source => ParseWithDefault((source.Properties).g_field, null)))
                .ForMember(dest => dest.Place, options => options.MapFrom(source => (source.Properties).g_place))
                .ForMember(dest => dest.Quarter, options => options.MapFrom(source => ParseWithDefault((source.Properties).g_quarter, null)))
                .ForMember(dest => dest.Row, options => options.MapFrom(source => ParseWithDefault((source.Properties).g_row, null)))
                .ForMember(dest => dest.Size, options => options.MapFrom(source => ParseWithDefault((source.Properties).g_size, null)))
                .ForMember(dest => dest.Location, options => options.MapFrom(source => Mapper.Map<GeographicalInfo, Coordinates>(source.Geometry)))
                .ForMember(dest => dest.DateBirth, options => options.MapFrom(source => (source.Properties).g_date_birth));

            Mapper.CreateMap<Feature, MapPoint>()
                .ForMember(dest => dest.Name, options => options.MapFrom(source => ((source.Properties)).nazwa))
                .ForMember(dest => dest.Location, options => options.MapFrom(source => Mapper.Map<GeographicalInfo, Coordinates>(source.Geometry)));
                
        }

        public static int? ParseWithDefault(string text, int? defaultValue)
        {
            int parsed;
            return int.TryParse(text, out parsed) ? parsed : defaultValue;
        }
    }
}