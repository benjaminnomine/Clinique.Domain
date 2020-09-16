﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinique.Domain.Models;
using Clinique.EntityFramework;

namespace Clinique.AspNetCore.Controllers
{
    public class OrdonnancemedicamentsController : Controller
    {
        private readonly CliniqueDbContext _context;

        public OrdonnancemedicamentsController(CliniqueDbContext context)
        {
            _context = context;
        }

        // GET: Ordonnancemedicaments
        public async Task<IActionResult> Index()
        {
            var cliniqueDbContext = _context.Ordonnancemedicaments.Include(o => o.Medicament).Include(o => o.Ordonnance);
            return View(await cliniqueDbContext.ToListAsync());
        }

        // GET: Ordonnancemedicaments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordonnancemedicament = await _context.Ordonnancemedicaments
                .Include(o => o.Medicament)
                .Include(o => o.Ordonnance)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordonnancemedicament == null)
            {
                return NotFound();
            }

            return View(ordonnancemedicament);
        }

        // GET: Ordonnancemedicaments/Create
        public IActionResult Create()
        {
            ViewData["IdMedicament"] = new SelectList(_context.Medicaments, "Id", "Id");
            ViewData["IdOrdonnance"] = new SelectList(_context.Ordonnances, "Id", "Id");
            return View();
        }

        // POST: Ordonnancemedicaments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NbBoites,IdOrdonnance,IdMedicament,Id")] Ordonnancemedicament ordonnancemedicament)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordonnancemedicament);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMedicament"] = new SelectList(_context.Medicaments, "Id", "Id", ordonnancemedicament.IdMedicament);
            ViewData["IdOrdonnance"] = new SelectList(_context.Ordonnances, "Id", "Id", ordonnancemedicament.IdOrdonnance);
            return View(ordonnancemedicament);
        }

        // GET: Ordonnancemedicaments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordonnancemedicament = await _context.Ordonnancemedicaments.FindAsync(id);
            if (ordonnancemedicament == null)
            {
                return NotFound();
            }
            ViewData["IdMedicament"] = new SelectList(_context.Medicaments, "Id", "Id", ordonnancemedicament.IdMedicament);
            ViewData["IdOrdonnance"] = new SelectList(_context.Ordonnances, "Id", "Id", ordonnancemedicament.IdOrdonnance);
            return View(ordonnancemedicament);
        }

        // POST: Ordonnancemedicaments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NbBoites,IdOrdonnance,IdMedicament,Id")] Ordonnancemedicament ordonnancemedicament)
        {
            if (id != ordonnancemedicament.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordonnancemedicament);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdonnancemedicamentExists(ordonnancemedicament.Id))
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
            ViewData["IdMedicament"] = new SelectList(_context.Medicaments, "Id", "Id", ordonnancemedicament.IdMedicament);
            ViewData["IdOrdonnance"] = new SelectList(_context.Ordonnances, "Id", "Id", ordonnancemedicament.IdOrdonnance);
            return View(ordonnancemedicament);
        }

        // GET: Ordonnancemedicaments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordonnancemedicament = await _context.Ordonnancemedicaments
                .Include(o => o.Medicament)
                .Include(o => o.Ordonnance)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordonnancemedicament == null)
            {
                return NotFound();
            }

            return View(ordonnancemedicament);
        }

        // POST: Ordonnancemedicaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordonnancemedicament = await _context.Ordonnancemedicaments.FindAsync(id);
            _context.Ordonnancemedicaments.Remove(ordonnancemedicament);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdonnancemedicamentExists(int id)
        {
            return _context.Ordonnancemedicaments.Any(e => e.Id == id);
        }
    }
}