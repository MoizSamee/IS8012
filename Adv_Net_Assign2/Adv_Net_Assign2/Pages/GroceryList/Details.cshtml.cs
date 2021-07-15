using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Adv_Net_Assign2.Data;
using Adv_Net_Assign2.Models;

namespace Adv_Net_Assign2.Pages.GroceryList
{
    public class DetailsModel : PageModel
    {
        private readonly Adv_Net_Assign2.Data.GroceryListContext _context;

        public DetailsModel(Adv_Net_Assign2.Data.GroceryListContext context)
        {
            _context = context;
        }

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
    }
}
