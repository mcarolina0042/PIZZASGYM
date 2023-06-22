namespace PIZZASG_M.Data.Response
{
    public class DetalleFacturaResponse
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public int PizzaId { get; set; }


        public int Cantidad { get; set; }


        public decimal Precio { get; set; }
    }
}
