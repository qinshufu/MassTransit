namespace MediatorExample.Command
{
    public class OrderSubmitCommand
    {
        public DateTime SubmitTime { get; init; } = DateTime.UtcNow;

        public Guid OrderId { get; set; }

        public string SubmiterName { get; set; }
    }
}
