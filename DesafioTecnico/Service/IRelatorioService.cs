using DesafioTecnico.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioTecnico.Services
{
    public interface IRelatorioService
    {
        Task<List<Documento>> ObterTodosDocumentos();
        Task InserirDocumento(Documento documento, IFormFile file);
        Task <Documento> ObterDocumento(int id);
        bool DocumentoExiste(int id);
       
}

    }