using System;
using System.Collections.ObjectModel;
using Reto_1.Entities;
using Reto_1.Entities.States;

namespace MyApp.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public Document Document { get; set; } = new Document();

        public string Address { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string RecruiterEmail { get; set; } = string.Empty;

        public DateTime Birthdate { get; set; }

        public IHireState State { get; set; } = new AppliedState();

        public Collection<JobOffer> Oferts { get; set; } = new Collection<JobOffer>();

        public CandidateMemento Save() => new CandidateMemento(State);

        public void Restore(CandidateMemento memento) => State = memento.State;
    }
}
