namespace PIZZASG_M.Data.Request
{
    public class DetalleFacturaRequest
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public int PizzaId { get; set; }


        public int Cantidad { get; set; }


        public decimal Precio { get; set; }
    }
}
