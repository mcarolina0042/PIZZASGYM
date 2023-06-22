using PIZZASG_M.Data.Request;
using PIZZASG_M.Data.Response;
using System.ComponentModel.DataAnnotations;

namespace PIZZASG_M.Data.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;


        public string Email { get; set; } = null!;
        public string Contraseña { get; set; } = null!;


        public string Sexo { get; set; } = null!;

        public static Usuario Crear(UsuarioRequest usuario)
          => new Usuario()
          {
              Nombre = usuario.Nombre,
              Email = usuario.Email,
              Contraseña = usuario.Contraseña,
              Sexo = usuario.Sexo,
          };
        public bool Modificar(UsuarioRequest usuario)
        {
            var cambio = false;
            if (Nombre != usuario.Nombre)
            {
                Nombre = usuario.Nombre;
                cambio = true;
            }
            if (Email != usuario.Email)
            {
                Email = usuario.Email;
                cambio = true;
            }
            if (Contraseña != usuario.Contraseña)
            {
                Contraseña = usuario.Contraseña;
                cambio = true;
            }
            if (Sexo != usuario.Sexo)
            {
                Sexo = usuario.Sexo;
                cambio = true;
            }

            return cambio;
        }

        public UsuarioResponse ToResponse()
        {
            return new UsuarioResponse
            {
                Nombre = Nombre,
                Email = Email,
                Contraseña = Contraseña,
                Sexo = Sexo,

            };
    }   }
}
