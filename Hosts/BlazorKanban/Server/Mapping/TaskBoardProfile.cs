using AutoMapper;

namespace BlazorKanban.Server.Mapping
{
    public class TaskBoardProfile : Profile
    {
        public TaskBoardProfile()
        {
            CreateMap<Domain.Objects.Entities.TaskCard, Shared.Card>();

            CreateMap<Domain.Objects.Entities.TaskList, Shared.Column>()
                .ForMember(dest => dest.Cards, opts => opts.MapFrom(src => src.Cards));

            CreateMap<Domain.Objects.Entities.TaskBoard, Shared.Board>()
                .ForMember(dest => dest.Columns, opts => opts.MapFrom(src => src.Lists));
        }
    }
}