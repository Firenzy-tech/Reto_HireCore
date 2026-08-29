using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class JobOffer
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime PostedDate { get; set; }

    public string Status { get; set; } = string.Empty;

    public bool IsActive { get; set; }

}



//class GestorDeCandidato
//{
//    avanzarEstado(candidato: Candidato, nuevoEstado: string) : void {
// if (candidato.estado === "APLICADO" && nuevoEstado === "ENTREVISTA") {
// candidato.estado = "ENTREVISTA";
// EmailService.enviar(candidato.reclutadorEmail, `${candidato.nombre
//}
//pasó a 
//entrevista`);
// } else if (candidato.estado === "ENTREVISTA" && nuevoEstado === "OFERTA")
//{
//    candidato.estado = "OFERTA";
//    EmailService.enviar(candidato.reclutadorEmail, `Oferta enviada a 
//${ candidato.nombre}`);
//}
//else if (candidato.estado === "OFERTA" && nuevoEstado === "CONTRATADO")
//{
//    candidato.estado = "CONTRATADO";
//    EmailService.enviar(candidato.reclutadorEmail, `${ candidato.nombre}
//    fue contratado`);
//}
//else if (nuevoEstado === "RECHAZADO")
//{
//    candidato.estado = "RECHAZADO";
//    EmailService.enviar(candidato.reclutadorEmail, `${ candidato.nombre}
//    fue rechazado`);
//}
//else
//{
//    throw new Error(`Transición inválida: ${ candidato.estado }-> ${ nuevoEstado}`);
//}
// }
//}
