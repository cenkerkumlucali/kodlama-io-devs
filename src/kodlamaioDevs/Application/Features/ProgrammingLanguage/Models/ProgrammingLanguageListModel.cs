using Application.Features.ProgrammingLanguage.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.ProgrammingLanguage.Models;

public class ProgrammingLanguageListModel:BasePageableModel
{
    public IList<ProgrammingLanguageListDto> Items { get; set; }
}