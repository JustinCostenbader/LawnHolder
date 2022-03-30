using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LawnHolder.Domain.Entities.Settings;
using LawnHolder.Infrastructure.Persistence.DbContexts;
using LawnHolder.Web.Controllers;
using RoverCore.BreadCrumbs.Services;
using System.Threading.Tasks;
using RoverCore.Abstractions.Settings;
using LawnHolder.Infrastructure.Common.Settings.Services;

namespace LawnHolder.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = "Customer")]
    public class BrowseController : BaseController<BrowseController>
    {
        public IActionResult Index()
        {
            _breadcrumbs.StartAtAction("Dashboard", "Index", "Home", new { Area = "Dashboard" })
                .Then("Customer")
                .ThenAction("Browse", "Index", "Browse", new { Area = "Customer" });

            return View();
        }
    }
}
