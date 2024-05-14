using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Open_Group.Models;
using Open_Group.Persistencia;

namespace Open_Group.Controllers
{
    public class InsightsController : Controller
    {
        private readonly OracleDbContext _context;

        public InsightsController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: Insights
        public async Task<IActionResult> Index()
        {
            var oracleDbContext = _context.Insights.Include(i => i.DadosCliente);
            return View(await oracleDbContext.ToListAsync());
        }

        // GET: Insights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insight = await _context.Insights
                .Include(i => i.DadosCliente)
                .FirstOrDefaultAsync(m => m.IdInsight == id);
            if (insight == null)
            {
                return NotFound();
            }

            return View(insight);
        }

        // POST: Insights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdInsight,DataGeracao,Detalhes,Recomendacao,Impacto,DadosClienteId")] Insight insight)
        {

            insight.DataGeracao = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(insight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DadosClienteId"] = new SelectList(_context.DadosClientes, "IdDados", "IdDados", insight.DadosClienteId);
            return View(insight);
        }

        // POST: Insights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("IdInsight,DataGeracao,Detalhes,Recomendacao,Impacto,DadosClienteId")] Insight insight)
        {
            if (id != insight.IdInsight)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsightExists(insight.IdInsight))
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
            ViewData["DadosClienteId"] = new SelectList(_context.DadosClientes, "IdDados", "IdDados", insight.DadosClienteId);
            return View(insight);
        }

        // GET: Insights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insight = await _context.Insights
                .Include(i => i.DadosCliente)
                .FirstOrDefaultAsync(m => m.IdInsight == id);
            if (insight == null)
            {
                return NotFound();
            }

            return View(insight);
        }

        // POST: Insights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insight = await _context.Insights.FindAsync(id);
            if (insight != null)
            {
                _context.Insights.Remove(insight);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsightExists(int id)
        {
            return _context.Insights.Any(e => e.IdInsight == id);
        }
    }
}
