using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obligatorioGestionReservaHotel
{
    public class loginUsuario
    {
        Menu login = new Menu();
        public List<Usuario> listaUsuario = new List<Usuario>();

        public void AgregarUsuario(Usuario usuario)
        { 
            listaUsuario.Add(usuario);
        }
        
        public void listaUsuarios()
        {
            PrecargaUser usuariosPrecargados = new PrecargaUser();
            var usuarios = usuariosPrecargados.precargaUser();
            foreach (var usuario in usuarios)
            {
                AgregarUsuario(usuario);
            }
        }


        public void loginUsuario1()
        {
            
            bool salir = false;
            while (!salir)
            {
                listaUsuarios();
                Console.Clear();
                Console.WriteLine("Hotel Estrella");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("1. Ingresar");
                Console.WriteLine("2. Registrarse.");
                Console.WriteLine("3. Recuperar contrseña.");
                Console.WriteLine("4. Salir.");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("Ingrese la opción deseada; ");

                string? entrada = Console.ReadLine();
                if (int.TryParse(entrada, out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            ingresarUsuario();
                            break;
                        case 2:
                            registrarse();
                            break;
                        case 3:
                            recuperarContrasenia();
                            break;
                        case 4:
                            salir = true;
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
        
        public void ingresarUsuario()
        {
            Console.Clear();
            listaUsuarios();
            Console.WriteLine("Ingresar Usuario");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Ingresa tu correo electronico; ");

            string? loginUser;
            do
            {
                loginUser = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(loginUser))
                {
                    Console.WriteLine("No puede estar vacía o contener espacios en blanco. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(loginUser));


            Console.Write("Ingresa tu contraseña; ");
            string? loginPassword;
            do
            {
                loginPassword = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(loginPassword))
                {
                    Console.WriteLine("No puede estar vacía o contener espacios en blanco. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(loginPassword));

            var findLogin = listaUsuario.Find(u => u.User == loginUser && u.Contrasenia == loginPassword);
            Console.WriteLine("");


            if (findLogin != null)
            {
                Console.WriteLine("Usuario y contraseña correctos.");
                System.Threading.Thread.Sleep(2000); 
                login.mostrarMenu();
            }
            {
                Console.WriteLine("El Usuario y la contraseña son  incorrectos. Vuelve a intentarlo en otro momento.");
                Console.ReadKey();
            }
        }

        public void registrarse()
        {
            Console.Clear();
            listaUsuarios();
            Console.WriteLine("¡Bienvenido a Hotel Estrella!");
            Console.WriteLine("");
            Console.WriteLine("Registrate para poder reservar.");
            Console.WriteLine("");
            string? nombre;
            do
            {
                Console.Write("Ingrese su nombre completo; ");
                nombre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    Console.WriteLine("No puede estar vacía o contener espacios en blanco. Intente de nuevo.");
                }

            } while (string.IsNullOrWhiteSpace(nombre));

            Console.WriteLine("");

            int tel;
            string? stringTel;
            do
            {
                Console.Write("Ingrese su telefono; ");
                stringTel = Console.ReadLine();
                if (!int.TryParse(stringTel, out tel))
                {
                    Console.WriteLine("Solo se permiten ingresar numeros. Intente de nuevo.");
                }

            } while (!int.TryParse(stringTel, out tel));
            Console.WriteLine("");

            string? user;
            do
            {
                Console.Write("Ingrese su Correo Eletronico; ");
                user = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(user))
                {
                    Console.WriteLine("No puede estar vacía o contener espacios en blanco. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(user));
            Console.WriteLine("");

            string? password;
            do
            {
                Console.Write("Ingrese su contraseña: ");
                password = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(password))
                {
                    Console.WriteLine("La contraseña no puede estar vacío o contener solo espacios en blanco.Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(password));
            Console.WriteLine("");

            Usuario nuevoUsuario = new Usuario(nombre, tel,user,password);
            AgregarUsuario(nuevoUsuario);

            Console.WriteLine("Te has ingresado con éxito. Presione una tecla para continuar.");
            Console.ReadKey();



        }

        public void recuperarContrasenia()
        {
            Console.Clear();
            Console.WriteLine("Recuperación de cuenta");
            Console.WriteLine("");
            Console.WriteLine("");

            string? findCorreo;
            do
            {
                Console.Write("ingresa tu correo; ");
                findCorreo = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(findCorreo))
                {
                    Console.WriteLine("No puede estar vacía o contener espacios en blanco. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(findCorreo));
            string? findTel;
            int tel;
            do
            {
                Console.Write("ingresa tu numero telefonico; ");
                findTel = Console.ReadLine();
                if (!int.TryParse(findTel, out tel))
                {
                    Console.WriteLine("No puede estar vacía o contener espacios en blanco. Intente de nuevo.");
                }
            } while (!int.TryParse(findTel, out tel));

            var findLogin = listaUsuario.Find(u => u.User == findCorreo && u.Telefono == tel);
            if (findLogin != null)
            {
                Console.WriteLine("¡Recuperación éxitosa!");
                Console.WriteLine($"Su contraseña es {findLogin.Contrasenia}, Presione una tecla para continuar.");
            }
            Console.ReadKey();
        }

    }
}
