using eMarket.Application.DTOs.Category;
using eMarket.Application.Feature.Product.Requests.Commands;
using eMarket.Application.Feature.Product.Requests.Queries;
using eMarket.Application.Patterns.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace eMarket.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = 
            await _mediator.Send<GetAllCategoriesQuery, IEnumerable<CategoryListDto>>(new GetAllCategoriesQuery());
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromQuery] string name)
    {
        var response = await _mediator.Send<CreateCategoryCommand, int>(new CreateCategoryCommand { Name = name });
        return Ok(response);
    }
}