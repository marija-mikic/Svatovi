using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Svatovi.Areas.Identity.Data;
using Svatovi.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace Svatovi.Controllers
{
    public class ImagessesController : Controller
    {
        private readonly SvatoviContext _context;

        public readonly IWebHostEnvironment webHostEnviroment;

        public ImagessesController(SvatoviContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            webHostEnviroment = webHostEnvironment;

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
        //public async Task<IActionResult> Create(Imagess images, IFormCollection multiple, IFormCollection multipleChart)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        Uploadsimage(images.Image, images);





        //        images.Image = new List<Imagess>();
        //        //books.Charts = new List<Charts>();

        //        UploadMultipleImages(multiple.Files, images);


        //        //UploadMultipleImagesCharts(multipleChart.Files, images);


        //        _context.Add(images);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(images);
        //}

        //void Uploadsimage(IFormFile singleImage, Imagess images)
        //{
        //    if (images.Imagefile != null)
        //    {
        //        string uploadsFolders = Path.Combine(_webHostEnvironment.WebRootPath, "Images/Cover");
        //        string uniqeFileName = Guid.NewGuid().ToString() + Path.GetExtension(images.Imagefile.Name) + ".png"; ;
        //        string filePath = Path.Combine(uploadsFolders, uniqeFileName);
        //        using (var FileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            images.Imagefile.CopyTo(FileStream);
        //        }
        //        images.Coment = uniqeFileName;
        //    }
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Image,Coment")] Imagess imagess)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(imagess);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(imagess);
        //}

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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,Coment")] ImagessModel imagess)
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
