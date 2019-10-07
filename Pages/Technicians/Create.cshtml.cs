using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainingHub.Models;

namespace TrainingHub.Pages.Technicians
{
    public class CreateModel : PageModel
    {
        private readonly TrainingHub.Models.TrainingHubContext _context;

        public CreateModel(TrainingHub.Models.TrainingHubContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Technician Technician { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyTechnician = new Technician();

            if(await TryUpdateModelAsync<Technician>(
                emptyTechnician,
                "technician",   // Prefix for form value.
                s => s.PNumber, s => s.LastName, s => s.FirstName
                ))

            {
                _context.Technician.Add(emptyTechnician);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            

            return null;
        }
    }
}