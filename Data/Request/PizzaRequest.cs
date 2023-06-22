namespace PIZZASG_M.Data.Request
{
    public class PizzaRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;


        public string Tamaño { get; set; } = null!;


        public decimal Precio { get; set; }
    }
}
