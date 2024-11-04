using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace obligatorioGestionReservaHotel
{
    public class ControlReserva
    {


        public List<Reserva> Reservas = new List<Reserva>();
        public List<Habitación> habitaciones = new List<Habitación>();
        public List<Huesped> huespedes = new List<Huesped>();

        #region concatenacionDeListas 
        public void AgregarHuesped(Huesped huesped)
        {
            huespedes.Add(huesped);
        }

        public void AgregarHabitacion(Habitación habitacion)
        {
            habitaciones.Add(habitacion);
        }

        public void UnificarHabitacion()
        {
            PrecargaHabitacion precargaHabitacion = new PrecargaHabitacion();
            var habitaciones = precargaHabitacion.PrecargaHabitaciones();
            foreach (var habitacion in habitaciones)
            {
                AgregarHabitacion(habitacion);
            }
        }

        public void AgregarReserva(Reserva reserva)
        {
            Reservas.Add(reserva);
        }
        public void unificarReserva()
        {
            PrecargaReserva precargaReserva = new PrecargaReserva();
            var reservas = precargaReserva.PrecargaReservas();
            foreach (var reserva in reservas)
            {
                AgregarReserva(reserva);
            }
        }
        #endregion

        public void FiltroDisponibilidad()
        {
            Console.Clear();
            unificarReserva();
            UnificarHabitacion();

            Console.WriteLine("Consulta de disponibilidad de habitaciones");
            Console.WriteLine("*Contamos con habitaciones para 2, 4 o 6 personas.");
            Console.WriteLine("");

            string formatoFecha = "yyyy-MM-dd";
            DateTime fechaInicio;
            DateTime fechaFinal;

            int capacidad;
            string? capacidadString;

            do
            {
                Console.Write("Ingresa la capacidad de personas: ");
                capacidadString = Console.ReadLine();
                if (!int.TryParse(capacidadString, out capacidad))
                {
                    Console.WriteLine("Numero no válido. Intente de nuevo.");
                }
            } while (!int.TryParse(capacidadString, out capacidad));

            do
            {
                Console.Write("Ingresa la fecha de inicio (YYYY-MM-DD): ");
                string? inicioString = Console.ReadLine();
                if (!DateTime.TryParseExact(inicioString, formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaInicio))
                {
                    Console.WriteLine("Fecha no válida. Intente de nuevo con el formato YYYY-MM-DD.");
                }
            } while (fechaInicio == DateTime.MinValue);

            do
            {
                Console.Write("Ingresa la fecha de finalización (YYYY-MM-DD): ");
                string? finalString = Console.ReadLine();
                if (!DateTime.TryParseExact(finalString, formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaFinal) || fechaFinal <= fechaInicio)
                {
                    Console.WriteLine("Fecha no válida. Intente de nuevo.");
                }
            } while (fechaFinal <= fechaInicio);

            Console.Clear();
            Console.WriteLine("Las habitaciones disponibles en el periodo ingresado son;");
            Console.WriteLine("");
            Console.WriteLine($"Fecha de inicio ingresada: {fechaInicio}");
            Console.WriteLine($"Fecha final ingresada: {fechaFinal}");
            Console.WriteLine("");

            if (fechaInicio >= DateTime.Now && fechaFinal > DateTime.Now)
            {
                var consultaDisponibilidad = Reservas.FindAll(reserva =>!(reserva.FechaF <= fechaInicio || reserva.FechaI >= fechaFinal));
                var habitacionesDisponibles = habitaciones.Where(habitacion => !consultaDisponibilidad.Any(reserva => reserva.Habitacion.Numero == habitacion.Numero)).ToList();

                var habitacionesCapacidad = habitacionesDisponibles.Where(habitacion => habitacion.Capacidad >= capacidad).ToList();


                if (habitacionesCapacidad.Count > 0)
                {
                    foreach (var habitacion in habitacionesCapacidad)
                    {
                        Console.WriteLine($"{habitacion.Numero}, {habitacion.TipoHabitacion}, Capacidad: {habitacion.Capacidad}");
                    }
                }
                else
                {
                    Console.WriteLine("No hay habitaciones disponibles para esas fechas.");
                }
            }
            else
            {
                Console.WriteLine("Las fechas ingresadas no pueden ser en el posterior a este dia.");
            }

            Console.ReadKey();
        }

        public void Rerservar()
        {
            Console.Clear();
            unificarReserva();
            UnificarHabitacion();

            Console.Write("Ingresa tu datos para la reserva");
            Console.WriteLine("");
            Console.WriteLine("");

            #region loginHuesped
            Console.Write("Ingresa tu Nombre Completo; ");
            string? nombre;
            do
            {
                nombre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("No puede estar vacía o contener espacios en blanco. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(nombre));

            Console.Write("Ingresa tu documento (EJ:CI-55952062); ");
            string? documento;
            do
            {
                documento = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(documento))
                {
                    Console.WriteLine("No puede estar vacía o contener espacios en blanco. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(documento));


            Console.Write("Ingresa tu numero de contacto: ");
            int telefono;
            string? numeroString;

            do
            {
                numeroString = Console.ReadLine();
                if (!int.TryParse(numeroString, out telefono))
                {
                    Console.WriteLine("Numero no válido. Intente de nuevo.");
                }
            } while (!int.TryParse(numeroString, out telefono));

            Console.Write("Ingresa tu pais de origen: ");
            string? pais;
            do
            {
                pais = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(pais))
                {
                    Console.WriteLine("No puede estar vacía o contener espacios en blanco. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(pais));

            string formatoFecha = "yyyy-MM-dd";
            DateTime fechaNacimiento;
            string? inicioString;

            do
            {
                Console.Write("Ingresa tu fecha de nacimiento (YYYY-MM-DD): ");
                inicioString = Console.ReadLine();
                if (!DateTime.TryParseExact(inicioString, formatoFecha, null, System.Globalization.DateTimeStyles.None, out fechaNacimiento))
                {
                    Console.WriteLine("Fecha no válida. Intente de nuevo con el formato YYYY-MM-DD.");
                }
            } while (!DateTime.TryParseExact(inicioString, formatoFecha, null, System.Globalization.DateTimeStyles.None, out fechaNacimiento));

            Huesped huesped = new Huesped(nombre, documento, fechaNacimiento, telefono, pais);
            AgregarHuesped(huesped);
            Console.Clear();
            #endregion

            Console.Write("REALIZAR RESERVA");
            DateTime inicioReserva;
            DateTime finalResrva;
            Console.WriteLine("");
            do
            {
                Console.Write("Ingresa la fecha de inicio de la reserva (YYYY-MM-DD): ");
                string? fechaRString = Console.ReadLine();
                if (!DateTime.TryParseExact(fechaRString, formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out inicioReserva))
                {
                    Console.WriteLine("Fecha no válida. Intente de nuevo con el formato YYYY-MM-DD.");
                }
            } while (inicioReserva == DateTime.MinValue);

            do
            {
                Console.Write("Ingresa la fecha de finalización de la reserva (YYYY-MM-DD): ");
                string? finalRString = Console.ReadLine();
                if (!DateTime.TryParseExact(finalRString, formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out finalResrva) || finalResrva <= inicioReserva)
                {
                    Console.WriteLine("Fecha no válida o la fecha final debe ser posterior a la de inicio. Intente de nuevo.");
                }
            } while (finalResrva <= inicioReserva);

            if (inicioReserva >= DateTime.Now && finalResrva > DateTime.Now)
            {

                var consultaDisponibilidad = Reservas.FindAll(reserva => reserva.FechaI < finalResrva && reserva.FechaF > inicioReserva);

                var habitacionesDisponibles = habitaciones.Where(habitacion => !consultaDisponibilidad.Any(reserva => reserva.Habitacion.Numero == habitacion.Numero)).ToList();

                #region loginHabitacion
                Console.WriteLine("");
                Console.WriteLine("Seleccione una habitación de las siguientes opciones:");
                for (int i = 0; i < habitacionesDisponibles.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {habitacionesDisponibles[i]}");
                }
                int opcionSeleccionada;
                do
                {
                    Console.Write("Ingrese el número correspondiente a la habitación que desea seleccionar: ");
                    string? opcionString = Console.ReadLine();
                    if (!int.TryParse(opcionString, out opcionSeleccionada) || opcionSeleccionada < 1 || opcionSeleccionada > habitacionesDisponibles.Count)
                    {
                        Console.WriteLine("Opción inválida. Por favor, seleccione un número de la lista.");
                    }
                } while (opcionSeleccionada < 1 || opcionSeleccionada > habitacionesDisponibles.Count);

                Habitación habitacionSeleccionada = habitacionesDisponibles[opcionSeleccionada - 1];
                Console.WriteLine("");
                Console.WriteLine($"Usted ha seleccionado la habitación: {habitacionSeleccionada}");
                Reserva reserva = new Reserva(huesped, habitacionSeleccionada, inicioReserva, finalResrva);
                #endregion
                gestionarPagos(reserva);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Las fechas ingresadas no pueden ser en el posterior a este dia. Intente nuevamente.");
            }
            Console.ReadKey();
        }

        public void modificarReserva()
        {
            UnificarHabitacion();
            unificarReserva();
            Console.Clear();
            Console.WriteLine("Modificar Reserva");
            Console.WriteLine("");
            Console.WriteLine("");

            DateTime inicioReserva;
            DateTime finalResrva;
            string formatoFecha = "yyyy-MM-dd";

            do
            {
                Console.Write("Ingresa la fecha de inicio de la reserva que quieres modificar (YYYY-MM-DD): ");
                string? fechaRString = Console.ReadLine();
                if (!DateTime.TryParseExact(fechaRString, formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out inicioReserva))
                {
                    Console.WriteLine("Fecha no válida. Intente de nuevo con el formato YYYY-MM-DD.");
                }
            } while (inicioReserva == DateTime.MinValue);

            do
            {
                Console.Write("Ingresa la fecha finalización de la reserva que quieres modificar (YYYY-MM-DD): ");
                string? finalRString = Console.ReadLine();
                if (!DateTime.TryParseExact(finalRString, formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out finalResrva) || finalResrva <= inicioReserva)
                {
                    Console.WriteLine("Fecha no válida o la fecha final debe ser posterior a la de inicio. Intente de nuevo.");
                }
            } while (finalResrva <= inicioReserva);

            var consultaReserva = Reservas.FindAll(reserva => reserva.FechaI == inicioReserva && reserva.FechaF == finalResrva);

            if (consultaReserva.Count > 0)
            {
                    Console.WriteLine("Seleccione una reserva de las siguientes opciones:");
                    for (int i = 0; i < consultaReserva.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {consultaReserva[i]}");
                    }
                    int opcionSeleccionada;
                    do
                    {
                        Console.Write("Ingrese el número correspondiente a la reserva que desea seleccionar: ");
                        string? opcionString = Console.ReadLine();
                        if (!int.TryParse(opcionString, out opcionSeleccionada) || opcionSeleccionada < 1 || opcionSeleccionada > consultaReserva.Count)
                        {
                            Console.WriteLine("Opción inválida. Por favor, seleccione un número de la lista.");
                        }
                    } while (opcionSeleccionada < 1 || opcionSeleccionada > consultaReserva.Count);


                Reserva reservaSeleccionada = consultaReserva[opcionSeleccionada - 1];
            
                Console.Clear();

                Console.WriteLine("Modifique los detalles de la reserva:");

                DateTime nuevaFechaInicio;
                do
                {
                    Console.Write("Ingresa la nueva fecha de inicio (YYYY-MM-DD): ");
                    string? nuevaFechaInicioString = Console.ReadLine();
                    if (!DateTime.TryParseExact(nuevaFechaInicioString, formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out nuevaFechaInicio))
                    {
                        Console.WriteLine("Fecha no válida. Intente de nuevo con el formato YYYY-MM-DD.");
                    }
                } while (nuevaFechaInicio == DateTime.MinValue);

                DateTime nuevaFechaFinal;
                do
                {
                    Console.Write("Ingresa la nueva fecha de finalización (YYYY-MM-DD): ");
                    string? nuevaFechaFinalString = Console.ReadLine();
                    if (!DateTime.TryParseExact(nuevaFechaFinalString, formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out nuevaFechaFinal) || nuevaFechaFinal <= nuevaFechaInicio)
                    {
                        Console.WriteLine("Fecha no válida o la fecha final debe ser posterior a la de inicio. Intente de nuevo.");
                    }
                } while (nuevaFechaFinal <= nuevaFechaInicio);

                reservaSeleccionada.FechaI = nuevaFechaInicio;
                reservaSeleccionada.FechaF = nuevaFechaFinal;


                var consultaDisponibilidad = Reservas.FindAll(reserva => reserva.FechaI < nuevaFechaFinal && reserva.FechaF > nuevaFechaInicio);

                var habitacionesDisponibles = habitaciones.Where(habitacion => !consultaDisponibilidad.Any(reserva => reserva.Habitacion.Numero == habitacion.Numero)).ToList();

                Console.WriteLine("¿Desea cambiar la habitación? (s/n)");
                string? cambiarHabitacion = Console.ReadLine();
                if (cambiarHabitacion?.ToLower() == "s")
                {
                    Console.WriteLine("Seleccione una nueva habitación de las siguientes opciones:");
                    for (int i = 0; i < habitacionesDisponibles.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {habitacionesDisponibles[i]}");
                    }

                    int nuevaHabitacionSeleccionada;
                    do
                    {
                        Console.Write("Ingrese el número correspondiente a la nueva habitación: ");
                        string? opcionNuevaHabitacion = Console.ReadLine();
                        if (!int.TryParse(opcionNuevaHabitacion, out nuevaHabitacionSeleccionada) || nuevaHabitacionSeleccionada < 1 || nuevaHabitacionSeleccionada > habitaciones.Count)
                        {
                            Console.WriteLine("Opción inválida. Por favor, seleccione un número de la lista.");
                        }
                    } while (nuevaHabitacionSeleccionada < 1 || nuevaHabitacionSeleccionada > habitaciones.Count);

                    Habitación nuevaHabitacion = habitaciones[nuevaHabitacionSeleccionada - 1];
                    reservaSeleccionada.Habitacion = nuevaHabitacion;
                }

                Console.WriteLine("Reserva modificada con éxito.");

            }
            else
            {
                Console.WriteLine("No hay reservas con esa fecha ingresada.");
            }


            Console.ReadKey();





        }

        public void cancelarReservas()
        {

            UnificarHabitacion();
            unificarReserva();
            Console.Clear();
            Console.WriteLine("Cancelar reserva");
            Console.WriteLine("");
            Console.WriteLine("");

            DateTime inicioReserva;
            DateTime finalResrva;
            string formatoFecha = "yyyy-MM-dd";

            string? nombre;
            do
            {
                Console.Write("Ingresa tu nombre para cancelar la reserva; ");
                nombre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("El dato ingresado no puede estar vacio. Intente nuevamuente.");

                }
                else if (!nombre.Split(' ').All(palabra => char.IsUpper(palabra[0])))
                {
                    Console.WriteLine("Cada palabra debe comenzar con una letra mayúscula. Intente nuevamente.");
                }
                else
                {
                    break;
                }
            } while (true);
            do
            {
                Console.Write("Ingresa la fecha de inicio de la reserva que quieres cancelar (YYYY-MM-DD): ");
                string? fechaRString = Console.ReadLine();
                if (!DateTime.TryParseExact(fechaRString, formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out inicioReserva))
                {
                    Console.WriteLine("Fecha no válida. Intente de nuevo con el formato YYYY-MM-DD.");
                }
                else if (inicioReserva.Date == DateTime.Today)
                {
                    Console.WriteLine("No puedes cancelar la reserva el mismo día.");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    break;
                }
            } while (inicioReserva == DateTime.MinValue);

            do
            {
                Console.Write("Ingresa la fecha finalización de la reserva que quieres cancelar (YYYY-MM-DD): ");
                string? finalRString = Console.ReadLine();
                if (!DateTime.TryParseExact(finalRString, formatoFecha, CultureInfo.InvariantCulture, DateTimeStyles.None, out finalResrva) || finalResrva <= inicioReserva)
                {
                    Console.WriteLine("Fecha no válida o la fecha final debe ser posterior a la de inicio. Intente de nuevo.");
                }
            } while (finalResrva <= inicioReserva);


            var consultaReserva = Reservas.FindAll(reserva => reserva.Huesped.Nombre == nombre && reserva.FechaI == inicioReserva && reserva.FechaF == finalResrva);
            Console.WriteLine("");


            if (consultaReserva.Count > 0)
            {
                Console.WriteLine("Seleccione una reserva de las siguientes opciones:");
                for (int i = 0; i < consultaReserva.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {consultaReserva[i]}");
                }
                Console.WriteLine("");
                int opcionSeleccionada;
                do
                {
                    Console.Write("Ingrese el número correspondiente a la reserva que desea seleccionar: ");
                    string? opcionString = Console.ReadLine();
                    if (!int.TryParse(opcionString, out opcionSeleccionada) || opcionSeleccionada < 1 || opcionSeleccionada > consultaReserva.Count)
                    {
                        Console.WriteLine("Opción inválida. Por favor, seleccione un número de la lista.");
                    }
                } while (opcionSeleccionada < 1 || opcionSeleccionada > consultaReserva.Count);

                Reserva reservaSeleccionada = consultaReserva[opcionSeleccionada - 1];
                Reservas.Remove(reservaSeleccionada);

                Console.WriteLine("");
                Console.WriteLine("Reserva cancelada con éxito.");
                Console.WriteLine("");

                if (Reservas.Count > 0)
                {
                    Console.WriteLine("Comprobacion de que la reserva se eliminó:");
                    Console.WriteLine("");
                    foreach (var reserva in Reservas)
                    {
                        Console.WriteLine($"{reserva.Huesped.Nombre} - {reserva.FechaI:yyyy-MM-dd} - {reserva.FechaF:yyyy-MM-dd}, Habitación: {reserva.Habitacion}");
                    }
                }
                else
                {
                    Console.WriteLine("No hay más reservas activas para este huésped.");
                }
            }
            else
            {
                Console.WriteLine("El nombre ingresado no tiene una reservas activas en el periodo ingresado.");
            }
            Console.ReadKey();

        }

        public void gestionarPagos(Reserva reserva)
        {
            Console.Clear();
            Console.WriteLine("REALIZAR PAGO");
            Console.WriteLine("");

            decimal montoTotal = calcularMontoTotal(reserva);
            Console.WriteLine($"El monto total a pagar es: $ {montoTotal}");

            Console.Write("¿Desea confirmar el pago? (S/N): ");
            string? respuesta = Console.ReadLine();

            if (respuesta?.ToUpper() == "S")
            {
                Console.WriteLine("Por favor, ingrese los datos de su tarjeta para confirmar el pago.");

                Console.Write("Número de tarjeta (16 dígitos): ");
                string? numeroTarjeta = Console.ReadLine();

                Console.Write("Fecha de vencimiento (MM/AA): ");
                string? fechaVencimiento = Console.ReadLine();

                Console.Write("Código de seguridad (CVV): ");
                string? codigoSeguridad = Console.ReadLine();

                bool datosValidos = ValidarDatosTarjeta(numeroTarjeta, fechaVencimiento, codigoSeguridad);
                if (datosValidos)
                {
                    System.Threading.Thread.Sleep(2000);
                    reserva.Pago = true;
                    AgregarReserva(reserva);
                    Console.WriteLine("Pago realizado con éxito. Reserva confirmada, seleccione enter para emitir su factura.");
                    Console.ReadKey();
                    EmitirFactura(reserva, montoTotal);
                }
                else
                {
                    Console.WriteLine("Datos de tarjeta inválidos. La reserva no se ha confirmado.");
                }
            }
            else
            {
                Console.WriteLine("Pago cancelado. La reserva no se ha confirmado.");
            }
            Console.ReadKey();
        }

        private decimal calcularMontoTotal(Reserva reserva)
        {
            int numeroDeNoches = (reserva.FechaF - reserva.FechaI).Days;
            return reserva.Habitacion.Tarifa * numeroDeNoches;
        }

        bool ValidarDatosTarjeta(string numero, string vencimiento, string cvv)
        {
            if (numero.Length != 16 || !numero.All(char.IsDigit))
            {
                Console.WriteLine("Número de tarjeta inválido.");
                return false;
            }

            if (!DateTime.TryParseExact(vencimiento, "MM/yy", null, System.Globalization.DateTimeStyles.None, out DateTime fechaExp))
            {
                Console.WriteLine("Fecha de vencimiento inválida.");
                return false;
            }

            if (cvv.Length != 3 || !cvv.All(char.IsDigit))
            {
                Console.WriteLine("Código de seguridad inválido.");
                return false;
            }

            return true;
        }

        private void EmitirFactura(Reserva reserva, decimal montoTotal)
        {
            Console.Clear();
            Console.WriteLine("FACTURA");
            Console.WriteLine("==================================");
            Console.WriteLine($"Número de Reserva: {reserva.ID}");
            Console.WriteLine($"Nombre del Cliente: {reserva.Huesped.Nombre}");
            Console.WriteLine($"Fecha de la Reserva: {reserva.FechaI:dd/MM/yyyy} - {reserva.FechaF:dd/MM/yyyy}");
            Console.WriteLine($"Habitación: {reserva.Habitacion.Numero}");
            Console.WriteLine($"Tarifa por noche: $ {reserva.Habitacion.Tarifa}");
            Console.WriteLine($"Número de noches: {(reserva.FechaF - reserva.FechaI).Days}");
            Console.WriteLine($"Monto Total: $ {montoTotal}");
            Console.WriteLine("==================================");
            Console.WriteLine("Gracias por su pago. ¡Que tenga una excelente estadía!");
        }
    }
}