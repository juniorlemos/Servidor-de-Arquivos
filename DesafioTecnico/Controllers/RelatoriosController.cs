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
        public async Task<IActionResult> TabelaDocumentos()
        {

            var documentos = await _service.ObterTodosDocumentos();
            return View(documentos); ;

        }


        // GET: Relatorios/Cadastro
        public IActionResult Cadastro()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        
              public async Task<IActionResult> Cadastro([FromForm][Bind("Codigo,Titulo,Processo,Categoria")]Documento documento, IFormFile arquivo)
        {

            if (ModelState.IsValid)
            {               

                documento.NomeArquivo = arquivo.FileName; 

                if (!ConferirDocumento(documento.Codigo))
                {
                    await _service.InserirDocumento(documento, arquivo);
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
        public async Task<IActionResult> BaixarDocumento([FromForm] int id)
        {

            var documento = await _service.ObterDocumento(id);


            if (documento != null)
            {
                byte[] fileBytes = documento.Arquivo;
                return File(fileBytes, Application.Octet, documento.NomeArquivo);
            }

            return NotFound();
        }


        private bool ConferirDocumento(int id)
        {
            return _service.DocumentoExiste(id);
        }
    }
}
