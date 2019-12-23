namespace OpenClosedShoppingCartAfter
{
    using System.Collections.Generic;
    using OpenClosedShoppingCartAfter.Items;

    public class Cart
    {
        private readonly List<IOrderItem> items;

        public Cart()
        {
            this.items = new List<IOrderItem>();
        }

        public IEnumerable<IOrderItem> Items
        {
            get { return new List<IOrderItem>(this.items); }
        }

        public string CustomerEmail { get; set; }

        public void Add(IOrderItem orderItem)
        {
            this.items.Add(orderItem);
        }

        public decimal TotalAmount()
        {
            decimal total = 0m;
            foreach (IOrderItem orderItem in this.Items)
            {
                total += orderItem.Total();
            }

            return total;
        }
    }
}