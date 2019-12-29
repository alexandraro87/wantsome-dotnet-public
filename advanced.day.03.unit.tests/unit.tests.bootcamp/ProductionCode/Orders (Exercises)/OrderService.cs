namespace ProductionCode.Orders
{
    using System;
    using System.Linq;
    using Models;

    public class OrderService
    {
        public bool IsOrderValid(Order order)
        {
            try
            {
                this.ValidateOrder(order);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void ValidateOrder(Order order)
        {
            if (order.Amount < 0)
                throw new Exception("Order amount cannot be negative");

            if (order.Amount + order.TotalAdjustments < 0)
                throw new Exception("Order adjustments make total amount negative");


            if (order.BookedDate > DateTime.Now)
                throw new Exception("BookedDate cannot be in the future");

            if (order.IsDeleted)
                throw new Exception("Order has been deleted");
        }

        public Payment PayInvoice(Order order, int invoiceId)
        {
            var invoiceToPay = order.Invoices.FirstOrDefault(inv => inv.InvoiceId == invoiceId);

            if (invoiceToPay == null) throw new Exception("Invalid InvoiceId");

            var payment = new Payment
            {
                Amount = invoiceToPay.Amount,
                CreatedDate = DateTime.Now,
                InvoiceId = invoiceId,
                OrderId = invoiceToPay.OrderId,
                PaymentId = new Random(DateTime.Now.Millisecond).Next()
            };


            if (payment.Amount != 0)
                // Joe in Accounting said not to include $0 payments on the order
                order.Payments.Add(payment);

            return payment;
        }

        public Refund RefundPayment(Payment payment)
        {
            var refund = new Refund
            {
                Amount = payment.Amount,
                OrderId = payment.OrderId.Value,
                CreatedDate = DateTime.Now,
                RefundId = new Random(DateTime.Now.Millisecond).Next()
            };

            return refund;
        }
    }
}
