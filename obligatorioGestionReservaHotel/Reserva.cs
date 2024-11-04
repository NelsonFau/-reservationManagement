    using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorioGestionReservaHotel
{
    public class Reserva
    {
        public readonly int Contador = 0;
        public int ID { get; private set; }
        public Habitación Habitacion { get; set; }


        public Huesped Huesped { get; set; }

        public DateTime FechaI { get; set; }

        public DateTime FechaF { get; set; }
        public DateTime FechaR { get; private set; }
        public bool Pago { get; set; } 

        public Reserva(Huesped huesped, Habitación habitacion, DateTime fechaI,DateTime fechaF)
        {
            Contador++;
            ID = Contador;
            FechaR = DateTime.Now;
            Habitacion = habitacion; 
            Huesped = huesped;
            FechaI = fechaI;
            FechaF = fechaF;
            Pago = false;
        }

        public override string ToString()
        {
            return $"Reservas; habitación {Habitacion.Numero}, huesped {Huesped.Nombre}, inicio de reserva; {FechaI}, finalización de reserva; {FechaF}, fecha de reserva; {FechaR}";
        }
    }
}
