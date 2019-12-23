namespace OpenClosedShoppingCartAfter.Items
{
    public class WeightOrderItem : IOrderItem
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }

        public decimal Total()
        {
            return this.Quantity * 4m / 1000;
        }
    }
}