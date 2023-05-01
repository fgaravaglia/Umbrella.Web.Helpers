using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Umbrella.UI.Web.MVC.Helpers.Portal.Controllers
{
    public class BreadCrumbController: Controller
    {
        private readonly ILogger<BreadCrumbController> _logger;

        public BreadCrumbController(ILogger<BreadCrumbController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
    }
}