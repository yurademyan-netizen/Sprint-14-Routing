using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using ProductsWithRouting.Models;
using ProductsWithRouting.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsWithRouting.Controllers
{
    public class UsersController : Controller
    {
        private readonly List<User> myUsers;
        private readonly IConfiguration configuration;

        public UsersController(Data data, IConfiguration config)
        {
            myUsers = data.Users;
            configuration = config;
        }

        [HttpPost]
        public IActionResult Index([FromBody] string id)
        {
            if (string.IsNullOrEmpty(id) || id != configuration["Password"])
            {
                ErrorViewModel model = new ErrorViewModel()
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    Message = "Seems you don’t have access to this information"
                };

                return View("Error", model);
            }

            return View(myUsers);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { StatusCode = StatusCodes.Status200OK });
        }

    }
}
