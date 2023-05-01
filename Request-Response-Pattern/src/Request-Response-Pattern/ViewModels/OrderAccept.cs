namespace MediatorExample.ViewModels
{
    public record OrderAccept
    {
        public DateTime AcceptTime { get; init; } = DateTime.UtcNow;

        public Guid OrderId { get; init; }

        public string SubmiterName { get; init; }
    }
}
