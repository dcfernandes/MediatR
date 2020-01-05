namespace EstudoMediatR.Applciation.Events
{
    using MediatR;

    public class NotaFiscalEmitidaEvent : INotification
    {
        public NotaFiscalEmitidaEvent(int numeroNotaFiscal)
        {
            NumeroNotaFiscal = numeroNotaFiscal;
        }

        public int NumeroNotaFiscal { get; private set; }
    }
}
