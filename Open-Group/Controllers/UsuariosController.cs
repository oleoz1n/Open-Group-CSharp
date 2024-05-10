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
    public class UsuariosController : Controller
    {
        private readonly OracleDbContext _context;

        public UsuariosController(OracleDbContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,Nome,Identificacao,Email,Telefone,Senha,DataCriacao")] Usuario usuario)
        {

            Boolean flag = false;

            if (await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == usuario.Email ) != null)
            {
                ModelState.AddModelError("Email", "Já existe um usuário com o mesmo email");
                flag = true;
            }
            if (await _context.Usuarios.FirstOrDefaultAsync(u =>  u.Identificacao == usuario.Identificacao) != null)
            {
                ModelState.AddModelError("Identificacao", "Já existe um usuário com a mesmo identificação.");
                flag = true;
            }

            // Adiciona a data de criação do usuário
            usuario.DataCriacao = DateTime.Now;

            if (ModelState.IsValid && !flag)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,Nome,Identificacao,Email,Telefone,Senha")] Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return NotFound();
            }

            Boolean flag = false;

            if (await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == usuario.Email && u.IdUsuario != usuario.IdUsuario) != null)
            {
                ModelState.AddModelError("Email", "Já existe um usuário com o mesmo email");
                flag = true;
            }

            if (await _context.Usuarios.FirstOrDefaultAsync(u => u.Identificacao == usuario.Identificacao && u.IdUsuario != usuario.IdUsuario) != null)
            {
                ModelState.AddModelError("Identificacao", "Já existe um usuário com a mesmo identificação.");
                flag = true;
            }

            if (ModelState.IsValid && !flag)
            {
                try
                {
                    _context.Update(usuario);
                    _context.Entry(usuario).Property(x => x.DataCriacao).IsModified = false;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.IdUsuario))
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
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }
    }
}
