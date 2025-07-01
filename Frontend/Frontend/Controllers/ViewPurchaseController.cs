using System.Security.Claims;
using DTO.PurchaseRequestDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Frontend.Controllers;

public class ViewPurchaseController : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public ViewPurchaseController(IHttpClientFactory clientFactory)
    {
         _clientFactory = clientFactory;
    }
    
    public async Task<IActionResult> Index()
    {
        var userId = User.Identity.IsAuthenticated ? User.FindFirst(ClaimTypes.NameIdentifier).Value : null;
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync($"http://localhost:5293/api/Purchase?userId={userId}");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetPurchaseByUserIdDto>>(json);
            return View(values);
        }
        
        return View();
    }
    
}