using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorioGestionReservaHotel
{
    public class Huesped
    {
        private static int contadorId = 0;
        public int ID { get; private set; }

        public string? Nombre { get; set; }

        public string? Documento { get; set; }
        public DateTime Fecha { get; set; }

        public int Telefono { get; set; }
        public string? Pais { get; set; }



        public Huesped(string nombre, string documento, DateTime fecha, int tel, string pais)
        {
            contadorId++;
            ID = contadorId;
            Nombre = nombre;
            Documento = documento;
            Fecha = fecha;
            Telefono = tel;
            Pais = pais;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Nombre: {Nombre}, Documento: {Documento}, Fecha de Nacimiento: {Fecha.ToShortDateString()}, Teléfono: {Telefono}, País: {Pais}";
        }

    }



}
