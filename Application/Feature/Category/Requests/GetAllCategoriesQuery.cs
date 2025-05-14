using eMarket.Application.DTOs.Category;
using eMarket.Application.Patterns.Mediator;

namespace eMarket.Application.Feature.Category.Requests;

public class GetAllCategoriesQuery :  IRequest<IEnumerable<CategoryListDto>>
{
    
}