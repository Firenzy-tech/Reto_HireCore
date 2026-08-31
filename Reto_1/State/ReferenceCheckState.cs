using HireCore.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireCore.ConsoleApp.State
{
    internal class ReferenceCheckState: ICandidateState
    {
        public string Name => HireStatus.REFERENCIA;

        public void Advance(Candidate candidate, ICandidateState newState)
        {
            if (newState is HiredState || newState is RejectedState)
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
