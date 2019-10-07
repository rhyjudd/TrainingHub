using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingHub.Models
{
    public class Training
    {
        public int TrainingID { get; set; }
        public int CourseID { get; set; }
        public int TechnicianID { get; set; }
        public Course Course { get; set; }
        public Technician Technician { get; set; }


    }
}
