using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TrainingHub.Models
{
    public class Technician
    {
        public int TechnicianID { get; set; }
        public int PNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
        public int PhoneNumber { get; set; }

        public string emailAddress { get; set; }
        public bool LeadStatus { get; set; }



        public ICollection<Training> Trainings { get; set; }
        
    }
}
