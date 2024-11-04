using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorioGestionReservaHotel
{
    public class PrecargaReserva
    {
        public List<Reserva> reservas = new List<Reserva>();

        Habitación habitacio1 = new Habitación(103, "Suite", 6, 200);
        Habitación habitacio2 = new Habitación(104, "Simple", 1, 100);
        Habitación habitacio3 = new Habitación(105, "Doble", 4, 150);
        Habitación habitacio4 = new Habitación(106, "Suite", 6, 200);

        Huesped huesped1 = new Huesped("Javier Gómez", "78901234", new DateTime(2000 - 10 - 02) , 987654327, "Argentina" );
        Huesped huesped2 = new Huesped("Lucía Rodríguez", "89012345", new DateTime(1998 - 01 - 30), 987654328, "Argentina");
        Huesped huesped3 = new Huesped("Carlos Ramírez", "90123456", new DateTime(1993 - 08 - 24), 987654329, "Argentina");
        Huesped huesped4 = new Huesped("Sofía Torres", "01234567", new DateTime(1997 - 06 - 10), 987654330, "Argentina");

        public List<Reserva> PrecargaReservas()
        {
            reservas.Add(new Reserva(huesped1, habitacio1, new DateTime(2024, 10, 26), new DateTime(2024, 11, 03)));
            reservas.Add(new Reserva(huesped2, habitacio2, new DateTime(2024, 09, 29), new DateTime(2024, 10, 03)));
            reservas.Add(new Reserva(huesped3, habitacio3, new DateTime(2024, 11, 15), new DateTime(2024, 11, 20)));
            reservas.Add(new Reserva(huesped4, habitacio4, new DateTime(2024, 08, 19), new DateTime(2024, 08, 22)));
            return reservas;
        }
    }

}
