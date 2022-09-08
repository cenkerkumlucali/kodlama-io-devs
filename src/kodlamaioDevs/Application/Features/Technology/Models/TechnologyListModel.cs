using Application.Features.programmingLanguage.Dtos;
using Application.Features.Technology.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Technology.Models;

public class TechnologyListModel:BasePageableModel
{
    public IList<TechnologyListDto> Items { get; set; }
}