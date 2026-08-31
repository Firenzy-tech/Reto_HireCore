namespace Reto_1.Entities.States
{
    public interface IHireState
    {
        string Name { get; }

        IHireState? Next(string newStatus);

        string Message(string candidateName);
    }
}
