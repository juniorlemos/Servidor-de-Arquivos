using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioTecnico.Models
{
    public class Documento
    {
        [Key]
       
        [Required(ErrorMessage = "Este campo não pode ficar em branco")]
        [RegularExpression("^[1-9][0-9]*$", ErrorMessage = "Por favor informe um número positivo")]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "Este campo não pode ficar em branco")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Este campo não pode ficar em branco")]
        public string Processo { get; set; }
        [Required(ErrorMessage = "Este campo não pode ficar em branco")]
        public string Categoria { get; set; }
        [Required (ErrorMessage = "Este campo não pode ficar em branco")]
       
        public string Arquivo { get; set; }
    }
}
