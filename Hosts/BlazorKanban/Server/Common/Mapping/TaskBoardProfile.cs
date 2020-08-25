using AutoMapper;

namespace BlazorKanban.Server.Common.Mapping
{
    public class TaskBoardProfile : Profile
    {
        public TaskBoardProfile()
        {
            CreateMap<Domain.Objects.Entities.TaskCard, Shared.Card>()
                .ForMember(dest => dest.ColumnId, opts => opts.MapFrom(src => src.ListId));

            CreateMap<Domain.Objects.Entities.TaskList, Shared.Column>()
                .ForMember(dest => dest.Cards, opts => opts.MapFrom(src => src.Cards));

            CreateMap<Domain.Objects.Entities.TaskBoard, Shared.Board>()
                .ForMember(dest => dest.Columns, opts => opts.MapFrom(src => src.Lists));

            CreateMap<Shared.Card, Domain.Objects.Entities.TaskCard>()
                .ForMember(dest => dest.ListId, opts => opts.MapFrom(src => src.ColumnId));

            CreateMap<Shared.Column, Domain.Objects.Entities.TaskList>()
                .ForMember(dest => dest.Cards, opts => opts.MapFrom(src => src.Cards));

            CreateMap<Shared.Board, Domain.Objects.Entities.TaskBoard>()
                .ForMember(dest => dest.Lists, opts => opts.MapFrom(src => src.Columns));
        }
    }
}