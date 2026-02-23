using AcMissionsApp.DTOs;
using AcMissionsApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcMissionsApp.Controllers
{
    public class MissionController : Controller
    {
        private readonly MissionService _missionService;
        private readonly FactionService _factionService;

        public MissionController(MissionService missionService, FactionService factionService)
        {
            _missionService = missionService;
            _factionService = factionService;
        }

        // LISTE DES MISSIONS
        public async Task<IActionResult> All()
        {
            var missions = await _missionService.GetAllAsync();
            return View(missions);
        }

        // DETAILS D'UNE MISSION
        public async Task<IActionResult> Detail(int id)
        {
            var mission = await _missionService.GetDetailAsync(id);
            if (mission == null) return NotFound();
            return View(mission);
        }

        // FORMULAIRE AJOUT
        public async Task<IActionResult> Ajout()
        {
            var factions = await _factionService.GetAllAsync();
            ViewBag.Factions = factions;
            return View();
        }

        // TRAITEMENT AJOUT (CORRIGÉ AVEC LOCATION)
        [HttpPost]
        public async Task<IActionResult> Ajout(string title, string description, string difficulty, string? reward, string location, List<int> factionIds)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description))
            {
                ModelState.AddModelError("", "Titre et description sont obligatoires.");
            }

            if (!ModelState.IsValid)
            {
                var factions = await _factionService.GetAllAsync();
                ViewBag.Factions = factions;
                return View();
            }

            await _missionService.CreateAsync(title, description, difficulty, reward, location, factionIds);
            return RedirectToAction("All");
        }

        // FORMULAIRE MODIFICATION
        public async Task<IActionResult> Modification(int id)
        {
            var mission = await _missionService.GetDetailAsync(id);
            if (mission == null) return NotFound();

            var factions = await _factionService.GetAllAsync();
            ViewBag.Factions = factions;
            return View(mission);
        }

        // TRAITEMENT MODIFICATION
        [HttpPost]
        public async Task<IActionResult> Modification(int id, string title, string description, string difficulty, string? reward, List<int> factionIds)
        {
            await _missionService.UpdateAsync(id, title, description, difficulty, reward, factionIds);
            return RedirectToAction("Detail", new { id });
        }

        // SUPPRESSION
        public async Task<IActionResult> Suppression(int id)
        {
            await _missionService.DeleteAsync(id);
            return RedirectToAction("All");
        }

        // FILTRE PAR FACTION (OPTIONNEL)
        public async Task<IActionResult> FiltreFaction(string faction)
        {
            return RedirectToAction("All");
        }
    }
}


