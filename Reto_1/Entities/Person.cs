using System;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;
namespace MyApp.Models
{

    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public Document Document { get; set; } = new Document();

        public string Address { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateTime Birthdate { get; set; } 

        public Collection<JobOffert> Oferts { get; set; } = new Collection<JobOffert>();

    }
}
