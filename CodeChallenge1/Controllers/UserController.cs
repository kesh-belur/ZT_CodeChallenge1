﻿using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge1.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
