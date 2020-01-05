namespace EstudoMediatR.Applciation.Commands
{
    using MediatR;
    using System;

    public class RealizarPedidoRequest : IRequest
    {
        public RealizarPedidoRequest()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }



        public override string ToString()
        {
            return $"Id: {Id.ToString()} - Nome: {Nome} - Valor: {Valor.ToString()} - Quantidade: {Quantidade.ToString()}";

        }
    }
}
