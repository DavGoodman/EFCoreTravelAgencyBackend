public class Observation
{
    public Guid Id { get; set; }
    public string GuestName { get; set; }
    public int NumberOfNights { get; set; }
    public Guid InvoiceId { get; set; }
    public string TravelAgent { get; set; } 
    public Invoice Invoice { get; set; }
    public TravelAgentInfo TravelAgentInfo { get; set; }
}
