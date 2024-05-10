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
    public class ArquivosController : Controller
    {
        private readonly OracleDbContext _context;

        public ArquivosController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: Arquivos
        public async Task<IActionResult> Index()
        {
            var oracleDbContext = _context.Arquivos.Include(a => a.DadosCliente);
            return View(await oracleDbContext.ToListAsync());
        }

        // GET: Arquivos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arquivo = await _context.Arquivos
                .Include(a => a.DadosCliente)
                .FirstOrDefaultAsync(m => m.IdArquivo == id);
            if (arquivo == null)
            {
                return NotFound();
            }

            return View(arquivo);
        }

        // GET: Arquivos/Create
        public IActionResult Create()
        {
            ViewData["DadosClienteId"] = new SelectList(_context.DadosClientes, "IdDados", "IdDados");
            return View();
        }

        // POST: Arquivos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdArquivo,Nome,Tipo,Tamanho,DataUpload,Link,PalavraChave,Resumo,DadosClienteId")] Arquivo arquivo)
        {
            // Adiciona a data de upload do arquivo
            arquivo.DataUpload = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(arquivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DadosClienteId"] = new SelectList(_context.DadosClientes, "IdDados", "IdDados", arquivo.DadosClienteId);
            return View(arquivo);
        }

        // GET: Arquivos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arquivo = await _context.Arquivos.FindAsync(id);
            if (arquivo == null)
            {
                return NotFound();
            }
            ViewData["DadosClienteId"] = new SelectList(_context.DadosClientes, "IdDados", "IdDados", arquivo.DadosClienteId);
            return View(arquivo);
        }

        // POST: Arquivos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdArquivo,Nome,Tipo,Tamanho,DataUpload,Link,PalavraChave,Resumo,DadosClienteId")] Arquivo arquivo)
        {
            if (id != arquivo.IdArquivo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arquivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArquivoExists(arquivo.IdArquivo))
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
            ViewData["DadosClienteId"] = new SelectList(_context.DadosClientes, "IdDados", "IdDados", arquivo.DadosClienteId);
            return View(arquivo);
        }

        // GET: Arquivos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arquivo = await _context.Arquivos
                .Include(a => a.DadosCliente)
                .FirstOrDefaultAsync(m => m.IdArquivo == id);
            if (arquivo == null)
            {
                return NotFound();
            }

            return View(arquivo);
        }

        // POST: Arquivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arquivo = await _context.Arquivos.FindAsync(id);
            if (arquivo != null)
            {
                _context.Arquivos.Remove(arquivo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArquivoExists(int id)
        {
            return _context.Arquivos.Any(e => e.IdArquivo == id);
        }
    }
}
