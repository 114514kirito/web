using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using sujiayang.Data;
using sujiayang.Models;

namespace sujiayang.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _dbContext;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    public async Task<IActionResult> MessageList()
    {
        var messages = await _dbContext.ContactMessages
            .OrderByDescending(message => message.CreatedAtUtc)
            .ToListAsync();

        return View(messages);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SubmitContact([Bind(Prefix = "ContactForm")] ContactFormModel form)
    {
        if (!ModelState.IsValid)
        {
            TempData["ErrorMessage"] = "请完整填写留言表单后再提交。";
            return RedirectToAction("Index", "Profile");
        }

        var contactMessage = new ContactMessage
        {
            Name = form.Name,
            Email = form.Email,
            Message = form.Message,
            CreatedAtUtc = DateTime.UtcNow
        };

        _dbContext.ContactMessages.Add(contactMessage);
        await _dbContext.SaveChangesAsync();

        TempData["SuccessMessage"] = "留言发送成功";
        return RedirectToAction("Index", "Profile");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
