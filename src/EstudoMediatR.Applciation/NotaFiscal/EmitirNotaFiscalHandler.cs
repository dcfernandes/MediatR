using EstudoMediatR.Applciation.Events;
using EstudoMediatR.Applciation.Logs;
using EstudoMediatR.Applciation.Pedido;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EstudoMediatR.Applciation.NotaFiscal
{
    public class EmitirNotaFiscalHandler : INotificationHandler<PedidoRealizadoEvent>
    {
        private readonly IMediator _mediator;
        private readonly ILog _log;

        public EmitirNotaFiscalHandler(IMediator mediator, ILog log)
        {
            _mediator = mediator;
            _log = log;
        }

        public Task Handle(PedidoRealizadoEvent notification, CancellationToken cancellationToken)
        {
            _log.AddPassos($"EmitirNotaFiscalHandler");

            var r = new Random();

            _log.AddPassos("_mediator.Publish(new NotaFiscalEmitidaEvent());");
            _mediator.Publish(new NotaFiscalEmitidaEvent(new Random().Next(100000, 9999999)));
            return Task.CompletedTask;
        }
    }
}
