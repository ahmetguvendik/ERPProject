using System.Security.Claims;
using Domain.Enums;
using DTO.PurchaseRequestDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Frontend.Controllers;

public class CreatePurchaseController : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public CreatePurchaseController(IHttpClientFactory clientFactory)
    {
         _clientFactory = clientFactory;
    }
    
    private void FillUrgencyLevels()
    {
        ViewBag.UrgencyLevel = Enum.GetValues(typeof(UrgencyLevel))
            .Cast<UrgencyLevel>()
            .Select(g => new SelectListItem
            {
                Text = g.ToString(),
                Value = ((int)g).ToString()
            }).ToList();
    }

    public IActionResult Index()
    {
        FillUrgencyLevels();
        return View();
    }
    
    [HttpPost]
    public async Task<ActionResult> Index(CreatePurchaseRequestDto  createPurchaseRequestDto)
    {
        var userId = User.Identity.IsAuthenticated 
            ? User.FindFirstValue(ClaimTypes.NameIdentifier) 
            : null;

        var departmanId = User.Identity.IsAuthenticated 
            ? User.FindFirst("DepartmanId")?.Value 
            : null;
        
        var managerId = User.Identity.IsAuthenticated 
            ? User.FindFirst("ManagerId")?.Value 
            : null;
        
        createPurchaseRequestDto.CreatedAt = DateTime.Now;
        createPurchaseRequestDto.Statues = "Talep Alındı";
        createPurchaseRequestDto.UserId = userId;
        createPurchaseRequestDto.DepartmentId = departmanId;
        createPurchaseRequestDto.ManagerId = managerId;
        var client =  _clientFactory.CreateClient();
        var response = await client.PostAsJsonAsync("http://localhost:5293/api/Purchase", createPurchaseRequestDto);
        if (response.IsSuccessStatusCode)
        {
            TempData["SuccessMessage"] = "Talep Basarili Bir Sekilde Olusturuldu";
            FillUrgencyLevels();
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
         FillUrgencyLevels(); 
        return View("Index");
    }
}