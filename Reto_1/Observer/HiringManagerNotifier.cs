using HireCore.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireCore.ConsoleApp.Observer
{
    public class HiringManagerNotifier: ITransitionObserver
    {
        public void Update(Candidate candidate, string oldState, string newState)
        {
            if (newState == "OFFER" || newState == "HIRED")
            {
                Console.WriteLine($"[Email a Gerente] {candidate.Name} está en etapa de {newState}.");
            }
        }
    }
}
