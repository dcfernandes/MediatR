using MediatR;

namespace EstudoMediatR.Applciation.Events
{
    public class NotaFiscalEmitidaEvent : INotification
    {
        public NotaFiscalEmitidaEvent(int numeroNotaFiscal)
        {
            NumeroNotaFiscal = numeroNotaFiscal;
        }

        public int NumeroNotaFiscal { get; private set; }
    }
}
