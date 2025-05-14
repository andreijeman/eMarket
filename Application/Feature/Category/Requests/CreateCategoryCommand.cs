using eMarket.Application.Patterns.Mediator;

namespace eMarket.Application.Feature.Category.Requests;

public class CreateCategoryCommand : IRequest<int>
{
    public required string Name { get; set; }
}