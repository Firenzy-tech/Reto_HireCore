using HireCore.ConsoleApp.State;

namespace HireCore.ConsoleApp.Memento
{
    public record CandidateMemento(ICandidateState State);
}
