using System.Security.Claims;
using DTO.AppUserDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Frontend.Controllers;

[Authorize(Roles = "Manager")]
public class ManagerController : Controller
{private readonly IHttpClientFactory _clientFactory;

    public ManagerController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var userid = User.Identity.IsAuthenticated ? User.FindFirstValue(ClaimTypes.NameIdentifier) : null;
        ViewBag.UserId = userid;
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