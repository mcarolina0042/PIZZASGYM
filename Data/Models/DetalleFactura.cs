using PIZZASG_M.Data.Request;
using PIZZASG_M.Data.Response;
using System.ComponentModel.DataAnnotations;

namespace PIZZASG_M.Data.Models
{
    public class DetalleFactura
    {
        [Key]
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public int PizzaId { get; set; }


        public int Cantidad { get; set; }


        public decimal Precio { get; set; }

        public static DetalleFactura Crear(DetalleFacturaRequest detalleFactura)
          => new DetalleFactura()
          {
              FacturaId = detalleFactura.FacturaId,
              PizzaId = detalleFactura.PizzaId,
              Cantidad = detalleFactura.Cantidad,
              Precio = detalleFactura.Precio,
          };
        public bool Modificar(DetalleFacturaRequest detalleFactura)
        {
            var cambio = false;
            if (FacturaId != detalleFactura.FacturaId)
            {
                FacturaId = detalleFactura.FacturaId;
                cambio = true;
            }
            if (PizzaId != detalleFactura.PizzaId)
            {
                PizzaId = detalleFactura.PizzaId;
                cambio = true;
            }
            if (Cantidad != detalleFactura.Cantidad)
            {
                Cantidad = detalleFactura.Cantidad;
                cambio = true;
            }
            if (Precio != detalleFactura.Precio)
            {
                Precio = detalleFactura.Precio;
                cambio = true;
            }
            return cambio;
        }

        public DetalleFacturaResponse ToResponse()
        {
            return new DetalleFacturaResponse
            {
                FacturaId = FacturaId,
                PizzaId = PizzaId,
                Cantidad = Cantidad,
                Precio = Precio
            };
        }
    }
}
