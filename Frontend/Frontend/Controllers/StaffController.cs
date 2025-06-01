using System.Security.Claims;
using Application.Features.Results.AppUserResults;
using DTO.AppUserDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Frontend.Controllers;

public class StaffController : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public StaffController(IHttpClientFactory clientFactory)
    {
         _clientFactory = clientFactory;
    }
    
    public async Task<IActionResult> Index()
    {
        var userid = User.Identity.IsAuthenticated ? User.FindFirstValue(ClaimTypes.NameIdentifier) : null;
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync($"http://localhost:5293/api/GetUserById?userId={userid}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<GetUserByIdDto>(jsonData);  
            return View(values);
        }
        
        return View();
    }
}
