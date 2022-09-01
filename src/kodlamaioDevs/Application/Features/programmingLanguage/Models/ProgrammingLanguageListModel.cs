using Application.Features.programmingLanguage.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.programmingLanguage.Models;

public class ProgrammingLanguageListModel:BasePageableModel
{
    public IList<ProgrammingLanguageListDto> Items { get; set; }
}