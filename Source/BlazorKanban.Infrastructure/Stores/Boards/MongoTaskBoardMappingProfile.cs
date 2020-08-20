using AutoMapper;
using BlazorKanban.Domain.Objects.Entities;
using MongoDB.Bson;

namespace BlazorKanban.Infrastructure.Stores.Boards
{
    public class MongoTaskBoardMappingProfile : Profile
    {
        public MongoTaskBoardMappingProfile()
        {
            CreateMap<TaskBoard, MongoTaskBoard>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => ObjectId.Parse(src.Id)))
                .ForMember(dest => dest.UserId, opts => opts.MapFrom(src => ObjectId.Parse(src.UserId)))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description));

            CreateMap<MongoTaskBoard, TaskBoard>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId.ToString()))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opts => opts.MapFrom(src => src.Description))
                .ForMember(dest => dest.Lists, opts => opts.Ignore());
        }
    }
}