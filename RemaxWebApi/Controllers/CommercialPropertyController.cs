using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RemaxWebApi.Models;
using RemaxWebAPI.Models;

namespace RemaxWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommercialPropertyController : ControllerBase
    {
        public readonly RelEstDbContext _context;
        public CommercialPropertyController(RelEstDbContext context)
        {
            _context = context;
        }
        // GET: PropertyController
        [HttpGet(Name ="GetPropertyDetails")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.CommercialProperty.ToListAsync());
        }

        // GET: PropertyController/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> DetailsAsync(int id)
        {
            if (id < 1)
                return BadRequest();
            var product = await _context.CommercialProperty.FirstOrDefaultAsync(m => m.PropertyId == id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<int?> Create(IEnumerable<CommercialProperty> collection)
        {
            try
            {
                _context.CommercialProperty.AddRange(collection);
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
        public async Task<IActionResult> Edit(int id, CommercialProperty lead)
        {
            try
            {
                _context.CommercialProperty.Update(lead);
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
                var lead = _context.CommercialProperty.FirstOrDefault(x => x.PropertyId == id);
                if (lead != null)
                {
                    _context.CommercialProperty.Remove(lead);
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
