using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP3.Data;
using TP3.Models;
using TP3.ViewModels;

namespace TP3.Controllers
{
    public class UtilisateursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UtilisateursController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var utilisateurs = await _context.Utilisateurs.ToListAsync();
            var vm = utilisateurs.Select(u => new UtilisateursIndexViewModel
            {
                Id = u.Id,
                Courriel = u.Courriel,
                Nom = u.Nom,
                Prenom = u.Prenom,
                Pseudonyme = u.Pseudonyme,
                MotDePasseActuel = u.MotDePasseActuel,
            });
                
            return View(vm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UtilisateursCreateViewModel vm)
        {
            var utilisateur = new Utilisateur
            {   
                Prenom = vm.Prenom,
                Nom = vm.Nom,
                Pseudonyme = vm.Pseudonyme,
                Courriel = vm.Courriel,
                MotDePasseActuel = vm.MotDePasseNouveau,
            };

            _context.Add(utilisateur);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.Utilisateurs.FindAsync(id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            var vm = new UtilisateursEditViewModel
            {
                Id = utilisateur.Id,
                Prenom = utilisateur.Prenom,
                Nom = utilisateur.Nom,
                Pseudonyme = utilisateur.Pseudonyme,
                Courriel = utilisateur.Courriel
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UtilisateursEditViewModel vm)
        {
            var utilisateurExistant = _context.Utilisateurs.Find(vm.Id);

            if (utilisateurExistant == null)
            {
                return NotFound();
            }

            utilisateurExistant.Prenom = vm.Prenom;
            utilisateurExistant.Nom = vm.Nom;
            utilisateurExistant.Pseudonyme = vm.Pseudonyme;
            utilisateurExistant.Courriel = vm.Courriel;

            _context.Update(utilisateurExistant);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditPassword(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilisateur = await _context.Utilisateurs.FindAsync(id);
            if (utilisateur == null)
            {
                return NotFound();
            }

            var vm = new UtilisateursEditPasswordViewModel
            {
                Id = utilisateur.Id,
                MotDePasseActuel = String.Empty,
                MotDePasseConfirmation = String.Empty,
                MotDePasseNouveau = String.Empty
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPassword(int id, UtilisateursEditPasswordViewModel vm)
        {
            var utilisateurExistant = _context.Utilisateurs.Find(vm.Id);

            if (utilisateurExistant == null)
            {
                return NotFound();
            }

            utilisateurExistant.MotDePasseActuel = vm.MotDePasseNouveau;
            _context.Update(utilisateurExistant);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
