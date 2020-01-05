namespace EstudoMediatR.PedidosApi.Controllers
{
    using EstudoMediatR.Applciation.Commands;
    using EstudoMediatR.Applciation.Logs;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class PedidosController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILog _log;

        public PedidosController(IMediator mediator, ILog log)
        {
            _mediator = mediator;
            _log = log;
        }

        // POST: api/Pedidos
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RealizarPedidoRequest request)
        {
            _log.AddPassos("_mediator.Send(RealizarPedidoRequest, CancellationToken.None);");
            var result = await _mediator.Send(request, default);
            return Ok(_log.Passos);
        }
    }
}