using System.Security.Claims;
using DTO.LeaveRequestDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Frontend.Controllers;

public class ViewLeaveRequestController : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public ViewLeaveRequestController(IHttpClientFactory clientFactory)
    {
         _clientFactory = clientFactory;
    }
    
    public async Task<IActionResult> Index()
    {
        var employeeId = User.Identity.IsAuthenticated ? User.FindFirstValue(ClaimTypes.NameIdentifier) : null;
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync($"http://localhost:5293/api/LeaveRequestByEmployeeId?employeeId={employeeId}");
        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetLeaveRequestByEmployeeIdDto>>(jsonData);
            return View(values);
        }
        
        return View();
    }
}