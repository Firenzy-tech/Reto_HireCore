using System;
using System.Collections.ObjectModel;
namespace MyApp.Models
{

    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DocumentType { get; set; }

        public string DocumentNumber { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public Collection<Ofert> Oferts { get; set; }

    }
}
