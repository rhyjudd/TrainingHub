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

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }


        public IList<Technician> Technician { get;set; }

        //public async Task OnGetAsync()
        //{
        //    Technician = await _context.Technician.ToListAsync();
        //}

        public async Task OnGetAsync(string sortOrder) 
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            IQueryable<Technician> techniciansIQ = from s in _context.Technicians
                                                   select s;

            switch (sortOrder)
            {
                case "name_desc":
                    techniciansIQ = techniciansIQ.OrderByDescending(s => s.LastName);
                    break;
                default:
                    techniciansIQ = techniciansIQ.OrderBy(s => s.LastName);
                    break;
            }

            Technician = await techniciansIQ.AsNoTracking().ToListAsync();
        }
    }
}
