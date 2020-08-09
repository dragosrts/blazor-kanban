using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System.Collections.Generic;

namespace BlazorKanban.Application.TaskLists.Commands.UpdateTaskList
{
    public class UpdateTaskListCommand : IRequest<string>
    {
        public UpdateTaskListCommand(string id, string boardId, string title, string description, IEnumerable<TaskCard> cards)
        {
            Id = id;
            BoardId = boardId;
            Title = title;
            Description = description;
            Cards = cards;
        }

        public string Id { get; }

        public string BoardId { get; }

        public string Title { get; }

        public string Description { get; }

        public IEnumerable<TaskCard> Cards { get; }
    }
}