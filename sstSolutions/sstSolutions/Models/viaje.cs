using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sstSolutions.Models
{
    public class viaje
    {
        [Key]
        public int viajeId { get; set; }
        [Required]
        public int horaPartida { get; set; }
        [Required]
        public int horaLlegada { get; set; }
        [Required]
        public int tiempoViaje { get; set; }
    }
}
