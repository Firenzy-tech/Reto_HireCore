using HireCore.ConsoleApp.Domain;

namespace HireCore.ConsoleApp.Observer
{
    public class CandidatePortalNotifier : ITransitionObserver
    {
        public void Update(Candidate candidate, string oldState, string newState)
        {
            if (newState == HireStatus.RECHAZADO.ToString())
            {
                Console.WriteLine($"Gracias por haber aplicado, {candidate.Name}.");
                return;
            }

            if (newState == HireStatus.CONTRATADO.ToString())
            {
                Console.WriteLine($"Felicidades {candidate.Name}, has sido contratado.");
                return;
            }

            Console.WriteLine($"[Portal Web] Hola {candidate.Name}, el estado de tu aplicación se actualizó a  su proximo estado será {((HireStatus)Enum.Parse(typeof(HireStatus), newState)).GetName()}.");
        }
    }
}
