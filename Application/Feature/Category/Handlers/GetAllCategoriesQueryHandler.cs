using AutoMapper;
using eMarket.Application.Contracts.Persistence;
using eMarket.Application.DTOs.Category;
using eMarket.Application.Feature.Category.Requests;
using eMarket.Application.Patterns.Mediator;

namespace eMarket.Application.Feature.Category.Handlers;

public class GetAllCategoriesQueryHandler :  IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryListDto>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<CategoryListDto>> Handle(GetAllCategoriesQuery request)
    {
        var categories = await _categoryRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CategoryListDto>>(categories);
    }
}