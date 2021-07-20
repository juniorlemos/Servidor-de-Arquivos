using DesafioTecnico.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioTecnico.Services
{
    public interface IRelatorioService
    {
        Task<List<Documento>>GetRelatorios();
        Task PostRelatorio(Documento documento, IFormFile file);
        Task <Documento>DownloadRelatorio(int id);
        bool DocumentoExiste(int id);
       
}

    }