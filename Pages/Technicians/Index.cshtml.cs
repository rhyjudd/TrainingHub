using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainingHub.Models;

namespace TrainingHub.Pages.Technicians
{
    public class IndexModel : PageModel
    {
        private readonly TrainingHub.Models.TrainingHubContext _context;

        public IndexModel(TrainingHub.Models.TrainingHubContext context)
        {
            _context = context;
        }

        public string LastNameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public string FirstNameSort { get; set; }
        public string PNumberSort { get; set; }



        public IList<Technician> Technicians { get;set; }

       
        public async Task OnGetAsync(string sortOrder, string searchString) 
        {
            LastNameSort = String.IsNullOrEmpty(sortOrder) ? "Lname_desc" : "";
            FirstNameSort = sortOrder == "Fname_asc" ? "Fname_desc" : "Fname_asc";
            PNumberSort = sortOrder == "Pnumber_asc" ? "Pnumber_desc" : "Pnumber_asc";

            IQueryable<Technician> techniciansIQ = from s in _context.Technician
                                                   select s;
            CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                techniciansIQ = techniciansIQ.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "Lname_desc":
                    techniciansIQ = techniciansIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Fname_desc":
                    techniciansIQ = techniciansIQ.OrderByDescending(s => s.FirstName);
                    break;
                case "Fname_asc":
                    techniciansIQ = techniciansIQ.OrderBy(s => s.FirstName);
                    break;
                case "Pnumber_desc":
                    techniciansIQ = techniciansIQ.OrderByDescending(s => s.PNumber);
                    break;
                case "Pnumber_asc":
                    techniciansIQ = techniciansIQ.OrderBy(s => s.PNumber);
                    break;
                default :
                    techniciansIQ = techniciansIQ.OrderBy(s => s.LastName);
                    break;                   
                    
            }

            Technicians = await techniciansIQ.AsNoTracking().ToListAsync();
        }
    }
}
