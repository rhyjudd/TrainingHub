using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainingHub.Models;

namespace TrainingHub.Pages.Technicians
{
    public class EditModel : PageModel
    {
        private readonly TrainingHub.Models.TrainingHubContext _context;

        public EditModel(TrainingHub.Models.TrainingHubContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Technician Technician { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Technician = await _context.Technician.FindAsync(id);

            if (Technician == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var technicianToUpdate = await _context.Technician.FindAsync(id);

            if (await TryUpdateModelAsync<Technician>(
            technicianToUpdate,
            "technician",
            s => s.PNumber, s => s.LastName, s => s.FirstName))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }


            return Page();
        }

        private bool TechnicianExists(int id)
        {
            return _context.Technician.Any(e => e.TechnicianID == id);
        }
    }
}
