using HireCore.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireCore.ConsoleApp.State
{
    public class AppliedState : ICandidateState
    {
        public string Name => "APPLIED";

        public void Advance(Candidate candidate, ICandidateState newState)
        {
            if (newState is InterviewState || newState is RejectedState)
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
