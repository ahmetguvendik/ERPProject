using System.Text;
using Domain.Entities;
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
        var client = _clientFactory.CreateClient();
        var response = await client.GetAsync("http://localhost:5293/api/JobType");
        var jsonData = await response.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<GetJobTypeDto>>(jsonData);
        List<SelectListItem> items = (from item in values
            select new SelectListItem
            {
                Text = item.Name,
                Value = item.Id.ToString()
            }).ToList();
        
        ViewBag.JobTypes = items;
        
        var response2 = await client.GetAsync("http://localhost:5293/api/Departman");
        var jsonData2 = await response2.Content.ReadAsStringAsync();
        var values2 = JsonConvert.DeserializeObject<List<GetDepartmanDto>>(jsonData2);
        List<SelectListItem> items2 = (from item in values2
            select new SelectListItem
            {
                Text = item.Name,
                Value = item.Id.ToString()
            }).ToList();
        
        ViewBag.Departmans = items2;    
        
        return View();
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
            return RedirectToAction("Index","Home");    
           
        }
        
        return View("Index");   
    }
}