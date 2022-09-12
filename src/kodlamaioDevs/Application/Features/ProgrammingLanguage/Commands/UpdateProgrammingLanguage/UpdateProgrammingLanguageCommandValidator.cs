using FluentValidation;

namespace Application.Features.ProgrammingLanguage.Commands.UpdateProgrammingLanguage;

public class UpdateProgrammingLanguageCommandValidator:AbstractValidator<UpdateProgrammingLanguageCommand>
{
    public UpdateProgrammingLanguageCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}