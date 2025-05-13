using eMarket.Application.DTOs.Category;
using eMarket.Application.Patterns.Mediator;

namespace eMarket.Application.Feature.Product.Requests.Queries;

public class GetAllCategoriesQuery :  IRequest<IEnumerable<CategoryListDto>>
{
    
}