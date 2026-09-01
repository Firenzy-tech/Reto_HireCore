using HireCore.ConsoleApp.Domain;

namespace HireCore.ConsoleApp.Observer
{
    public class HiringManagerNotifier: ITransitionObserver
    {
        public void Update(Candidate candidate, string oldState, string newState)
        {
            if (newState == HireStatus.OFERTA.ToString() || newState == HireStatus.CONTRATADO.ToString())
            {
                Console.WriteLine($"[Email a Gerente] {candidate.Name} está en etapa de {newState}.");
            }
        }
    }
}
