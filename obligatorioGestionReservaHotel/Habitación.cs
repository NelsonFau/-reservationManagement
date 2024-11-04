using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorioGestionReservaHotel
{
    public class Habitación
    {
        public int Numero { get; set; } 
        public string? TipoHabitacion { get; set; }
        public int Capacidad { get; set; }
        public decimal Tarifa { get; set; }

        public Habitación(int numero, string tipoHab, int capacidad, decimal tarifa)
        {
            Numero = numero;
            TipoHabitacion = tipoHab;
            Capacidad = capacidad;
            Tarifa = tarifa;
        }

        public override string ToString()
        {
            return $"Habitación {Numero}, {TipoHabitacion}, Capacidad: {Capacidad} personas, U$S {Tarifa}";
        }

    }
}
