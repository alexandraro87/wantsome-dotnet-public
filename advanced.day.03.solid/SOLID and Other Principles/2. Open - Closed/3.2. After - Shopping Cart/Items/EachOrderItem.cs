namespace OpenClosedShoppingCartAfter.Items
{
    public class EachOrderItem : IOrderItem
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }

        public decimal Total()
        {
            return this.Quantity * 5m;
        }
    }
}