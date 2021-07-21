using DesafioTecnico.Models;
using DesafioTecnico.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DesafioTecnico.Controllers
{
    public class RelatoriosController : Controller
    {

        private readonly IRelatorioService _service;

        public RelatoriosController(IRelatorioService service)
        {
            _service = service;
        }

        // GET: Relatorios
        public async Task<IActionResult> Index()
        {

            var documentos = await _service.GetRelatorios();
            return View(documentos); ;

        }


        // GET: Relatorios/Cadastro
        public IActionResult Cadastro()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        
              public async Task<IActionResult> Cadastro([FromForm][Bind("Codigo,Titulo,Processo,Categoria")]Documento documento, IFormFile file)
        {

            if (ModelState.IsValid)
            {               

                documento.NomeArquivo = file.FileName; ;
                if (!DocumentoExists(documento.Codigo))
                {
                    await _service.PostRelatorio(documento, file);
                    TempData["Mensagem"] = "sucesso";
                    return RedirectToAction(nameof(Cadastro));                  
                }
                else
                {
                    TempData["Mensagem"] = "erroCodigo";
                    return View();

                }


            }
            TempData["Mensagem"] = "erro";
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> DownloadDocument([FromForm] int id)
        {

            var documento = await _service.DownloadRelatorio(id);


            if (documento != null)
            {
                byte[] fileBytes = documento.Arquivo;
                return File(fileBytes, Application.Octet, documento.NomeArquivo);
            }

            return NotFound();
        }


        private bool DocumentoExists(int id)
        {
            return _service.DocumentoExiste(id);
        }
    }
}
