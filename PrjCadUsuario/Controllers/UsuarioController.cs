using System;
using System.IO;
using System.Net;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PrjCadUsuario.Data;
using PrjCadUsuario.Models;
using Microsoft.EntityFrameworkCore;

namespace PrjCadUsuario.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioContext _context;

        public UsuarioController(UsuarioContext context)
        {
            this._context = context;
        }

        public async Task<ActionResult> Index()
        {
            var objLst = _context.Usuarios.OrderBy(c => c.Nome).ToList();
            return View(objLst);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(string SearchString)
        {
            var objLst = _context.Usuarios.Where(c => c.Nome.Contains(SearchString == null ? c.Nome : SearchString)).OrderBy(c => c.Nome).ToList();
            return View(objLst);
        }

        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(m => m.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Security objSecurity = new Security();
                    obj.Senha = objSecurity.GeraSenhaAleatoria();

                    _context.Add(obj);

                    await _context.SaveChangesAsync();
                    TempData["MsgSucesso"] = "Registro salvo com sucesso!!";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(obj);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(m => m.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, Usuario obj)
        {
            if (id != obj.UsuarioId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obj);
                    TempData["MsgSucesso"] = "Registro atualizado com sucesso!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(m => m.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(m => m.UsuarioId == id);
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
