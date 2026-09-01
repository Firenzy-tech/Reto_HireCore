using HireCore.ConsoleApp.Domain;

namespace HireCore.ConsoleApp.Observer
{
    public class PayrollNotifier : ITransitionObserver
    {
        public void Update(Candidate candidate, string oldState, string newState)
        {
            if (newState == HireStatus.CONTRATADO.ToString())
            {
                Console.WriteLine($"[Alerta a Nómina] {candidate.Name} fue {newState}. Iniciar proceso de ingreso.");
            }
        }
    }
}
