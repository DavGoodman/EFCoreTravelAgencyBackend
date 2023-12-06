namespace Onyx_Tasks.Models
{
    public class InvoiceGroupLink
    {
        public Guid InvoiceId { get; set; }
        public Guid InvoiceGroupId { get; set; }
        public Invoice Invoice { get; set; }
        public InvoiceGroup InvoiceGroup { get; set; }
    }
}
