using HireCore.ConsoleApp.Domain;

namespace HireCore.ConsoleApp.State
{
    public interface ICandidateState
    {
        string Name { get; }
        void Advance(Candidate candidate, ICandidateState newState);
    }
}
