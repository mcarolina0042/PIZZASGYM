using PIZZASG_M.Data.Request;
using PIZZASG_M.Data.Response;
using System.ComponentModel.DataAnnotations;

namespace PIZZASG_M.Data.Models
{
    public class Factura
    {
        [Key]
        public int Id { get; set; }


        public int ClienteId { get; set; }


        public string Referencia { get; set; } = null!;
        public string Extra { get; set; } = null!;
        public decimal SubTotal { get; set; }


        public decimal Descuento { get; set; }
        public decimal ITBIS { get; set; }
        public decimal Total { get; set; }

        public static Factura Crear(FacturaRequest factura)
            => new Factura()
            {
                ClienteId = factura.ClienteId,
                Referencia = factura.Referencia,
                Extra = factura.Extra,
                SubTotal = factura.SubTotal,
                ITBIS = factura.ITBIS,
                Total = factura.Total,

            };
        public bool Modificar(FacturaRequest factura)
        {
            var cambio = false;
            if (ClienteId != factura.ClienteId)
            {
                ClienteId = factura.ClienteId;
                cambio = true;
            }
            if (Referencia != factura.Referencia)
            {
                Referencia = factura.Referencia;
                cambio = true;
            }
            if (Extra != factura.Extra)
            {
                Extra = factura.Extra;
                cambio = true;
            }
            if (SubTotal != factura.SubTotal)
            {
                SubTotal = factura.SubTotal;
                cambio = true;
            }
            if (ITBIS != factura.ITBIS)
            {
                ITBIS = factura.ITBIS;
                cambio = true;
            }
            if (Total != factura.Total)
            {
                Total = factura.Total;
                cambio = true;
            }
            return cambio;

        }

            public FacturaResponse ToResponse()
            {
                return new FacturaResponse
                {
                    ClienteId = ClienteId,
                    Referencia = Referencia,
                    Extra = Extra,
                    SubTotal = SubTotal,
                    ITBIS = ITBIS,
                    Total = Total


                };
        }   }
    }
