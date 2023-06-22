using Microsoft.EntityFrameworkCore;
using PIZZASG_M.Data.Context;
using PIZZASG_M.Data.Models;
using PIZZASG_M.Data.Request;
using PIZZASG_M.Data.Response;

namespace PIZZASG_M.Data.Services
{
    public class Resul
    {
        public bool Success { get; set; }
        public string? Message { get; set; }

    }
    public class Resul<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
    public class FacturaServices
    {
        private readonly IMyDBContext dbContext;

        public FacturaServices(IMyDBContext DbContext)
        {
            dbContext = DbContext;
        }

        public async Task<Resul> Crear(FacturaRequest request)
        {
            try
            {
                var factura = Factura.Crear(request);
                dbContext.Facturas.Add(factura);
                await dbContext.SaveChangesAsync();
                return new Resul() { Message = "OK", Success = true };
            }

            catch (Exception E)
            {
                return new Resul() { Message = E.Message, Success = false };
            }
        }

        public async Task<Resul> Modificar(FacturaRequest request)
        {
            try
            {
                var factura = await dbContext.Facturas.FirstOrDefaultAsync(d => d.Id == request.Id);
                if (factura == null)
                    return new Resul() { Message = "No Se Encontro El DetalleFactura ", Success = false };

                if (factura.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Resul() { Message = "OK", Success = true };
            }

            catch (Exception E)
            {
                return new Resul() { Message = E.Message, Success = false };
            }
        }


        public async Task<Resul> Eliminar(FacturaRequest request)
        {
            try
            {
                var factura = await dbContext.Facturas.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (factura == null)
                    return new Resul() { Message = "No Se Encontro La Factura ", Success = false };

                dbContext.Facturas.Remove(factura);
                await dbContext.SaveChangesAsync();

                return new Resul() { Message = "OK", Success = true };
            }

            catch (Exception E)
            {
                return new Resul() { Message = E.Message, Success = false };
            }
        }

        public async Task<Resul<List<FacturaResponse>>> Consultar(string filtro)
        {
            try
            {
                var facturas = await dbContext.Facturas
                    .Where(d =>
                        (d.ClienteId + " " + d.Referencia + " " + d.Extra + " " + d.SubTotal + "" + d.ITBIS + "" + d.Total)
                        .ToLower()
                        .Contains(filtro.ToLower()
                        )
                    )
                    .Select(d => d.ToResponse())
                    .ToListAsync();
                return new Resul<List<FacturaResponse>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = facturas
                };
            }
            catch (Exception E)
            {
                return new Resul<List<FacturaResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }
    }
}
