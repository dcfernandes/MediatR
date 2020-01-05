namespace EstudoMediatR.Applciation.UnitTests
{
    using EstudoMediatR.Applciation.Commands;
    using EstudoMediatR.Applciation.Logs;
    using EstudoMediatR.Applciation.Pedido;
    using FluentAssertions;
    using MediatR;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class RealizarPedidoHandlerTest
    {
        readonly Mock<IMediator> _mediatorMock;
        readonly Mock<INotificationHandler<INotification>> _notificationHandlerMock;
        readonly Mock<ILog> _logMock;
        readonly List<INotification> _notifications;

        public RealizarPedidoHandlerTest()
        {
            _notifications = new List<INotification>();
            _mediatorMock = new Mock<IMediator>();
            _notificationHandlerMock = new Mock<INotificationHandler<INotification>>();
            _logMock = new Mock<ILog>();


            _notificationHandlerMock.Setup(f => f.Handle(It.IsAny<INotification>(), It.IsAny<CancellationToken>()))
                .Callback((INotification n, CancellationToken c)=>
                {
                    _notifications.Add(n);
                })
                .Returns(Task.CompletedTask);

            _mediatorMock.Setup(f => f.Publish(It.IsAny<INotification>(), It.IsAny<CancellationToken>()))
                .Callback((INotification n, CancellationToken c) =>
                {
                    _notificationHandlerMock.Object.Handle(n, c);
                })
                .Returns(Task.CompletedTask);
        }

        [Fact]
        public void RealizarPedidoHandler_Test()
        {
            var realizarPedidoHandler = new RealizarPedidoHandler(_mediatorMock.Object, _logMock.Object);

            var realizarPedidoRequest = new RealizarPedidoRequest()
            {
                Nome = "Teste pedido",
                Quantidade = 1,
                Valor = 100M
            };

            var result = realizarPedidoHandler.Handle(realizarPedidoRequest, default);

            _notifications.Should().ContainItemsAssignableTo<PedidoRealizadoEvent>();
        }
    }
}
