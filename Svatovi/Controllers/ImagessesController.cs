using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Svatovi.Areas.Identity.Data;
using Svatovi.Models;

namespace Svatovi.Controllers
{
    public class ImagessesController : Controller
    {
        private readonly SvatoviContext _context;

        public ImagessesController(SvatoviContext context)
        {
            _context = context;
        }

        // GET: Imagesses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Datas.ToListAsync());
        }

        // GET: Imagesses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagess = await _context.Datas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imagess == null)
            {
                return NotFound();
            }

            return View(imagess);
        }

        // GET: Imagesses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Imagesses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Image,Coment")] Imagess imagess)
        {
            if (ModelState.IsValid)
            {
                _context.Add(imagess);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imagess);
        }

        // GET: Imagesses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagess = await _context.Datas.FindAsync(id);
            if (imagess == null)
            {
                return NotFound();
            }
            return View(imagess);
        }

        // POST: Imagesses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,Coment")] Imagess imagess)
        {
            if (id != imagess.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imagess);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImagessExists(imagess.Id))
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
            return View(imagess);
        }

        // GET: Imagesses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagess = await _context.Datas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imagess == null)
            {
                return NotFound();
            }

            return View(imagess);
        }

        // POST: Imagesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imagess = await _context.Datas.FindAsync(id);
            if (imagess != null)
            {
                _context.Datas.Remove(imagess);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImagessExists(int id)
        {
            return _context.Datas.Any(e => e.Id == id);
        }
    }
}
