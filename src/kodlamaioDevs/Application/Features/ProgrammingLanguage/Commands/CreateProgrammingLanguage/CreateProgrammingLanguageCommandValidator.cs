using FluentValidation;

namespace Application.Features.ProgrammingLanguage.Commands.CreateProgrammingLanguage;

public class CreateProgrammingLanguageCommandValidator:AbstractValidator<CreateProgrammingLanguageCommand>
{
    public CreateProgrammingLanguageCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}