namespace HireCore.ConsoleApp.Domain
{
    public enum HireStatus
    {
        RECHAZADO = 0,
        APLICADO = 1,
        ENTREVISTA = 2,
        PRUEBA_TECNICA = 3,
        REFERENCIA = 4,
        OFERTA = 5,
        CONTRATADO = 6
    }



    public static class HireStatusExtensions
    {
        private static readonly Dictionary<HireStatus, string> StatusNames = new()
        {
            { HireStatus.APLICADO, "Entrevista" },
            { HireStatus.ENTREVISTA, "Prueba Técnica" },
            { HireStatus.PRUEBA_TECNICA, "Referencia" },
            { HireStatus.REFERENCIA, "Oferta" },
            { HireStatus.OFERTA, "Contratado" },
            { HireStatus.CONTRATADO, "" }
        };
        public static string GetName(this HireStatus status)
        {
            return StatusNames.TryGetValue(status, out var name) ? name : status.ToString();
        }
    }



}

