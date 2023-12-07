using System.Text.Json;

namespace Lab5.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Lab5_lib;

[Authorize]
public class LabController : Controller
{
    public IActionResult FirstLab()
    {
        return View();
    }

    [HttpPost]
    public async Task<string> FirstLab([FromForm] string inputPath,[FromForm] string outputPath)
    {
        
        var response = Lab1.Run(inputPath, outputPath);

        return response;
    }

    public IActionResult SecondLab()
    {
        return View();
    }

    [HttpPost]
    public async Task<string> SecondLab([FromForm] string inputPath,[FromForm] string outputPath)
    {
        
        var response = Lab2.Run(inputPath, outputPath);

        return response;
    }

    public IActionResult ThirdLab()
    {
        return View();
    }

    [HttpPost]
    public async Task<string> ThirdLab([FromForm] string inputPath,[FromForm] string outputPath)
    {
        
        var response = Lab3.Run(inputPath, outputPath);

        return response;
    }
}