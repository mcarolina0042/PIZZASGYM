namespace PIZZASG_M.Data.Response
{
    public class PizzaResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;


        public string Tamaño { get; set; } = null!;


        public decimal Precio { get; set; }
    }
}
