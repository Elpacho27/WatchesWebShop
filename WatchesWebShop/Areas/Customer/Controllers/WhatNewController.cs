using Microsoft.AspNetCore.Mvc;

namespace WatchesWebShop.Areas.Customer.Controllers;

[Area("Customer")]
public class WhatNewController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
