namespace Reto_1.Entities.States
{
    public class OfferState : IHireState
    {
        public string Name => HireStatus.STATUS_OFERTA;

        public IHireState? Next(string newStatus) => newStatus switch
        {
            HireStatus.STATUS_CONTRATADO => new HiredState(),
            HireStatus.STATUS_RECHAZADO => new RejectedState(),
            _ => null
        };

        public string Message(string candidateName) => $"Oferta enviada a {candidateName}";
    }
}
