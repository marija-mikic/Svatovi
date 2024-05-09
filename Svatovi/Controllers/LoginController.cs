using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Svatovi.Areas.Identity.Data;

namespace Svatovi.Controllers
{
    public class LoginController : Controller
    {
        private readonly SvatoviContext _context;

        public LoginController(SvatoviContext context)
        {
            _context = context;
        }



        // GET: Login
        //[Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            ViewBag.ErrorMessage = null;
            return View();
        }
        // POST: /Login
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public IActionResult Index(string name /*string role*/)
        {

            // Ovdje biste provjeravali korisničke podatke koristeći Entity Framework Core
            var svatoviUser = _context.Users.FirstOrDefault(u => u.name == name /*&& u.role == role*/);

            if (svatoviUser != null)
            {
                // Ako su korisnički podaci ispravni, možete preusmjeriti korisnika na početnu stranicu
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Ako su korisnički podaci neispravni, možete vratiti pogled sa porukom o grešci
                ViewBag.ErrorMessage = "Pogrešno korisničko ime ili lozinka.";
                return View();
            }
        }
    }
    //POST: /Login
    


        //    // GET: Login/Details/5
        //    public async Task<IActionResult> Details(string id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var svatoviUser = await _context.Users
        //            .FirstOrDefaultAsync(m => m.id == id);
        //        if (svatoviUser == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(svatoviUser);
        //    }

        //    // GET: Login/Create
        //    public IActionResult Create()
        //    {
        //        return View();
        //    }

        //    // POST: Login/Create
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Create([Bind("id,name,role")] SvatoviUser svatoviUser)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _context.Add(svatoviUser);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(svatoviUser);
        //    }

        //    // GET: Login/Edit/5
        //    public async Task<IActionResult> Edit(string id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var svatoviUser = await _context.Users.FindAsync(id);
        //        if (svatoviUser == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(svatoviUser);
        //    }

        //    // POST: Login/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(string id, [Bind("id,name,role")] SvatoviUser svatoviUser)
        //    {
        //        if (id != svatoviUser.id)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(svatoviUser);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!SvatoviUserExists(svatoviUser.id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(svatoviUser);
        //    }

        //    // GET: Login/Delete/5
        //    public async Task<IActionResult> Delete(string id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var svatoviUser = await _context.Users
        //            .FirstOrDefaultAsync(m => m.id == id);
        //        if (svatoviUser == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(svatoviUser);
        //    }

        //    // POST: Login/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(string id)
        //    {
        //        var svatoviUser = await _context.Users.FindAsync(id);
        //        if (svatoviUser != null)
        //        {
        //            _context.Users.Remove(svatoviUser);
        //        }

        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    private bool SvatoviUserExists(string id)
        //    {
        //        return _context.Users.Any(e => e.id == id);
        //    }
        //}
    }
