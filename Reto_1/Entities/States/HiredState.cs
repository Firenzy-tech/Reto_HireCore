namespace Reto_1.Entities.States
{
    public class HiredState : IHireState
    {
        public string Name => HireStatus.STATUS_CONTRATADO;

        public IHireState? Next(string newStatus) => null;

        public string Message(string candidateName) => $"{candidateName} fue contratado";
    }
}
