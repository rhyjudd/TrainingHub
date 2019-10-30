using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TrainingHub.Models
{
    public class Certificate
    {
        public int CertificateID { get; set; }
        public string CertTitle { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateAwarded { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateExpires { get; set}
    }
}
