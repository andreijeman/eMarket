using eMarket.Application.DTOs.Product;
using eMarket.Application.Feature.Product.Requests;
using eMarket.Application.Patterns.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eMarket.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    { 
        var query = new GetProductQuery { Id = id };
        var response = await _mediator.Send<GetProductQuery, ProductDto>(query);
        return Ok(response);
    }

    [HttpGet("range")]
    public async Task<IActionResult> GetListAsync([FromQuery] int skip,  [FromQuery] int take)
    { 
        var query = new GetProductListQuery { Skip = skip, Take = take};
        var response = await _mediator.Send<GetProductListQuery, IEnumerable<ProductListDto>>(query);
        return Ok(response);
    }
    
    [Authorize(Roles = "User,Admin")]
    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync([FromForm] CreateProductDto product)
    {
        var command = new CreateProductCommand
        {
            Name = product.Name,
            Price = product.Price,
            Description = product.Description,
            Images =  product.Images,
            CategoryIds = product.CategoryIds
        };

        var response = await _mediator.Send<CreateProductCommand, int>(command); 
        return Ok(response);
    }
}