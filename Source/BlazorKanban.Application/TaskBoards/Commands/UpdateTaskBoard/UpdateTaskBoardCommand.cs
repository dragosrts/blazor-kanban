using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System.Collections.Generic;

namespace BlazorKanban.Application.TaskBoards.Commands.UpdateTaskBoard
{
    public class UpdateTaskBoardCommand : IRequest<string>
    {
        public UpdateTaskBoardCommand(string id, string userId, string title, string description, IEnumerable<TaskList> lists)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Description = description;
            Lists = lists;
        }

        public string Id { get; }

        public string UserId { get; }

        public string Title { get; }

        public string Description { get; }

        public IEnumerable<TaskList> Lists { get; }
    }
}