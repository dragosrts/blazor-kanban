using MediatR;
using System.Collections.Generic;

namespace BlazorKanban.Application.TaskCards.Commands.UpdateTaskCardsDetails
{
    public class UpdateTaskCardsDetailsCommand : IRequest<bool>
    {
        public UpdateTaskCardsDetailsCommand(IEnumerable<TaskCardDetail> taskCardDetails)
        {
            TaskCardDetails = taskCardDetails;
        }

        public IEnumerable<TaskCardDetail> TaskCardDetails { get; }
    }

    public class TaskCardDetail
    {
        public TaskCardDetail(string id, string listId, string title, string description, long position)
        {
            Id = id;
            ListId = listId;
            Title = title;
            Description = description;
            Position = position;
        }

        public string Id { get; }

        public string ListId { get; }

        public string Title { get; }

        public string Description { get; }

        public long Position { get; }
    }
}