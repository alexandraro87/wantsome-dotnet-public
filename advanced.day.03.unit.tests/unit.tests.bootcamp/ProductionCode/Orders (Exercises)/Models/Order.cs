namespace ProductionCode.Orders.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Order
    {
        public int OrderId { get; set; }

        public int ClientId { get; set; }
        public string ClientName { get; set; }

        public int? ContractId { get; set; }

        public string Status { get; set; }

        /// <summary>
        ///     Order cost with tax.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        ///     Order cost before tax.
        /// </summary>
        public decimal Subtotal { get; set; }

        public string Source { get; set; }
        public string OpportunityId { get; set; }

        public decimal SubtotalPercentage => this.Amount == 0 ? 0 : this.Subtotal / this.Amount;

        public string CurrencyIsoCode { get; set; }

        public bool IsAnnualSubscription { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime? BookedDate { get; set; }

        public bool IsDeleted { get; set; }

        public string SalesRep { get; set; }

        public List<Invoice> Invoices { get; } = new List<Invoice>();
        public List<Payment> Payments { get; } = new List<Payment>();
        public decimal TotalPayments => this.Payments.Select(p => p.Amount).DefaultIfEmpty(0M).Sum();
        public List<Refund> Refunds { get; } = new List<Refund>();

        /// <summary>
        ///     Total amount of Refunds (not included tax refunds)
        /// </summary>
        public decimal TotalRefunds => this.Refunds.Select(r => r.Amount).DefaultIfEmpty(0M).Sum();

        public List<Adjustment> Adjustments { get; } = new List<Adjustment>();
        public decimal TotalAdjustments => this.Adjustments.Select(a => a.Amount).DefaultIfEmpty(0M).Sum();

        public bool ShouldBeIgnored
        {
            get
            {
                if (!this.BookedDate.HasValue || this.BookedDate.Value < new DateTime(2016, 4, 1))
                    return true;

                return false;
            }
        }
    }
}
