using eMarket.Application.DTOs.Product;
using eMarket.Application.Feature.Product.Requests.Commands;
using eMarket.Application.Feature.Product.Requests.Queries;
using eMarket.Application.Patterns.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace eMarket.WebApi.Controllers;

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
    public async Task<IActionResult> GetAsync([FromRoute] int id)
    { 
        var query = new GetProductQuery { Id = id };
        var response = await _mediator.Send<GetProductQuery, ProductDto>(query);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetListAsync([FromQuery] int skip,  [FromQuery] int take)
    { 
        var query = new GetProductListQuery { Skip = skip, Take = take};
        var response = await _mediator.Send<GetProductListQuery, IEnumerable<ProductListDto>>(query);
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CreateProductDto createProductDto)
    {
        var command = new CreateProductCommand { CreateProductDto = createProductDto };
        var response = await _mediator.Send<CreateProductCommand, int>(command); 
        return Ok(response);
    }
}