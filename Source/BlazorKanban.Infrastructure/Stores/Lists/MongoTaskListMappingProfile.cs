using AutoMapper;
using BlazorKanban.Domain.Objects.Entities;
using MongoDB.Bson;

namespace BlazorKanban.Infrastructure.Stores.Lists
{
    public class MongoTaskListMappingProfile : Profile
    {
        public MongoTaskListMappingProfile()
        {
            CreateMap<TaskList, MongoTaskList>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => ObjectId.Parse(src.Id)))
                .ForMember(dest => dest.BoardId, opts => opts.MapFrom(src => ObjectId.Parse(src.BoardId)))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description));

            CreateMap<MongoTaskList, TaskList>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.BoardId, opt => opt.MapFrom(src => src.BoardId.ToString()))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description));
        }
    }
}