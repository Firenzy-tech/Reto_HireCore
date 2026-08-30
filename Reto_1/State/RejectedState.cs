using HireCore.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireCore.ConsoleApp.State
{
    public class RejectedState : ICandidateState
    {
        public string Name => "REJECTED";
        public void Advance(Candidate candidate, ICandidateState newState) =>
            throw new InvalidOperationException("Process terminated. Cannot advance from REJECTED.");
    }
}
