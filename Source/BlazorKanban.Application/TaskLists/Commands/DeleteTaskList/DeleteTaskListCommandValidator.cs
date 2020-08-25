using FluentValidation;

namespace BlazorKanban.Application.TaskLists.Commands.DeleteTaskList
{
    public class DeleteTaskListCommandValidator : AbstractValidator<DeleteTaskListCommand>
    {
        public DeleteTaskListCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            //RuleFor(x => x.Forename).NotEmpty().WithMessage("Please specify a first name");
            //RuleFor(x => x.Discount).NotEqual(0).When(x => x.HasDiscount);
            //RuleFor(x => x.Address).Length(20, 250);
            //RuleFor(x => x.Postcode).Must(BeAValidPostcode).WithMessage("Please specify a valid postcode");
        }
    }
}