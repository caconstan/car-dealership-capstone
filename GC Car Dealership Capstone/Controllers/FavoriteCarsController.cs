using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GC_Car_Dealership_Capstone.Data;
using GC_Car_Dealership_Capstone.Models;
using System.Security.Claims;

namespace GC_Car_Dealership_Capstone.Controllers
{
    public class FavoriteCarsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly InventoryDAL _dal;
        public FavoriteCarsController(ApplicationDbContext context)
        {
            _context = context;
            _dal = new InventoryDAL();
        }

        // GET: FavoriteCars
        public async Task<IActionResult> Index()
        {
            List<FavoriteCars> fcl = await _context.FavoriteCars.ToListAsync();
            fcl.ForEach(x => x.Userid = User.FindFirst(ClaimTypes.Name).Value);

            return View( fcl );
        }

        // GET: FavoriteCars/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorites(int CarID)
        {
            FavoriteCars fc = new FavoriteCars();
            fc.Userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            fc.Carid = CarID;

            Cars car = await _dal.GetCar(CarID);
            fc.Color = car.Color;
            fc.Make = car.Make;
            fc.Model = car.Model;
            fc.Year = car.Year;

            _context.Add( fc );
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(FavoriteCars favoriteCars)
        {
            favoriteCars.Userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _context.Add(favoriteCars);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: FavoriteCars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var favoriteCars = await _context.FavoriteCars
                .FirstOrDefaultAsync(m => m.Id == id);
            if (favoriteCars == null)
            {
                return NotFound();
            }

            return View(favoriteCars);
        }

        // POST: FavoriteCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var favoriteCars = await _context.FavoriteCars.FindAsync(id);
            _context.FavoriteCars.Remove(favoriteCars);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavoriteCarsExists(int id)
        {
            return _context.FavoriteCars.Any(e => e.Id == id);
        }
    }
}
