using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemaxWebAPI.Models;

namespace RemaxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemaxLeadMgmtController : ControllerBase
    {
        public readonly RelEstDbContext _context;
        public RemaxLeadMgmtController(RelEstDbContext context)
        {
            _context = context;
        }

        // GET: RemaxLeadMgmtController
        [HttpGet(Name ="GetLeadDetails")]
        public async Task<IActionResult> AllLeadDetails()
        {
            return Ok(await _context.Leads.ToListAsync());
        }


        // GET: RemaxLeadMgmtController/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            if (id < 1)
                return BadRequest();
            var product = await _context.Leads.FirstOrDefaultAsync(m => m.LeadId == id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        //// GET: RemaxLeadMgmtController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: RemaxLeadMgmtController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IAsyncResult> Create(Leads collection)
        //{
        //    try
        //    {
        //        _context.Leads.Add(collection);
        //        return Ok(await _context.SaveChangesAsync());
        //        //return RedirectToAction(nameof(AllLeadDetails));
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        //// GET: RemaxLeadMgmtController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: RemaxLeadMgmtController/Edit/5
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

        //// GET: RemaxLeadMgmtController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: RemaxLeadMgmtController/Delete/5
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

        [HttpGet("Throw")]
        public IActionResult Throw() =>
    throw new Exception("Sample exception.");
    }
}
