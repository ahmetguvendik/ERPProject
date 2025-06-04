using System.Security.Claims;
using Application.Features.Results.AppUserResults;
using DTO.AppUserDto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

public class LoginController : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public LoginController(IHttpClientFactory clientFactory)
    {
         _clientFactory = clientFactory;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(LoginUserDto dto)
    {
        var client = _clientFactory.CreateClient();
        try
        {

            var response = await client.PostAsJsonAsync("http://localhost:5293/api/Login" ,dto);
            if (response.IsSuccessStatusCode)
            {
                var loginResult = await response.Content.ReadFromJsonAsync<LoginUserQueryResult>();
                if (loginResult != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, loginResult.Id),
                        new Claim("TcNo", dto.TcNo),
                        new Claim("ManagerId",loginResult.ManagerId),
                        new Claim("Role",loginResult.RoleName)
                    };
                
                    var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync("MyCookieAuth", principal);

                    return loginResult.RoleName switch
                    {
                        "Staff" => RedirectToAction("Index", "Staff"),
                        "HR" => RedirectToAction("Index", "HR"),
                        "Manager" => RedirectToAction("Index", "Manager"),
                        _ => RedirectToAction("Index", "Login")     
                    };
                }
                
                
            }
            else
            {
                var errorText = await response.Content.ReadAsStringAsync();
                ViewBag.Error = "Sunucudan hata döndü: " + errorText;   
            }
        }
        catch (Exception e)
        {
            ViewBag.Error = "İstek sırasında beklenmeyen bir hata oluştu: " + e.Message;
        }
        
        return View();
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
    
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("MyCookieAuth");
        return RedirectToAction("Index", "Login");      
    }
}