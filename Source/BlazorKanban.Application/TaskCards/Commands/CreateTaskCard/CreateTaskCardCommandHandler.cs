using BlazorKanban.Domain.Contracts.TaskCards;
using BlazorKanban.Domain.Objects.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorKanban.Application.TaskCards.Commands.CreateTaskCard
{
    public class CreateTaskCardCommandHandler : IRequestHandler<CreateTaskCardCommand, string>
    {
        private readonly ICreateTaskCardEntity<TaskCard> createTaskCard;

        public CreateTaskCardCommandHandler(ICreateTaskCardEntity<TaskCard> createTaskCard)
        {
            this.createTaskCard = createTaskCard;
        }

        public async Task<string> Handle(CreateTaskCardCommand request, CancellationToken cancellationToken)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var entity =
                new TaskCard(
                    id: createTaskCard.GenerateIdentifier(),
                    listId: request.ListId,
                    title: request.Title,
                    description: request.Description,
                    position: request.Position
                );

            var cardResult = await createTaskCard.CreateAsync(entity, cancellationToken).ConfigureAwait(false);

            return cardResult;
        }
    }
}