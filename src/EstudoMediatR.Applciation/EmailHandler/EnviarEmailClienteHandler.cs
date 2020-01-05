namespace EstudoMediatR.Applciation.EmailHandler
{
    using EstudoMediatR.Applciation.Events;
    using EstudoMediatR.Applciation.Logs;
    using EstudoMediatR.Applciation.Pedido;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class EnviarEmailClienteHandler : INotificationHandler<PedidoRealizadoEvent>, INotificationHandler<NotaFiscalEmitidaEvent>
    {
        private readonly ILog _log;

        public EnviarEmailClienteHandler(ILog log)
        {
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
