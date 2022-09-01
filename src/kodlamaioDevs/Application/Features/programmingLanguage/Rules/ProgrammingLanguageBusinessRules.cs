using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.programmingLanguage.Rules;

public class ProgrammingLanguageBusinessRules
{
    private IProgrammingLanguageRepository _programmingLanguageRepository;

    public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
    {
        _programmingLanguageRepository = programmingLanguageRepository;
    }
    public async Task LanguageNameCanNotBeDuplicatedWhenInserted(string name)
    {
        IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(b => b.Name == name);
        if (result.Items.Any()) throw new BusinessException("Programming language name exists.");
    }
    public async Task LanguageShouldExistWhenRequested(ProgrammingLanguage programmingLanguage)
    {
        if (programmingLanguage == null) throw new BusinessException("Requested brand does not exist.");
    }
}