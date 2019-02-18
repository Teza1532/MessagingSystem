using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MessagingService.Controllers
{
    public class RouteController : Controller
    {
        [Route("")]
        [Route("Route")]
        [Route("Route/Index")]
        public IActionResult Index()
        {
            if (User.Claims.Any(c => c.Type == "StaffID"))
            {
                return RedirectToRoute(new
                {
                    controller = "Staff",
                    action = "Index"
                });
            }
            else
            {
                return RedirectToRoute(new
                {
                    controller = "Customer",
                    action = "Index"
                });
            }

            
        }
    }
}