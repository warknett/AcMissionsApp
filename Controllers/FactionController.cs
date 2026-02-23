using Microsoft.AspNetCore.Mvc;
using AcMissionsApp.Data;
using AcMissionsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AcMissionsApp.Controllers
{
    public class FactionController : Controller
    {
        private readonly AppDbContext _context;

        public FactionController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> All()
        {
            var factions = await _context.Factions.ToListAsync();
            return View(factions);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var faction = await _context.Factions
                .Include(f => f.MissionFactions)
                .ThenInclude(mf => mf.Mission)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (faction == null)
                return NotFound();

            return View(faction);
        }
    }
}




