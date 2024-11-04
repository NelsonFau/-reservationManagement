using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorioGestionReservaHotel
{
    public class Menu
    {

        PrecargaUser probando = new PrecargaUser();
        List<Reserva> reservas = new List<Reserva>();
        ControlReserva controlResrevas = new ControlReserva();
       

        

        public void mostrarMenu()
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("¡Bienvenido a Hotel Estrella!");
                Console.WriteLine("");
                Console.WriteLine("1. Reservar.");
                Console.WriteLine("2. Estadisticas y reportes.");
                Console.WriteLine("3. Salir.");
                Console.WriteLine("");
                Console.Write("Ingrese la opción deseada; ");

                string? entrada = Console.ReadLine();
                if (int.TryParse(entrada, out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            reservar();
                            break;
                        case 2:
                            //recuperarCuenta();
                            break;                      
                        case 3:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Presione una tecla para continuar.");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número válido. Presione una tecla para continuar.");
                    Console.ReadKey();
                }
            }
        }
        public void reservar()
        {
            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("RESERVA TU HABITACIÓN");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("1. Habitaciones y disponibilidad");
                Console.WriteLine("2. Realizar reserva");
                Console.WriteLine("3. Modificar reserva");
                Console.WriteLine("4. Cancelar reserva");
                Console.WriteLine("5. Atras");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("Ingrese la opción deseada; ");

                string? opcionParse;
                int opcion;

                opcionParse = Console.ReadLine();
                
                if(!int.TryParse(opcionParse, out opcion))
                {
                    Console.WriteLine("Por favor, ingrese un número válido. Presione una tecla para continuar.");
                    Console.ReadKey();
                }
                else
                {
                    switch (opcion)
                    {
                        case 1:
                            controlResrevas.FiltroDisponibilidad();
                            break;
                        case 2:
                            controlResrevas.Rerservar();
                            break;
                        case 3:
                            controlResrevas.modificarReserva();
                            break;
                        case 4:
                            controlResrevas.cancelarReservas();
                            break;
                        case 5:
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Opción ingresada es incorrecta, vuelve a intentarlo.");
                            Console.ReadKey();  
                            break;

                    }
                }

            }
        }

        
    }
}
