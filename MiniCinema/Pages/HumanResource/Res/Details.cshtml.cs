﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MiniCinema.Data;
using MiniCinema.Models;

namespace MiniCinema.Pages.Res
{
    public class DetailsModel : PageModel
    {
        private readonly MiniCinema.Data.MiniCinemaContext _context;

        public DetailsModel(MiniCinema.Data.MiniCinemaContext context)
        {
            _context = context;
        }

      public Resign Resign { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Resign == null)
            {
                return NotFound();
            }

            var resign = await _context.Resign.FirstOrDefaultAsync(m => m.ID == id);
            if (resign == null)
            {
                return NotFound();
            }
            else 
            {
                Resign = resign;
            }
            return Page();
        }
    }
}
