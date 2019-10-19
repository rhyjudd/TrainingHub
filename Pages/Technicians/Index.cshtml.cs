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



        public IList<Technician> Technician { get;set; }

        //public async Task OnGetAsync()
        //{
        //    Technician = await _context.Technician.ToListAsync();
        //}

        public async Task OnGetAsync(string sortOrder) 
        {
            LastNameSort = String.IsNullOrEmpty(sortOrder) ? "Lname_desc" : "Lname_asc";
            FirstNameSort = String.IsNullOrEmpty(sortOrder) ? "Fname_desc" : "Fname_asc";
            PNumberSort = sortOrder == "Pnumber" ? "Pnumber_desc" : "Pnumber";

            IQueryable<Technician> techniciansIQ = from s in _context.Technicians
                                                   select s;

            switch (sortOrder)
            {
                case "Lname_desc":
                    techniciansIQ = techniciansIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Lname_asc":
                    techniciansIQ = techniciansIQ.OrderBy(s => s.LastName);
                    break;
                case "Fname_desc":
                    techniciansIQ = techniciansIQ.OrderByDescending(s => s.FirstName);
                    break;
                case "Fname_asc":
                    techniciansIQ = techniciansIQ.OrderBy(s => s.FirstName);
                    break;
                case "Pnumber_desc":
                    techniciansIQ = 
                
                default:
                    
                    break;
            }

            Technician = await techniciansIQ.AsNoTracking().ToListAsync();
        }
    }
}
