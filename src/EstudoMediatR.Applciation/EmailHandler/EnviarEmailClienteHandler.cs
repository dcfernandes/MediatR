using EstudoMediatR.Applciation.Events;
using EstudoMediatR.Applciation.Logs;
using EstudoMediatR.Applciation.Pedido;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EstudoMediatR.Applciation.EmailHandler
{
    public class EnviarEmailClienteHandler : INotificationHandler<PedidoRealizadoEvent>, INotificationHandler<NotaFiscalEmitidaEvent>
    {
        private readonly IMediator _mediator;
        private readonly ILog _log;

        public EnviarEmailClienteHandler(IMediator mediator, ILog log)
        {
            _mediator = mediator;
            _log = log;
        }

        public Task Handle(PedidoRealizadoEvent notification, CancellationToken cancellationToken)
        {
            _log.AddPassos($"EnviarEmailClienteHandler: PedidoRealizadoEvent");

            return Task.CompletedTask;
        }

        public Task Handle(NotaFiscalEmitidaEvent notification, CancellationToken cancellationToken)
        {
            _log.AddPassos($"EnviarEmailClienteHandler: NotaFiscalEmitidaEvent");
            return Task.CompletedTask;
        }
    }
}
