namespace EstudoMediatR.Applciation.Logs
{
    using System;
    using System.Collections.Generic;

    public interface ILog
    {
        List<string> Passos { get; set; }
        void AddPassos(string passo);
    }

    public class Log : ILog
    {
        public Log()
        {
            Passos = new List<string>();
        }
        public List<string> Passos { get; set; }

        public void AddPassos(string passo) => Passos.Add($"Hora: {DateTime.Now.ToString("hh:MM:ss.fff")} - {passo}");

    }
}
