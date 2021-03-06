﻿using System.Diagnostics;

using ICSP.WebProxy.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ICSP.WebProxy.Controllers
{
  public class ErrorController : Controller
  {
    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Index(int errorCode)
    {
      return View(new ErrorViewModel
      {
        ErrorCode = errorCode,
        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
      });
    }
  }
}
