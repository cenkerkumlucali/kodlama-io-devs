using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;

namespace Application.Features.ProgrammingLanguage.Rules;

public class ProgrammingLanguageBusinessRules
{
    private IProgrammingLanguageRepository _programmingLanguageRepository;

    public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
    {
        _programmingLanguageRepository = programmingLanguageRepository;
    }
    public async Task LanguageNameCanNotBeDuplicatedWhenInserted(string name)
    {
        IPaginate<Domain.Entities.ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(b => b.Name == name);
        if (result.Items.Any()) throw new BusinessException("Programming language name exists.");
    }
    public async Task LanguageShouldExistWhenRequested(Domain.Entities.ProgrammingLanguage programmingLanguage)
    {
        if (programmingLanguage == null) throw new BusinessException("Requested brand does not exist.");
    }
}