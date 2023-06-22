using Microsoft.EntityFrameworkCore;
using PIZZASG_M.Data.Context;
using PIZZASG_M.Data.Models;
using PIZZASG_M.Data.Request;
using PIZZASG_M.Data.Response;

namespace PIZZASG_M.Data.Services
{
    public class Results
    {
        public bool Success { get; set; }
        public string? Message { get; set; }

    }
    public class Results<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }

    public class ClienteServices
    {
        private readonly IMyDBContext dbContext;

        public ClienteServices(IMyDBContext DbContext)
        {
            dbContext = DbContext;
        }
        public async Task<Results> Crear(ClienteRequest request)
        {
            try
            {
                var cliente = Cliente.Crear(request);
                dbContext.Clientes.Add(cliente);
                await dbContext.SaveChangesAsync();
                return new Results() { Message = "OK", Success = true };
            }

            catch (Exception E)
            {
                return new Results() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result> Modificar(ClienteRequest request)
        {
            try
            {
                var cliente = await dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (cliente == null)
                    return new Result() { Message = "No Se Encontro El Cliente ", Success = false };

                if (cliente.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "OK", Success = true };
            }

            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result> Eliminar(ClienteRequest request)
        {
            try
            {
                var cliente = await dbContext.Clientes.FirstOrDefaultAsync(c => c.Id == request.Id);
                if (cliente == null)
                    return new Result() { Message = "No Se Encontro El Cliente ", Success = false };

                dbContext.Clientes.Remove(cliente);
                await dbContext.SaveChangesAsync();

                return new Result() { Message = "OK", Success = true };
            }

            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Results<List<ClienteResponse>>> Consultar(string filtro)
        {
            try
            {
                var clientes = await dbContext.Clientes
                    .Where(c =>
                        (c.Nombre)
                        .ToLower()
                        .Contains(filtro.ToLower()
                        )
                    )
                    .Select(c => c.ToResponse())
                    .ToListAsync();
                return new Results<List<ClienteResponse>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = clientes
                };
            }
            catch (Exception E)
            {
                return new Results<List<ClienteResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }

    }
}
