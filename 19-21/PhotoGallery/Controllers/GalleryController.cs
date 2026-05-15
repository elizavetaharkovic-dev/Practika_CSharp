using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotoGallery.Data;
using PhotoGallery.Models;

namespace PhotoGallery.Controllers
{
    public class GalleryController : Controller
    {
        private readonly AppDbContext _context;

        public GalleryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Gallery/Index
        public async Task<IActionResult> Index()
        {
            var images = await _context.ImageItems.ToListAsync();
            ViewBag.Total = images.Count;
            return View(images);
        }

        // GET: /Gallery/Show/5
        public async Task<IActionResult> Show(int id)
        {
            var image = await _context.ImageItems.FindAsync(id);
            if (image == null) return NotFound();
            return View(image);
        }

        // GET: /Gallery/Add
        public IActionResult Add()
        {
            return View();
        }

        // POST: /Gallery/Add
        [HttpPost]
        public async Task<IActionResult> Add(ImageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var image = new ImageItem
            {
                Title = model.Title,
                Url = model.Url,
                Description = model.Description
            };

            _context.ImageItems.Add(image);
            await _context.SaveChangesAsync();
            TempData["Message"] = "Изображение успешно добавлено!";
            return RedirectToAction("Index");
        }

        // GET: /Gallery/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var image = await _context.ImageItems.FindAsync(id);
            if (image == null) return NotFound();
            return View(image);
        }

        // POST: /Gallery/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ImageItem image)
        {
            if (id != image.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(image);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Заголовок успешно обновлён!";
                return RedirectToAction("Index");
            }
            return View(image);
        }

        // GET: /Gallery/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var image = await _context.ImageItems.FindAsync(id);
            if (image == null) return NotFound();
            return View(image);
        }

        // POST: /Gallery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var image = await _context.ImageItems.FindAsync(id);
            if (image != null)
            {
                _context.ImageItems.Remove(image);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Изображение удалено!";
            }
            return RedirectToAction("Index");
        }
    }
}