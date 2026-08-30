using HireCore.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace HireCore.ConsoleApp.Observer
{
    // Interfaz que deben implementar todos los destinatarios de notificaciones
    public interface ITransitionObserver
    {
        void Update(Candidate candidate, string oldState, string newState);
    }
}
