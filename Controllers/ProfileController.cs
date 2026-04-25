using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using sujiayang.Models;

namespace sujiayang.Controllers;

public class ProfileController : Controller
{
    private readonly IWebHostEnvironment _environment;

    public ProfileController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<IActionResult> Index()
    {
        var profile = await LoadProfileAsync();
        return View(profile);
    }

    private async Task<ProfileViewModel> LoadProfileAsync()
    {
        var filePath = Path.Combine(_environment.ContentRootPath, "profile.json");

        if (!System.IO.File.Exists(filePath))
        {
            throw new FileNotFoundException("未找到 profile.json 文件。", filePath);
        }

        var json = await System.IO.File.ReadAllTextAsync(filePath);
        var profile = JsonSerializer.Deserialize<ProfileViewModel>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (profile is null)
        {
            throw new InvalidOperationException("profile.json 反序列化失败。");
        }

        profile.Contact ??= new ContactInfo();
        profile.EducationHistory ??= [];
        profile.Skills ??= [];
        profile.Projects ??= [];
        profile.ContactForm ??= new ContactFormModel();

        return profile;
    }
}
