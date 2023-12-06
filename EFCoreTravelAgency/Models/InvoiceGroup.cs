using Onyx_Tasks.Models;

public class InvoiceGroup
{

    public Guid Id { get; set; }
    public DateTime IssueDate { get; set; }
    public List<InvoiceGroupLink> InvoiceGroupLinks { get; set; }
}
