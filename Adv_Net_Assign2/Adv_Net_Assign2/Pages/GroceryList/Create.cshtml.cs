using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Adv_Net_Assign2.Data;
using Adv_Net_Assign2.Models;

namespace Adv_Net_Assign2.Pages.GroceryList
{
    public class CreateModel : PageModel
    {
        private readonly Adv_Net_Assign2.Data.GroceryListContext _context;

        public CreateModel(Adv_Net_Assign2.Data.GroceryListContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GroceryListModel GroceryListModel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GroceryList.Add(GroceryListModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
