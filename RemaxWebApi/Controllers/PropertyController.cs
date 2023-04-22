using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemaxWebAPI.Models;

namespace RemaxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        public readonly RelEstDbContext _context;
        public PropertyController(RelEstDbContext context)
        {
            _context = context;
        }
        // GET: PropertyController
        [HttpGet(Name ="GetPropertyDetails")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.Property.ToListAsync());
        }

        // GET: PropertyController/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> DetailsAsync(int id)
        {
            if (id < 1)
                return BadRequest();
            var product = await _context.Property.FirstOrDefaultAsync(m => m.PropertyId == id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        //// GET: PropertyController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: PropertyController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: PropertyController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: PropertyController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: PropertyController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: PropertyController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
