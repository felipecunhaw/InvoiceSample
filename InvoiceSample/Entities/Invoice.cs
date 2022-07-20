namespace InvoiceSample.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public Customer ? Customer { get; set; }
        public ICollection<InvoiceItems> ? Items { get; set; }
    }
}
