using System.Security.Claims;
using System.Text;
using Domain.Enums;
using DTO.LeaveRequestDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Frontend.Controllers;

public class CreateLeaveRequestController : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public CreateLeaveRequestController(IHttpClientFactory clientFactory)
    {
         _clientFactory = clientFactory;
    }
    
    public async Task<IActionResult> Index()
    {
        var types = Enum.GetValues(typeof(RequestType))
            .Cast<RequestType>()
            .Select(g => new SelectListItem
            {
                Text = g.ToString(),
                Value = ((int)g).ToString()
            }).ToList();

        ViewBag.RequestTypes = types;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(CreateLeaveRequestDto dto)
    {
        var userid = User.Identity.IsAuthenticated ? User.FindFirstValue(ClaimTypes.NameIdentifier) : null;
        var managerId = User.Identity.IsAuthenticated ?  User.FindFirstValue("ManagerId") : null;
        dto.CreatedAt = DateTime.Now;
        dto.Status = "Beklemede";
        dto.EmployeeId = userid;
        dto.ManagerId = managerId;
        var client = _clientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dto);
        StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
        var response = await client.PostAsync("http://localhost:5293/api/LeaveRequest", content);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Home");   
        }
        return View();
    }
    
}