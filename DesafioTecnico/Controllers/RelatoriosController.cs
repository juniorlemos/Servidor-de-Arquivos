using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesafioTecnico.Data;
using DesafioTecnico.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace DesafioTecnico.Controllers
{
    public class RelatoriosController : Controller
    {
        private readonly DocumentContext _context;

        public RelatoriosController(DocumentContext context)
        {
            _context = context;
        }

        // GET: Relatorios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Documentos.OrderBy(c => c.Titulo).AsNoTracking().ToListAsync()); ;
        }

        // GET: Relatorios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documento = await _context.Documentos
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (documento == null)
            {
                return NotFound();
            }

            return View(documento);
        }

        // GET: Relatorios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Relatorios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] int codigo,string titulo ,string processo,
            string categoria,IFormFile file )
        {
           
            if (ModelState.IsValid)
            {
                

                var nome = file.FileName;
     
                var documento = new Documento()
                {
                    Codigo = codigo,
                    Titulo = titulo,
                    Processo = processo,
                    Categoria = categoria,
                    NomeArquivo = nome

                };
                              using (var target = new MemoryStream())
                {
                    file.CopyTo(target);
                    documento.Arquivo = target.ToArray();
                }
                _context.Add(documento);
                await _context.SaveChangesAsync();
                TempData["Mensagem"] = "sucesso";
                return RedirectToAction(nameof(Create));
               
            }
            TempData["Mensagem"] = "erro";
            return View();
        }

        // GET: Relatorios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documento = await _context.Documentos.FindAsync(id);
            if (documento == null)
            {
                return NotFound();
            }
            return View(documento);
        }

        // POST: Relatorios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo,Titulo,Processo,Categoria,Arquivo,NomeArquivo")] Documento documento)
        {
            if (id != documento.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentoExists(documento.Codigo))
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
            return View(documento);
        }

        // GET: Relatorios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documento = await _context.Documentos
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (documento == null)
            {
                return NotFound();
            }

            return View(documento);
        }

        // POST: Relatorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var documento = await _context.Documentos.FindAsync(id);
            _context.Documentos.Remove(documento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DownloadDocument([FromForm] int id)
        {
           
                try
                {
                

                    var myFile = await _context.Documentos.SingleOrDefaultAsync(x => x.Codigo ==id);
                    
                    if (myFile != null)
                    {
                        byte[] fileBytes = myFile.Arquivo;
                        return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, myFile.NomeArquivo);
                    }
                }
                catch
                {
                }


            return NotFound(); 
        }

        private bool DocumentoExists(int id)
        {
            return _context.Documentos.Any(e => e.Codigo == id);
        }
    }
}
