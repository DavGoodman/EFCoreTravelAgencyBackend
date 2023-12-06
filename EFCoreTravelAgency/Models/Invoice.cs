using Onyx_Tasks.Models;

public class Invoice
{
    public Guid Id { get; set; }
    public List<Observation> Observations { get; set; }
    public List<InvoiceGroupLink> InvoiceGroupLinks { get; set; }
}
