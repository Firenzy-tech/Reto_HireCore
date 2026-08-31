namespace Reto_1.Entities.States
{
    public class InterviewState : IHireState
    {
        public string Name => HireStatus.STATUS_ENTREVISTA;

        public IHireState? Next(string newStatus) => newStatus switch
        {
            HireStatus.STATUS_OFERTA => new OfferState(),
            HireStatus.STATUS_RECHAZADO => new RejectedState(),
            _ => null
        };

        public string Message(string candidateName) => $"{candidateName} pasó a entrevista";
    }
}
