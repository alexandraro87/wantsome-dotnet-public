namespace OpenClosedShoppingCartAfter.Items
{
    public interface IOrderItem
    {
        string Sku { get; set; }
        int Quantity { get; set; }
        decimal Total();
    }
}