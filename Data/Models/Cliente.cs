using PIZZASG_M.Data.Request;
using PIZZASG_M.Data.Response;
using System.ComponentModel.DataAnnotations;

namespace PIZZASG_M.Data.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public static Cliente Crear(ClienteRequest cliente)
          => new Cliente()
          {
              Nombre = cliente.Nombre,
          };
        public bool Modificar(ClienteRequest cliente)
        {
            var cambio = false;
            if (Nombre != cliente.Nombre)
            {
                Nombre = cliente.Nombre;
                cambio = true;
            }
            return cambio;
        }

        public ClienteResponse ToResponse()
        {
            return new ClienteResponse
            {
                Nombre = Nombre,
            };





} 
    }   }

