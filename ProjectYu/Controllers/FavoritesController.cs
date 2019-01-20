using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectYu.Models;

namespace ProjectYu.Controllers
{
    public class FavoritesController : Controller
    {
        public IActionResult Index(LoginedUserModel loginedUserModel)
        {


            return View(loginedUserModel);
        }
    }
}