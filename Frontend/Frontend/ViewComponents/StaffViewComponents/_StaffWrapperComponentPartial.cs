using System.Security.Claims;
using DTO.AppUserDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Frontend.ViewComponents.StaffViewComponents;

public class _StaffWrapperComponentPartial :  ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _StaffWrapperComponentPartial(IHttpClientFactory httpClientFactory)
    {
         _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var userid = HttpContext.User.Identity.IsAuthenticated 
            ? HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) 
            : null;
        var client = _httpClientFactory.CreateClient();
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