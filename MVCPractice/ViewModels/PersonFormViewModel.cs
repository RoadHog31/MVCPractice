using MVCPractice.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPractice.ViewModels
{
    public class PersonFormViewModel
    {
        private Person person1;

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]        
        public int Age { get; set; }

        [Display(Name = "Is Active?")]
        [Required]       
        public bool IsActive { get; set; }

        public PersonFormViewModel()
        {
            Id = 0;
        }

        public PersonFormViewModel(Person person)
        {
            Id = person.Id;
            FirstName = person.FirstName;
            LastName = person.LastName;
            IsActive = person.IsActive;
        }

        public PersonFormViewModel(Person person, Person person1) : this(person)
        {
            this.person1 = person1;
        }
    }
}