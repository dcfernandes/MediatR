using EstudoMediatR.Applciation.Commands;
using EstudoMediatR.Applciation.Logs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace EstudoMediatR.PedidosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
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
            var result = await _mediator.Send(request, CancellationToken.None);
            return Ok(_log.Passos);
        }

    }
}
