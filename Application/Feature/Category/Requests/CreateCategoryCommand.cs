using eMarket.Application.DTOs.Category;
using eMarket.Application.Patterns.Mediator;
using eMarket.Domain.Entities;

namespace eMarket.Application.Feature.Product.Requests.Commands;

public class CreateCategoryCommand : IRequest<int>
{
    public required string Name { get; set; }
}