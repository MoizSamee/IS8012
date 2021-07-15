using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Adv_Net_Assign2.Data;
using Adv_Net_Assign2.Models;

namespace Adv_Net_Assign2.Pages.GroceryList
{
    public class EditModel : PageModel
    {
        private readonly Adv_Net_Assign2.Data.GroceryListContext _context;

        public EditModel(Adv_Net_Assign2.Data.GroceryListContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GroceryListModel GroceryListModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GroceryListModel = await _context.GroceryList.FirstOrDefaultAsync(m => m.ItemId == id);

            if (GroceryListModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GroceryListModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroceryListModelExists(GroceryListModel.ItemId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GroceryListModelExists(int id)
        {
            return _context.GroceryList.Any(e => e.ItemId == id);
        }
    }
}
