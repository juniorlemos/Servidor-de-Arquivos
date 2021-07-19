using DesafioTecnico.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTecnico.Services
{
   public interface IRelatorioService
    {
        Task<List<Documento>>GetRelatorios();
        Task PostRelatorio(Documento documento, IFormFile file);
        Task <Documento>DownloadRelatorio(int id);
       
}

    }