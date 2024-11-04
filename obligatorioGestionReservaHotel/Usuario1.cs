using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace obligatorioGestionReservaHotel
{
    public class Usuario
    {

        private static int contadorId = 0;
        public  int ID { get; private set; }

        public string? Nombre { get; set; }

        public int Telefono { get; set; }

        public string? User { get; set; }

        public string? Contrasenia { get; set; }




        public Usuario(string nombre, int telefono, string user, string password)
        {
            contadorId++;
            ID = contadorId;
            Nombre = nombre;
            Telefono = telefono;
            User = user;
            Contrasenia = password;
        }
    }
}
