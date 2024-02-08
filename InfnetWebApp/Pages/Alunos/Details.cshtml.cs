using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InfnetWebApp.Models;

namespace InfnetWebApp.Pages.Alunos
{
    public class DetailsModel : PageModel
    {
        private readonly InfnetDbContext _context;

        public DetailsModel(InfnetDbContext context)
        {
            _context = context;
        }

      public Aluno Aluno { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Aluno == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno.FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }
            else 
            {
                Aluno = aluno;
            }
            return Page();
        }
    }
}
