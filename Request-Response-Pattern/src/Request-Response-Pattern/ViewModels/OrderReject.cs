namespace MediatorExample.ViewModels
{
    public record OrderReject
    {
        public DateTime AcceptTime { get; init; } = DateTime.UtcNow;

        public Guid OrderId { get; init; }

        public string SubmiterName { get; init; }

        public string Reason { get; init; }
    }
}
