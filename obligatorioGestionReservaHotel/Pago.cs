using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorioGestionReservaHotel
{
    public class Pago
    {
        public readonly int Contador = 0;
        public int ID { get; private set; }

        public Reserva? IdReserva { get; private set; }

        public DateTime FechaPago { get; private set; }

        public decimal Monto { get; set; }

        public string? MetodosP { get; set; }



    }
}
