using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Dojodachi.Models;

namespace Dojodachi.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    ////////////////////
    public IActionResult Index()
    {
        HttpContext.Session.Clear();
        DojodachiPet Dojito = new DojodachiPet();
        string message = "Welcome to Dojodachi!";
        HttpContext.Session.SetString("Message", message);
        
        return RedirectToAction("dojodachi", Dojito);
    }
    ////////////////////
    [HttpGet("dojodachi")]
    public IActionResult dojodachi(DojodachiPet dojito)
    {
        System.Console.WriteLine("entered dojodachi route");
        DojodachiPet Dojito = dojito;
        if(Dojito.CheckWin())
        {
        System.Console.WriteLine("Win has happened");
        string message = "You Win!";
        HttpContext.Session.SetString("Message", message);
        }
        if(Dojito.CheckLose())
        {
            System.Console.WriteLine("Loss has happened");
        string message = "You killed your Dojodachi!";
        HttpContext.Session.SetString("Message", message);
        }

        string? CheckMessage = HttpContext.Session.GetString("Message");
        System.Console.WriteLine($"Message will be: {CheckMessage}");

        HttpContext.Session.SetObjectAsJson("DojodachiPet", Dojito);

        return View("dojodachi", Dojito);
    }
    ////////////////////
    [HttpGet("feed")]
    public IActionResult Feed()
    {
        System.Console.WriteLine("entered 'feed'");
        DojodachiPet Dojito = HttpContext.Session.GetObjectFromJson<DojodachiPet>("DojodachiPet");
        string message = Dojito.Feed();
        HttpContext.Session.SetString("Message", message);
        HttpContext.Session.SetObjectAsJson("DojodachiPet", Dojito);
        System.Console.WriteLine("exiting 'feed'");
        return RedirectToAction("dojodachi", Dojito);
    }
    ////////////////////
    [HttpGet("play")]
    public IActionResult Play()
    {
        System.Console.WriteLine("entered 'play'");
        DojodachiPet Dojito = HttpContext.Session.GetObjectFromJson<DojodachiPet>("DojodachiPet");
        string message = Dojito.Play();
        HttpContext.Session.SetString("Message", message);
        HttpContext.Session.SetObjectAsJson("DojodachiPet", Dojito);
        System.Console.WriteLine("exiting 'play'");
        return RedirectToAction("dojodachi", Dojito);
    }

    ////////////////////
    [HttpGet("work")]
    public IActionResult Work()
    {
        System.Console.WriteLine("entered 'work'");
        DojodachiPet Dojito = HttpContext.Session.GetObjectFromJson<DojodachiPet>("DojodachiPet");
        string message = Dojito.Work();
        HttpContext.Session.SetString("Message", message);
        HttpContext.Session.SetObjectAsJson("DojodachiPet", Dojito);
        System.Console.WriteLine("exiting 'work'");
        return RedirectToAction("dojodachi", Dojito);
    }

    ////////////////////
    [HttpGet("sleep")]
    public IActionResult Sleep()
    {
        System.Console.WriteLine("entered 'sleep'");
        DojodachiPet Dojito = HttpContext.Session.GetObjectFromJson<DojodachiPet>("DojodachiPet");
        string message = Dojito.Sleep();
        HttpContext.Session.SetString("Message", message);
        HttpContext.Session.SetObjectAsJson("DojodachiPet", Dojito);
        System.Console.WriteLine("exiting 'sleep'");
        return RedirectToAction("dojodachi", Dojito);
    }

    ////////////////////
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
