using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorKanban.Application.TaskBoards.Queries.GetTaskBoardDetail
{
    //public class GetTaskBoardDetailQuery : IRequest<TaskBoardDetail>
    public class GetTaskBoardDetailQuery : IRequest<TaskBoard>
    {
        public string Id { get; set; }
    }
}