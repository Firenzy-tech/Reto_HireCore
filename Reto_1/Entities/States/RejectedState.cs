namespace Reto_1.Entities.States
{
    public class RejectedState : IHireState
    {
        public string Name => HireStatus.STATUS_RECHAZADO;

        public IHireState? Next(string newStatus) => null;

        public string Message(string candidateName) => $"{candidateName} fue rechazado";
    }
}
