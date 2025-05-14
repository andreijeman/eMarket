using eMarket.Application.DTOs.Category;
using eMarket.Application.Feature.Category.Requests;
using eMarket.Application.Patterns.Mediator;
using Microsoft.AspNetCore.Authorization;
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

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = 
            await _mediator.Send<GetAllCategoriesQuery, IEnumerable<CategoryListDto>>(new GetAllCategoriesQuery());
        return Ok(response);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync([FromBody] string name)
    {
        var response = await _mediator.Send<CreateCategoryCommand, int>(new CreateCategoryCommand { Name = name });
        return Ok(response);
    }
}