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
    public class DetailsModel : PageModel
    {
        private readonly TrainingHub.Models.TrainingHubContext _context;

        public DetailsModel(TrainingHub.Models.TrainingHubContext context)
        {
            _context = context;
        }

        public Technician Technician { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Technician = await _context.Technician.Include(s =>s.Trainings).ThenInclude(e=>e.Course).AsNoTracking().FirstOrDefaultAsync(m => m.TechnicianID == id);

            if (Technician == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
