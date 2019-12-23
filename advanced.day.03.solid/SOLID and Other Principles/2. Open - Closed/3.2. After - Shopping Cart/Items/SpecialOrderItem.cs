namespace OpenClosedShoppingCartAfter.Items
{
    public class SpecialOrderItem : IOrderItem
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }

        public decimal Total()
        {
            return (this.Quantity * .4m) - ((this.Quantity / 3) * .2m );
        }
    }
}