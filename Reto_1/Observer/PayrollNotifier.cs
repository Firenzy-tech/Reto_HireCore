using HireCore.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireCore.ConsoleApp.Observer
{
    public class PayrollNotifier : ITransitionObserver
    {
        public void Update(Candidate candidate, string oldState, string newState)
        {
            if (newState == "HIRED")
            {
                Console.WriteLine($"[Alerta a Nómina] {candidate.Name} fue {newState}. Iniciar proceso de ingreso.");
            }
        }
    }
}
