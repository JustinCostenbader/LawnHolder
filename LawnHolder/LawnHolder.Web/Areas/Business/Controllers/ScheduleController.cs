using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LawnHolder.Domain.Entities.Settings;
using LawnHolder.Infrastructure.Persistence.DbContexts;
using LawnHolder.Web.Controllers;
using RoverCore.BreadCrumbs.Services;
using System.Threading.Tasks;
using RoverCore.Abstractions.Settings;
using LawnHolder.Infrastructure.Common.Settings.Services;

namespace LawnHolder.Web.Areas.Business.Controllers
{
    [Area("Business")]
    [Authorize(Roles = "Business")]
    public class ScheduleController : BaseController<ScheduleController>
    {
        public IActionResult Index()
        {
            _breadcrumbs.StartAtAction("Dashboard", "Index", "Home", new { Area = "Dashboard" })
                .Then("Business")
                .ThenAction("Schedule", "Index", "Schedule", new { Area = "Business" });

            return View();
        }
    }
}
