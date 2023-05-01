using MassTransit;
using MediatorExample.ViewModels;

namespace MediatorExample.Command
{
    public class OrderSubmitHandler : IConsumer<OrderSubmitCommand>
    {
        public async Task Consume(ConsumeContext<OrderSubmitCommand> context)
        {
            var order = context.Message;

            object result = context.Message.SubmiterName switch
            {
                "REJECT" => new OrderReject() { AcceptTime = DateTime.UtcNow, OrderId = order.OrderId, Reason = "rejct", SubmiterName = order.SubmiterName },
                _ => new OrderAccept() { AcceptTime = DateTime.UtcNow, OrderId = order.OrderId, SubmiterName = order.SubmiterName },
            };

            await context.RespondAsync(result);
        }
    }
}
