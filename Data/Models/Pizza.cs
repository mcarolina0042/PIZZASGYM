using PIZZASG_M.Data.Request;
using PIZZASG_M.Data.Response;
using System.ComponentModel.DataAnnotations;

namespace PIZZASG_M.Data.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;


        public string Tamaño { get; set; } = null!;


        public decimal Precio { get; set; }

        public static Pizza Crear(PizzaRequest pizza)
            => new Pizza()
            {
                Nombre = pizza.Nombre,
                Tamaño = pizza.Tamaño,
                Precio = pizza.Precio,

            };
        public bool Modificar(PizzaRequest pizza)
        {
            var cambio = false;
            if (Nombre != pizza.Nombre)
            {
                Nombre = pizza.Nombre;
                cambio = true;
            }
            if (Tamaño != pizza.Tamaño)
            {
                Tamaño = pizza.Tamaño;
                cambio = true;
            }
            if (Precio != pizza.Precio)
            {
                Precio = pizza.Precio;
                cambio = true;
            }

            return cambio;

        }

        public PizzaResponse ToResponse()
        {
            return new PizzaResponse
            {
                Nombre = Nombre,
                Tamaño = Tamaño,
                Precio = Precio,


            };
        }
    }
}

