using System.Diagnostics;
using AlarmService.Client;
using Microsoft.AspNetCore.Mvc;
using AlarmService.Web.Models;

namespace AlarmService.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IAlarmServiceClient _alarmServiceClient;
    public HomeController(ILogger<HomeController> logger, IAlarmServiceClient alarmServiceClient)
    {
        _alarmServiceClient = alarmServiceClient;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Alarm()
    {
        await _alarmServiceClient.PostAlarm("ALARM");
        return new OkResult();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}