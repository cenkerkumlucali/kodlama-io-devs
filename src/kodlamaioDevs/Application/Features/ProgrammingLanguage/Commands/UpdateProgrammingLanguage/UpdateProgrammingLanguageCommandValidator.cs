using Application.Features.programmingLanguage.Commands.UpdateProgrammingLanguage;
using FluentValidation;

namespace Application.Features.programmingLanguage.Commands.CreateProgrammingLanguage;

public class UpdateProgrammingLanguageCommandValidator:AbstractValidator<UpdateProgrammingLanguageCommand>
{
    public UpdateProgrammingLanguageCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}