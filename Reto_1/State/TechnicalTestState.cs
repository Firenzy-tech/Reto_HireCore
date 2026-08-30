using HireCore.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireCore.ConsoleApp.State
{
    public class TechnicalTestState: ICandidateState
    {
        public string Name => "TECHNICAL_TEST";

        public void Advance(Candidate candidate, ICandidateState newState)
        {
            if (newState is OfferState || newState is RejectedState)
            {
                candidate.SetState(newState);
            }
            else
            {
                throw new InvalidOperationException($"Invalid transition: {Name} -> {newState.Name}");
            }
        }
    }
}
