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
        [HttpGet(Name = "GetLeadDetails")]
        public async Task<IActionResult> Index()
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

        //POST: RemaxLeadMgmtController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<int?> Create(IEnumerable<Leads> collection)
        {
            try
            {
                _context.Leads.AddRange(collection);
                return await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(AllLeadDetails));
            }
            catch
            {
                return null;
                //return BadRequest();        //    }
            }

            //// GET: RemaxLeadMgmtController/Edit/5
            //public ActionResult Edit(int id)
            //{
            //    return View();
            //}
        }
        //// POST: RemaxLeadMgmtController/Edit/5
        [HttpPut("{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Leads lead)
        {
            try
            {
                _context.Leads.Update(lead);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest();
            }
        }

        //// GET: RemaxLeadMgmtController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: RemaxLeadMgmtController/Delete/5
        [HttpDelete("{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<int> Delete(int id)
        {
            try
            {
                Leads? lead = _context.Leads.FirstOrDefault(x => x.LeadId == id);
                if (lead != null)
                {
                    _context.Leads.Remove(lead);
                    return await _context.SaveChangesAsync();
                }
                else
                    return -1;
                    
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return -1;
            }
        }


    }
}
