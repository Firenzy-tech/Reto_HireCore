using Reto_1.Entities.States;

namespace Reto_1.Entities
{
    public class CandidateMemento
    {
        public CandidateMemento(IHireState state)
        {
            State = state;
        }

        public IHireState State { get; }
    }
}
