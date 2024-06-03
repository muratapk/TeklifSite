using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeklifSite.Data;
using TeklifSite.Models;

namespace TeklifSite.Controllers
{
    public class SlidersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SlidersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sliders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sliders.ToListAsync());
        }

        // GET: Sliders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sliders = await _context.Sliders
                .FirstOrDefaultAsync(m => m.SliderId == id);
            if (sliders == null)
            {
                return NotFound();
            }

            return View(sliders);
        }

        // GET: Sliders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sliders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SliderId,SliderName,Header1,Heeader2,Context,SliderImage")] Sliders sliders,IFormFile ImageUpload)
        {

            if (ImageUpload != null)
            {
                var uzanti = Path.GetExtension(ImageUpload.FileName);
                //bocek.png  .png domates.jpg  .jpg
                string yeniisim = Guid.NewGuid().ToString() + uzanti;

                string yol = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/Urunler/" + yeniisim);
                using (var stream = new FileStream(yol, FileMode.Create))
                {
                    ImageUpload.CopyToAsync(stream);
                }
                sliders.SliderName = yeniisim;
            }



            if (ModelState.IsValid)
            {
                _context.Add(sliders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sliders);
        }

        // GET: Sliders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sliders = await _context.Sliders.FindAsync(id);
            if (sliders == null)
            {
                return NotFound();
            }
            return View(sliders);
        }

        // POST: Sliders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SliderId,SliderName,Header1,Heeader2,Context,SliderImage")] Sliders sliders, IFormFile ImageUpload)
        {

            if (ImageUpload != null)
            {
                var uzanti = Path.GetExtension(ImageUpload.FileName);
                //bocek.png  .png domates.jpg  .jpg
                string yeniisim = Guid.NewGuid().ToString() + uzanti;

                string yol = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/Urunler/" + yeniisim);
                using (var stream = new FileStream(yol, FileMode.Create))
                {
                    ImageUpload.CopyToAsync(stream);
                }
                sliders.SliderName = yeniisim;
            }




            if (id != sliders.SliderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sliders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlidersExists(sliders.SliderId))
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
            return View(sliders);
        }

        // GET: Sliders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sliders = await _context.Sliders
                .FirstOrDefaultAsync(m => m.SliderId == id);
            if (sliders == null)
            {
                return NotFound();
            }

            return View(sliders);
        }

        // POST: Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sliders = await _context.Sliders.FindAsync(id);
            if (sliders != null)
            {
                _context.Sliders.Remove(sliders);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlidersExists(int id)
        {
            return _context.Sliders.Any(e => e.SliderId == id);
        }
    }
}
