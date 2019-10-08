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
    public class DeleteModel : PageModel
    {
        private readonly TrainingHub.Models.TrainingHubContext _context;

        public DeleteModel(TrainingHub.Models.TrainingHubContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Technician Technician { get; set; }
        public string ErrorMessage { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Technician = await _context.Technician.AsNoTracking().FirstOrDefaultAsync( m=>m.TechnicianID == id);

            if (Technician == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technician = await _context.Technician
                            .AsNoTracking()
                            .FirstOrDefaultAsync(m => m.TechnicianID == id);

            if (technician == null)
            {
                return NotFound();
            }

            try
            {
                _context.Technician.Remove(technician);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }

        
    }
}
