using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace obligatorioGestionReservaHotel
{
    public class PrecargaUser
    {
        
        public List<Usuario> precargaUser()
        {
            List<Usuario> precargaUsuario = new List<Usuario>();

            precargaUsuario.Add(new Usuario("Juan Pérez", 987654321, "juanp", "pass1"));
            precargaUsuario.Add(new Usuario("María García", 987654322, "mariag", "pass2"));
            precargaUsuario.Add(new Usuario("Pedro López", 987654323,  "pedrol", "pass3"));
            precargaUsuario.Add(new Usuario("Ana Martínez",  987654324, "anam", "pass4"));
            precargaUsuario.Add(new Usuario("Luis Fernández", 987654325, "luisf", "pass5"));
            precargaUsuario.Add(new Usuario("Carla Sánchez", 987654326, "carlas", "pass6"));
            precargaUsuario.Add(new Usuario("Javier Gómez",  987654327, "javierg", "pass7"));
            precargaUsuario.Add(new Usuario("Lucía Rodríguez", 987654328, "luciar", "pass8"));
            precargaUsuario.Add(new Usuario("Carlos Ramírez", 987654329,"carlosr", "pass9"));
            precargaUsuario.Add(new Usuario("Sofía Torres", 987654330,  "sofit", "pass10"));
            return precargaUsuario; 


        }
    }
}
