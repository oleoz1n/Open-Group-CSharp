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
    public class DadosClientesController : Controller
    {
        private readonly OracleDbContext _context;

        public DadosClientesController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: DadosClientes
        public async Task<IActionResult> Index()
        {
            var oracleDbContext = _context.DadosClientes.Include(d => d.Usuario);
            return View(await oracleDbContext.ToListAsync());
        }

        // GET: DadosClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosCliente = await _context.DadosClientes
                .Include(d => d.Usuario)
                .FirstOrDefaultAsync(m => m.IdDados == id);
            if (dadosCliente == null)
            {
                return NotFound();
            }

            return View(dadosCliente);
        }

        // POST: DadosClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDados,Segmento,Localizacao,TempoAtuacao,NumFuncionarios,FaturamentoAnual,CanalVenda,ProdutoServico,Tipo,Porte,Concorrente,Desafio,Objetivo,UsuarioId")] DadosCliente dadosCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dadosCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "IdUsuario", "Email", dadosCliente.UsuarioId);
            return View(dadosCliente);
        }

        // POST: DadosClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDados,Segmento,Localizacao,TempoAtuacao,NumFuncionarios,FaturamentoAnual,CanalVenda,ProdutoServico,Tipo,Porte,Concorrente,Desafio,Objetivo,UsuarioId")] DadosCliente dadosCliente)
        {
            if (id != dadosCliente.IdDados)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dadosCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DadosClienteExists(dadosCliente.IdDados))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "IdUsuario", "Email", dadosCliente.UsuarioId);
            return View(dadosCliente);
        }

        // GET: DadosClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadosCliente = await _context.DadosClientes
                .Include(d => d.Usuario)
                .FirstOrDefaultAsync(m => m.IdDados == id);
            if (dadosCliente == null)
            {
                return NotFound();
            }

            return View(dadosCliente);
        }

        // POST: DadosClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dadosCliente = await _context.DadosClientes.FindAsync(id);
            if (dadosCliente != null)
            {
                _context.DadosClientes.Remove(dadosCliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DadosClienteExists(int id)
        {
            return _context.DadosClientes.Any(e => e.IdDados == id);
        }
    }
}
