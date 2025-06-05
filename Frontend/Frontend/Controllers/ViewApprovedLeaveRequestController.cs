using System.Text;
using DTO.LeaveRequestDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Frontend.Controllers;

[Authorize(Roles = "HR")]   
public class ViewApprovedLeaveRequestController : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public ViewApprovedLeaveRequestController(IHttpClientFactory clientFactory)
    {
         _clientFactory = clientFactory;
    }
    
    public async Task<IActionResult> Index()
    {
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5293/api/LeaveRequestByApproved/LeaveRequestByApproved");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetLeaveRequestByApprovedDto>>(json);
            return View(values);
        }
        
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> ApproveRequest(UpdateHrLeaveRequestDto leaveRequestDto)
    {
        leaveRequestDto.Status = "IK Onayladi";
        leaveRequestDto.RejectionReason = "---";    
        var client = _clientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(leaveRequestDto);    
        StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
        var response = await client.PutAsync("http://localhost:5293/api/UpdateHrLeaveRequest/UpdateHrLeaveRequest",content);
        if (!response.IsSuccessStatusCode)
        {
           
            return Json("Error");
        }
        
        return RedirectToAction("Index", "ViewApprovedLeaveRequest");
    }
}