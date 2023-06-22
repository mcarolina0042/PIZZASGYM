using Microsoft.EntityFrameworkCore;
using PIZZASG_M.Data.Context;
using PIZZASG_M.Data.Models;
using PIZZASG_M.Data.Request;
using PIZZASG_M.Data.Response;

namespace PIZZASG_M.Data.Services
{
    public class Resu
    {
        public bool Success { get; set; }
        public string? Message { get; set; }

    }
    public class Resu<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
    public class PizzaServices
    {
        private readonly IMyDBContext dbContext;

        public PizzaServices(IMyDBContext DbContext)
        {
            dbContext = DbContext;
        }

        public async Task<Resu> Crear(PizzaRequest request)
        {
            try
            {
                var pizza = Pizza.Crear(request);
                dbContext.Pizzas.Add(pizza);
                await dbContext.SaveChangesAsync();
                return new Resu() { Message = "OK", Success = true };
            }

            catch (Exception E)
            {
                return new Resu() { Message = E.Message, Success = false };
            }
        }

        public async Task<Resu> Modificar(PizzaRequest request)
        {
            try
            {
                var pizza = await dbContext.Pizzas.FirstOrDefaultAsync(d => d.Id == request.Id);
                if (pizza == null)
                    return new Resu() { Message = "No Se Encontro El Cliente ", Success = false };

                if (pizza.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Resu() { Message = "OK", Success = true };
            }

            catch (Exception E)
            {
                return new Resu() { Message = E.Message, Success = false };
            }
        }

        public async Task<Resu> Eliminar(PizzaRequest request)
        {
            try
            {
                var pizza = await dbContext.Pizzas.FirstOrDefaultAsync(d => d.Id == request.Id);
                if (pizza == null)
                    return new Resu() { Message = "No Se Encontro La Factura ", Success = false };

                dbContext.Pizzas.Remove(pizza);
                await dbContext.SaveChangesAsync();

                return new Resu() { Message = "OK", Success = true };
            }

            catch (Exception E)
            {
                return new Resu() { Message = E.Message, Success = false };
            }
        }

        public async Task<Resu<List<PizzaResponse>>> Consultar(string filtro)
        {
            try
            {
                var pizzas = await dbContext.Pizzas
                    .Where(d =>
                        (d.Nombre + " " + d.Tamaño + " " + d.Precio)
                        .ToLower()
                        .Contains(filtro.ToLower()
                        )
                    )
                    .Select(d => d.ToResponse())
                    .ToListAsync();
                return new Resu<List<PizzaResponse>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = pizzas

                };
            }
            catch (Exception E)
            {
                return new Resu<List<PizzaResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }
    }
}
