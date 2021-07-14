using DesafioTecnico.Data;
using DesafioTecnico.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTecnico.Controllers
{
    public class DemoController : Controller
    {
        private readonly DocumentContext _context;
        public DemoController(DocumentContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View( );
        }

        public IActionResult formulario()
        {
            return View();
        }
        public IActionResult Teste()
        {
            return View();
        }

        public IActionResult Postando()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Postando(IFormFile files)
        {
          
            if (files != null)
            {
                if (files.Length > 0)
                {
                    var nome = files.FileName;
                    var caminho = Path.GetExtension(nome);
                    var objfiles = new Documento()
                    {
                        Codigo = 157,
                        Titulo = "Livro da teste",
                        Processo = caminho,
                        Categoria = "Categoria",                      
                        NomeArquivo=nome
                        
                        
                    };

                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        objfiles.Arquivo = target.ToArray();
                    }

                    _context.Documentos.Add(objfiles);
                    _context.SaveChanges();
                   
                }
            }

           
            return View();
            
        }

        [HttpPost]
        public async Task<IActionResult> BaixardAsync()
        {
            var id = 99;


            var myInv = await _context.Documentos.FirstOrDefaultAsync(x => x.Codigo == id);

            if (myInv == null)
            {
                return NotFound();
            }

            if (myInv.Arquivo == null)
            {
                return NoContent();
            }
            else {
                byte[] byteArr = myInv.Arquivo;
                string mimeType = "aplication/pdf";
                return new FileContentResult(byteArr, mimeType) {

                    FileDownloadName = $"Documento.Titulo {myInv.Titulo}.pdf"
                };
            
            
            }
        }
       
        [HttpPost]
        public FileResult DownloadDocument()
        {
            string id = "99";
            if (!string.IsNullOrEmpty(id))
            {
                try
                {
                    var fileId = 22;

                    var myFile = _context.Documentos.SingleOrDefault(x => x.Codigo == fileId);

                    if (myFile != null)
                    {
                        byte[] fileBytes = myFile.Arquivo;
                        return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, myFile.NomeArquivo);
                    }
                }
                catch
                {
                }
            }

            return null;
        }
      

    }
}
