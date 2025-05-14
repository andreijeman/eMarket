using AutoMapper;
using eMarket.Application.Contracts.Persistence;
using eMarket.Application.Feature.Category.Requests;
using eMarket.Application.Patterns.Mediator;

namespace eMarket.Application.Feature.Category.Handlers;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    public async Task<int> Handle(CreateCategoryCommand request)
    {
        var category = await _categoryRepository.AddAsync(new Domain.Entities.Category { Name =  request.Name });
        return category.Id;
    }
}