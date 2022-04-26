using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RoverCore.BreadCrumbs.Services;
using RoverCore.Datatables.DTOs;
using RoverCore.Datatables.Extensions;
using LawnHolder.Web.Controllers;
using LawnHolder.Infrastructure.Common.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using LawnHolder.Domain.Entities;
using LawnHolder.Infrastructure.Persistence.DbContexts;
using LawnHolder.Domain.Entities.Identity;

namespace LawnHolder.Web.Areas.Business.Controllers;

[Area("Business")]
[Authorize(Roles = "Business")]
public class BusinessProfileController : BaseController<BusinessProfileController>
{
	public class BusinessProfileIndexViewModel 
	{
		[Key]            
	    public string BusinessId { get; set; }
	    public string BusinessName { get; set; }
	    public string PhoneNumber { get; set; }
	    public string ServicedAreas { get; set; }
	    public string Description { get; set; }
	}

	private const string createBindingFields = "BusinessId,BusinessName,PhoneNumber,ServicedAreas,Description";
    private const string editBindingFields = "BusinessId,BusinessName,PhoneNumber,ServicedAreas,Description";
    private const string areaTitle = "Business";

    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public BusinessProfileController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // GET: Business/BusinessProfile
    public IActionResult Index()
    {
        _breadcrumbs.StartAtAction("Dashboard", "Index", "Home", new { Area = "Dashboard" })
			.Then("Manage BusinessProfile");       
		
		// Fetch descriptive data from the index dto to build the datatables index
		var metadata = DatatableExtensions.GetDtMetadata<BusinessProfileIndexViewModel>();
		
		return View(metadata);
   }

    // GET: Business/BusinessProfile/Details/5
    public async Task<IActionResult> Details(string id)
    {
        ViewData["AreaTitle"] = areaTitle;
        _breadcrumbs.StartAtAction("Dashboard", "Index", "Home", new { Area = "Dashboard" })
            .ThenAction("Manage BusinessProfile", "Index", "BusinessProfile", new { Area = "Business" })
            .Then("BusinessProfile Details");            

        if (id == null)
        {
            return NotFound();
        }

        var businessProfile = await _context.BusinessProfile
            .FirstOrDefaultAsync(m => m.BusinessId == id);
        if (businessProfile == null)
        {
            return NotFound();
        }

        return View(businessProfile);
    }

    // GET: Business/BusinessProfile/Create
    public IActionResult Create()
    {
        _breadcrumbs.StartAtAction("Dashboard", "Index", "Home", new { Area = "Dashboard" })
            .ThenAction("Manage BusinessProfile", "Index", "BusinessProfile", new { Area = "Business" })
            .Then("Create BusinessProfile");     

       return View();
	}

    // POST: Business/BusinessProfile/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind(createBindingFields)] BusinessProfile businessProfile)
    {
        ViewData["AreaTitle"] = areaTitle;

        _breadcrumbs.StartAtAction("Dashboard", "Index", "Home", new { Area = "Dashboard" })
        .ThenAction("Manage BusinessProfile", "Index", "BusinessProfileController", new { Area = "Business" })
        .Then("Create BusinessProfile");     
        
        // Remove validation errors from fields that aren't in the binding field list
        ModelState.Scrub(createBindingFields);           

        if (ModelState.IsValid)
        {
            _context.Add(businessProfile);
            await _context.SaveChangesAsync();
            
            _toast.Success("Created successfully.");
            
                return RedirectToAction(nameof(Index));
            }
        return View(businessProfile);
    }

    // GET: Business/BusinessProfile/Edit/5
    public async Task<IActionResult> Edit(string id)
    {
        ViewData["AreaTitle"] = areaTitle;

        _breadcrumbs.StartAtAction("Dashboard", "Index", "Home", new { Area = "Dashboard" })
        .ThenAction("Manage BusinessProfile", "Index", "BusinessProfile", new { Area = "Business" })
        .Then("Edit BusinessProfile");     

        if (id == null)
        {
            return NotFound();
        }

        var businessProfile = await _context.BusinessProfile.FindAsync(id);
        if (businessProfile == null)
        {
            return NotFound();
        }
        

        return View(businessProfile);
    }

    // POST: Business/BusinessProfile/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind(editBindingFields)] BusinessProfile businessProfile)
    {
        ViewData["AreaTitle"] = areaTitle;

        _breadcrumbs.StartAtAction("Dashboard", "Index", "Home", new { Area = "Dashboard" })
        .ThenAction("Manage BusinessProfile", "Index", "BusinessProfile", new { Area = "Business" })
        .Then("Edit BusinessProfile");  
    
        if (id != businessProfile.BusinessId)
        {
            return NotFound();
        }
        
        BusinessProfile model = await _context.BusinessProfile.FindAsync(id);

        model.BusinessName = businessProfile.BusinessName;
        model.PhoneNumber = businessProfile.PhoneNumber;
        model.ServicedAreas = businessProfile.ServicedAreas;
        model.Description = businessProfile.Description;
        // Remove validation errors from fields that aren't in the binding field list
        ModelState.Scrub(editBindingFields);           

        if (ModelState.IsValid)
        {
            try
            {
                await _context.SaveChangesAsync();
                _toast.Success("Updated successfully.");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessProfileExists(businessProfile.BusinessId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(businessProfile);
    }

    // GET: Business/BusinessProfile/Delete/5
    public async Task<IActionResult> Delete(string id)
    {
        ViewData["AreaTitle"] = areaTitle;

        _breadcrumbs.StartAtAction("Dashboard", "Index", "Home", new { Area = "Dashboard" })
        .ThenAction("Manage BusinessProfile", "Index", "BusinessProfile", new { Area = "Business" })
        .Then("Delete BusinessProfile");  

        if (id == null)
        {
            return NotFound();
        }

        var businessProfile = await _context.BusinessProfile
            .FirstOrDefaultAsync(m => m.BusinessId == id);
        if (businessProfile == null)
        {
            return NotFound();
        }

        return View(businessProfile);
    }

    // POST: Business/BusinessProfile/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var businessProfile = await _context.BusinessProfile.FindAsync(id);
        _context.BusinessProfile.Remove(businessProfile);
        await _context.SaveChangesAsync();
        
        _toast.Success("BusinessProfile deleted successfully");

        return RedirectToAction(nameof(Index));
    }

    private bool BusinessProfileExists(string id)
    {
        return _context.BusinessProfile.Any(e => e.BusinessId == id);
    }


	[HttpPost]
	[ValidateAntiForgeryToken]
    public async Task<IActionResult> GetBusinessProfile(DtRequest request)
    {
        try
		{
			var query = _context.BusinessProfile;
			var jsonData = await query.GetDatatableResponseAsync<BusinessProfile, BusinessProfileIndexViewModel>(request);

            return Ok(jsonData);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating BusinessProfile index json");
        }
        
        return StatusCode(500);
    }

}

