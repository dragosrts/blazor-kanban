using AutoMapper;
using BlazorKanban.Domain.Objects.Entities;
using MongoDB.Bson;

namespace BlazorKanban.Infrastructure.Stores.Cards
{
    public class MongoTaskCardMappingProfile : Profile
    {
        public MongoTaskCardMappingProfile()
        {
            CreateMap<TaskCard, MongoTaskCard>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => ObjectId.Parse(src.Id)))
                .ForMember(dest => dest.ListId, opts => opts.MapFrom(src => ObjectId.Parse(src.ListId)))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description))
                .ForMember(dest => dest.Position, opts => opts.MapFrom(src => src.Position));


            CreateMap<MongoTaskCard, TaskCard>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.ListId, opt => opt.MapFrom(src => src.ListId.ToString()))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description))
                .ForMember(dest => dest.Position, opts => opts.MapFrom(src => src.Position));
        }
    }
}