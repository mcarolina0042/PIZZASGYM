using System.ComponentModel.DataAnnotations;

namespace PIZZASG_M.Data.Request
{
    public class ClienteRequest
    {
        
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
    }
}
