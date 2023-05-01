using MassTransit;
using MediatorExample.Command;
using MediatorExample.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MediatorExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRequestClient<OrderSubmitCommand> _orderSubmitClient;

        public OrderController(IRequestClient<OrderSubmitCommand> orderSubmitClient)
        {
            _orderSubmitClient = orderSubmitClient;
        }

        [HttpPost]
        [ProducesResponseType(typeof(OrderReject), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(OrderAccept), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> SubmitOrder([FromBody] OrderSubmitCommand command, CancellationToken ct)
        {
            var (accept, reject) = await _orderSubmitClient.GetResponse<OrderAccept, OrderReject>(command, ct);

            dynamic response = (accept.Status, reject.Status) switch
            {
                (TaskStatus.RanToCompletion, _) => accept.Result.Message,
                _ => reject.Result.Message
            };

            return Ok(response);
        }
    }
}
