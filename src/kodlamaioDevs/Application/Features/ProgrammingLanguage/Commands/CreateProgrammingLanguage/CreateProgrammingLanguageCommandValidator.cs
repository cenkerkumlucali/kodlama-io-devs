using FluentValidation;

namespace Application.Features.programmingLanguage.Commands.CreateProgrammingLanguage;

public class CreateProgrammingLanguageCommandValidator:AbstractValidator<CreateProgrammingLanguageCommand>
{
    public CreateProgrammingLanguageCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}