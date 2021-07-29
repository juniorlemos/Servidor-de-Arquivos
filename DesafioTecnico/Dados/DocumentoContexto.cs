using DesafioTecnico.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioTecnico.Data
{
    public class DocumentoContexto : DbContext
    {

        public DocumentoContexto(DbContextOptions<DocumentoContexto>options) : base(options)
        {
                
        }
        public DbSet<Documento> Documentos { get; set; }

    }
}
