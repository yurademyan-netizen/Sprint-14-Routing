using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        public UsersController(Data data)
        {
            myUsers = data.Users;
        }

        [HttpPost]
        public IActionResult Index([FromBody] string id)
        {
            if (string.IsNullOrEmpty(id) || id != "df2323eoT")
            {
                return Unauthorized();
            }

            return View(myUsers);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
