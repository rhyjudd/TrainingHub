using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingHub.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }

        public string Description { get; set; }
        public ICollection<Training> Trainings { get; set; }

    }
}
