using FluentValidation;

namespace BlazorKanban.Application.TaskLists.Commands.CreateTaskList
{
    public class CreateTaskListCommandValidator : AbstractValidator<CreateTaskListCommand>
    {
        public CreateTaskListCommandValidator()
        {
            RuleFor(x => x.BoardId).NotEmpty();
            RuleFor(x => x.Title).NotEmpty().Length(1, 25).WithMessage("Please specify a Title");
        }
    }
}