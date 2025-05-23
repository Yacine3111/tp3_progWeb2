﻿using Microsoft.AspNetCore.Mvc;
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
                InfoLettre = u.InfoLettre,
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
        public async Task<IActionResult> Create([Bind("Id", "Prenom", "Nom", "Pseudonyme", "Courriel", "InfoLettre", "MotDePasseNouveau", "MotDePasseConfirmation")] UtilisateursCreateViewModel vm)
        {

            var utilisateurs = await _context.Utilisateurs.ToListAsync();


            if (utilisateurs.Any(u => string.Equals(u.Pseudonyme, vm.Pseudonyme, StringComparison.OrdinalIgnoreCase)))
            {
                ModelState.AddModelError(nameof(UtilisateursCreateViewModel.Pseudonyme), "Ce pseudonyme est déjà utilisé.");

            }

            if (utilisateurs.Any(u => u.Courriel == vm.Courriel && vm.Courriel != null))
            {
                ModelState.AddModelError(nameof(UtilisateursCreateViewModel.Courriel), "Ce courriel est déjà utilisé.");

            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var utilisateur = new Utilisateur
            {
                Prenom = vm.Prenom,
                Nom = vm.Nom,
                Pseudonyme = vm.Pseudonyme,
                Courriel = vm.Courriel,
                InfoLettre = vm.InfoLettre,
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
                Courriel = utilisateur.Courriel,
                InfoLettre = utilisateur.InfoLettre

            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id", "Prenom", "Nom", "Pseudonyme", "Courriel", "InfoLettre")] UtilisateursEditViewModel vm)
        {


            var utilisateurs = await _context.Utilisateurs.ToListAsync();

            if (utilisateurs.Any(u => u.Pseudonyme == vm.Pseudonyme && u.Id != vm.Id))
            {
                ModelState.AddModelError(nameof(UtilisateursCreateViewModel.Pseudonyme), "Ce pseudonyme est déjà utilisé.");

            }

            if (utilisateurs.Any(u => u.Courriel == vm.Courriel && u.Id != vm.Id && vm.Courriel != null))
            {
                ModelState.AddModelError(nameof(UtilisateursCreateViewModel.Courriel), "Ce courriel est déjà utilisé.");

            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var utilisateurExistant = _context.Utilisateurs.Find(vm.Id);

            if (utilisateurExistant == null)
            {
                return NotFound();
            }

            utilisateurExistant.Prenom = vm.Prenom;
            utilisateurExistant.Nom = vm.Nom;
            utilisateurExistant.Pseudonyme = vm.Pseudonyme;
            utilisateurExistant.Courriel = vm.Courriel;
            utilisateurExistant.InfoLettre = vm.InfoLettre;

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
        public async Task<IActionResult> EditPassword(int id, [Bind("Id", "MotDePasseActuel", "MotDePasseNouveau", "MotDePasseConfirmation")] UtilisateursEditPasswordViewModel vm)
        {


            var utilisateurExistant = _context.Utilisateurs.Find(vm.Id);

            if (utilisateurExistant == null)
            {
                return NotFound();
            }

            if (utilisateurExistant.MotDePasseActuel != vm.MotDePasseActuel)
            {
                ModelState.AddModelError(nameof(UtilisateursEditPasswordViewModel.MotDePasseActuel), "Le mot de passe actuel est différent.");

            }

            if (utilisateurExistant.MotDePasseActuel == vm.MotDePasseNouveau)
            {
                ModelState.AddModelError(nameof(UtilisateursEditPasswordViewModel.MotDePasseNouveau), "Le nouveau mot de passe doit être différent.");

            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            utilisateurExistant.MotDePasseActuel = vm.MotDePasseNouveau;
            _context.Update(utilisateurExistant);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
