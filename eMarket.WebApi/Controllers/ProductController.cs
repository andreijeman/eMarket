using eMarket.Application.DTOs.Product;
using eMarket.Application.Feature.Product.Requests.Queries;
using eMarket.Application.Patterns.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace eMarket.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("/{id:int}")]
    public async Task<IActionResult> GetAsync(int id)
    { 
        var request = new GetProductRequest { Id = id };
        var response = await _mediator.Send<GetProductRequest, ProductDto>(request);
        
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetListAsync([FromQuery] int start, [FromQuery] int count)
    { 
        var request = new GetProductListRequest { Start = start, Count = count };
        var response = await _mediator.Send<GetProductListRequest, IEnumerable<ProductListDto>>(request);
        
        return Ok(response);
    }
}