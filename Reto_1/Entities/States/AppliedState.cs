namespace Reto_1.Entities.States
{
    public class AppliedState : IHireState
    {
        public string Name => HireStatus.STATUS_APLICADO;

        public IHireState? Next(string newStatus) => newStatus switch
        {
            HireStatus.STATUS_ENTREVISTA => new InterviewState(),
            HireStatus.STATUS_RECHAZADO => new RejectedState(),
            _ => null
        };

        public string Message(string candidateName) => $"{candidateName} registró su aplicación";
    }
}
