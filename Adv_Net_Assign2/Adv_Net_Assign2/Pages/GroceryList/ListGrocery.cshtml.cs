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
    public class ListGroceryModel : PageModel
    {
        private readonly Adv_Net_Assign2.Data.GroceryListContext _context;

        public ListGroceryModel(Adv_Net_Assign2.Data.GroceryListContext context)
        {
            _context = context;
        }

        public IList<GroceryListModel> GroceryListModel { get;set; }

        public async Task OnGetAsync()
        {
            GroceryListModel = await _context.GroceryList.ToListAsync();
        }
    }
}
