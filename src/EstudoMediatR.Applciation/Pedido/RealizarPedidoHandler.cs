namespace EstudoMediatR.Applciation.Commands
{
    using EstudoMediatR.Applciation.Logs;
    using EstudoMediatR.Applciation.Pedido;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class RealizarPedidoHandler : IRequestHandler<RealizarPedidoRequest>
    {
        private readonly IMediator _mediator;
        private readonly ILog _log;

        public RealizarPedidoHandler(IMediator mediator, ILog log)
        {
            _mediator = mediator;
            _log = log;
        }

        public Task<Unit> Handle(RealizarPedidoRequest request, CancellationToken cancellationToken)
        {
            _log.AddPassos($"RealizarPedidoHandler -  Id: {request.Id}, Nome: {request.Nome}");

            _log.AddPassos("_mediator.Publish(new PedidoRealizadoEvent());");
            _mediator.Publish(new PedidoRealizadoEvent());

            return Unit.Task;
        }
    }
}
