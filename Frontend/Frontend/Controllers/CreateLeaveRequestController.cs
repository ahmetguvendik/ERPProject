using System.Security.Claims;
using System.Text;
using Domain.Enums;
using DTO.LeaveQuotaDto;
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
        await FillViewBags();
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
                TempData["SuccessMessage"] = "Izin Basarili Sekilde Yoneticinize Gonderildi ";
                await FillViewBags();
                return View();
            }
            
            var responseContent = await response.Content.ReadAsStringAsync();
            var allErrors = new List<string>();
            try
            {
                var errors = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(responseContent);
                if (errors != null)
                {
                    foreach (var err in errors)
                    {
                        allErrors.AddRange(err.Value);
                    }
                }
                else
                {
                    allErrors.Add("Bilinmeyen bir hata oluştu.");
                }
            }
            catch
            {
                allErrors.Add("Sunucudan geçersiz cevap alındı.");
                allErrors.Add(responseContent); 
            }

        
        TempData["ErrorMessages"] = JsonConvert.SerializeObject(allErrors);
        await FillViewBags(); 
        return View();
    }
    
    private async Task FillViewBags()
    {
        var types = Enum.GetValues(typeof(RequestType))
            .Cast<RequestType>()
            .Select(g => new SelectListItem
            {
                Text = g.ToString(),
                Value = ((int)g).ToString()
            }).ToList();

        ViewBag.RequestTypes = types;
    }
    
    [HttpGet]
    public async Task<PartialViewResult> GetLeaveQuotaPartial(string userId)
    {
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync($"http://localhost:5293/api/LeaveQuota?id={userId}");
        if (!response.IsSuccessStatusCode)
        {
            // Hata durumunda boş partial veya hata mesajı dönebilirsin
            return PartialView("GetLeaveQuotaPartial", null);
        }

        var jsonData = await response.Content.ReadAsStringAsync();
        var leaveQuota = JsonConvert.DeserializeObject<List<GetLeaveQuotaDto>>(jsonData);

        return PartialView("GetLeaveQuotaPartial", leaveQuota);
    }

    
    
}