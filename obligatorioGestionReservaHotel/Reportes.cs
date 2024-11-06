using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorioGestionReservaHotel
{
    public class Reportes
    {
        private ControlReserva _controlReserva;

        public Reportes(ControlReserva controlReserva)
        {
            _controlReserva = controlReserva;
        }

        public void MostrarHistorialReservas()
        {
            Console.Clear(); 
            Console.Write("Ingrese el documento del huésped para ver su historial de reservas: ");
            string? documento = Console.ReadLine();

            var reservasDelHuesped = ObtenerReservasPorHuesped(documento);

            if (reservasDelHuesped.Any())
            {
                Console.WriteLine($"Historial de reservas para el huésped con documento {documento}:");
                foreach (var reserva in reservasDelHuesped)
                {
                    Console.WriteLine($"Fecha de inicio: {reserva.FechaI.ToShortDateString()}, Fecha de fin: {reserva.FechaF.ToShortDateString()}, Habitación: {reserva.Habitacion.Numero}");
                }
            }
            else
            {
                Console.WriteLine("No se encontraron reservas para este huésped.");
            }

            Console.ReadKey();
        }

        private List<Reserva> ObtenerReservasPorHuesped(string documento)
        {
            return _controlReserva.Reservas.Where(r => r.Huesped.Documento == documento).ToList();
        }

        public List<Habitación> ObtenerHabitaciones()
        {
            return _controlReserva.habitaciones;
        }

        public List<Huesped> ObtenerHuespedes()
        {
            return _controlReserva.huespedes;
        }

        public void listarHuesped()
        {
            Console.Clear();
            Console.WriteLine("Lista de huéspedes (ordenada alfabéticamente):");
            Console.WriteLine("");

            var huespedesOrdenados = ObtenerHuespedes().OrderBy(h => h.Nombre);

            foreach (var huesped in huespedesOrdenados)
            {
                Console.WriteLine(huesped);
            }

            Console.ReadKey();
        }

        public void ListarHabitacionesLibres()
        {
            Console.Clear();
            Console.WriteLine("Habitaciones libres hoy:");
            Console.WriteLine("");

            var habitacionesLibres = _controlReserva.ObtenerHabitacionesLibres();

            foreach (var habitacion in habitacionesLibres)
            {
                Console.WriteLine($"Número: {habitacion.Numero}, Tipo: {habitacion.TipoHabitacion}, Capacidad: {habitacion.Capacidad}, Precio: {habitacion.Tarifa}");
            }

            Console.ReadKey();
        }

        public void MostrarHabitacionesConMasReservas()
        {
            Console.Clear();
            Console.WriteLine("Habitaciones con mayor número de reservas:");

            var reservasPorHabitacion = _controlReserva.Reservas.GroupBy(r => r.Habitacion.Numero).Select(g => new
            {
                NumeroHabitacion = g.Key,
                TotalReservas = g.Count() 
            }).OrderByDescending(h => h.TotalReservas); 

            if (reservasPorHabitacion.Any())
            {
                foreach (var item in reservasPorHabitacion)
                {
                    Console.WriteLine($"Número de Habitación: {item.NumeroHabitacion}, Total Reservas: {item.TotalReservas}");
                }
            }
            else
            {
                Console.WriteLine("No hay reservas disponibles.");
            }

            Console.ReadKey();
        }
    }
}