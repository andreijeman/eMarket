using eMarket.Application.DTOs.Product;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace eMarket.Web.Pages;

public class AllProducts : PageModel
{
    private readonly HttpClient _client;
    private readonly IConfiguration _configuration;
    
    public List<ProductListDto> Products { get; set; } = new List<ProductListDto>();
    
    public AllProducts(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _client = httpClientFactory.CreateClient();
        _configuration = configuration;
    }

    public async Task OnGetAsync()
    {
        var response = await _client
            .GetFromJsonAsync<List<ProductListDto>>($"{_configuration["Api:BaseUrl"]}/Product/range?skip=0&take=9999");
        
        if(response != null) Products = response; 
    }
}