using sstSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sstSolutions.Data
{
    public class dbInitializer
    {
        public static void Initialize(sstSolutionsContext context)
        {
            context.Database.EnsureCreated();

            if (context.ciudad.Any())
            {
                return;
            }

            var ciudades = new ciudad[]
            {
                new ciudad{ciudadNombre="Bogota"},
                new ciudad{ciudadNombre="Cali"}
            };

            var viajes = new viaje[]
           {
                new viaje{horaPartida=1, horaLlegada=2,tiempoViaje=1}
           };

            foreach (ciudad c in ciudades)
            {
                context.ciudad.Add(c);
            }

            foreach (viaje v in viajes)
            {
                context.viaje.Add(v);
            }
            context.SaveChanges();
        }
    }
}
