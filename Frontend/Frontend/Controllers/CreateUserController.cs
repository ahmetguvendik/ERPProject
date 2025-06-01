using System.Text;
using Domain.Entities;
using Domain.Enums;
using DTO.AppRoleDto;
using DTO.AppUserDto;
using DTO.DepartmanDto;
using DTO.JobTypeDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Frontend.Controllers;

public class CreateUserController : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public CreateUserController(IHttpClientFactory clientFactory)
    {
         _clientFactory = clientFactory;
    }
    
    public async Task<IActionResult> Index()    
    {
        await FillViewBags();
        return View();
    }

    private async Task FillViewBags()
    {
        var client = _clientFactory.CreateClient();

        var response1 = await client.GetAsync("http://localhost:5293/api/JobType");
        var values1 = JsonConvert.DeserializeObject<List<GetJobTypeDto>>(await response1.Content.ReadAsStringAsync());
        ViewBag.JobTypes = values1.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

        var response2 = await client.GetAsync("http://localhost:5293/api/Departman");
        var values2 = JsonConvert.DeserializeObject<List<GetDepartmanDto>>(await response2.Content.ReadAsStringAsync());
        ViewBag.Departmans = values2.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

        var response3 = await client.GetAsync("http://localhost:5293/api/Role");
        var values3 = JsonConvert.DeserializeObject<List<GetRoleDto>>(await response3.Content.ReadAsStringAsync());
        ViewBag.Roles = values3.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

        var response4 = await client.GetAsync("http://localhost:5293/api/Role/GetManagerRole");
        var values4 = JsonConvert.DeserializeObject<List<GetManagerDto>>(await response4.Content.ReadAsStringAsync());
        ViewBag.Managers = values4.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

        var genders = Enum.GetValues(typeof(Gender))
            .Cast<Gender>()
            .Select(g => new SelectListItem
            {
                Text = g.ToString(),
                Value = ((int)g).ToString()
            }).ToList();

        ViewBag.Genders = genders;
    }

    
    [HttpPost]
    public async Task<IActionResult> Index(CreateUserDto dto)
    {
        
        dto.IsActive = true;
        var client = _clientFactory.CreateClient();
        var jsonData = JsonConvert.SerializeObject(dto);
        StringContent content = new StringContent(jsonData,Encoding.UTF8 , "application/json");
        var response = await client.PostAsync("http://localhost:5293/api/Register", content);
        if (response.IsSuccessStatusCode)
        {
            TempData["SuccessMessage"] = "Kisi Basarili Bir Sekilde Olusturuldu";
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
        return View("Index");
    }
}