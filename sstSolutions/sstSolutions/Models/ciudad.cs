using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sstSolutions.Models
{
    public class ciudad
    {
        [Key]
        public int ciudadId { get; set; }
        public DateTimeOffset ciudadUTC { get; set; }
        [Required]
        [StringLength(50,MinimumLength = 5,ErrorMessage = "La descripcion debe ser minimo de 5 caracteres")]
        public string ciudadNombre { get; set; }
    }
}
