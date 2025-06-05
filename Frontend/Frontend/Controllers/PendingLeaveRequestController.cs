using System.Security.Claims;
using System.Text;
using DTO.LeaveRequestDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Frontend.Controllers;

public class PendingLeaveRequestController : Controller
{
   private readonly IHttpClientFactory _clientFactory;

   public PendingLeaveRequestController(IHttpClientFactory clientFactory)
   {
        _clientFactory = clientFactory;
   } 
   
   [HttpGet]
   public async Task<IActionResult> Index()
    {
        var userid = User.Identity.IsAuthenticated ? User.FindFirstValue(ClaimTypes.NameIdentifier) : null; ;
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync($"http://localhost:5293/api/LeaveRequestByManagerId/LeaveRequestByManagerId/{userid}");
        if (response.IsSuccessStatusCode)
        {
            var jsondata= await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetLeaveRequestByManagerIdDto>>(jsondata);
            return View(values);
        }
        return View();
    }

   [HttpPost]
    public async Task<IActionResult> ApproveRequest(UpdateLeaveRequestDto leaveRequestDto)
    {
        leaveRequestDto.Status = "Onaylandi";
        leaveRequestDto.RejectionReason = "Izin Onaylandi";
        var client = _clientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(leaveRequestDto);    
        StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
        var response = await client.PutAsync("http://localhost:5293/api/UpdateLeaveRequest",content);
        if (!response.IsSuccessStatusCode)
        {
           
            return Json("Error");
        }
        
        return RedirectToAction("Index", "PendingLeaveRequest");
    }
    
   
    [HttpPost]
    public async Task<IActionResult> CreateRejectDescriptionPartial(UpdateRejectLeaveRequestDto dto)
    {
        dto.Status = "Reddedildi";
        var client = _clientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dto);
        StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
        var response = await client.PutAsync("http://localhost:5293/api/UpdateRejectLeaveRequest/UpdateRejectLeaveRequest",content);
        if (!response.IsSuccessStatusCode)
        {
            return Json("Error");
        }
        

        return RedirectToAction("Index", "PendingLeaveRequest");
    }
}