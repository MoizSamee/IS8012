using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Adv_Net_Assign2.Data;
using Adv_Net_Assign2.Models;

namespace Adv_Net_Assign2.Pages
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryListModelsController : ControllerBase
    {
        private readonly GroceryListContext _context;

        public GroceryListModelsController(GroceryListContext context)
        {
            _context = context;
        }

        // GET: api/GroceryListModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroceryListModel>>> GetGroceryList()
        {
            return await _context.GroceryList.ToListAsync();
        }

        // GET: api/GroceryListModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroceryListModel>> GetGroceryListModel(int id)
        {
            var groceryListModel = await _context.GroceryList.FindAsync(id);

            if (groceryListModel == null)
            {
                return NotFound();
            }

            return groceryListModel;
        }

        // PUT: api/GroceryListModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroceryListModel(int id, GroceryListModel groceryListModel)
        {
            if (id != groceryListModel.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(groceryListModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroceryListModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GroceryListModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GroceryListModel>> PostGroceryListModel(GroceryListModel groceryListModel)
        {
            _context.GroceryList.Add(groceryListModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroceryListModel", new { id = groceryListModel.ItemId }, groceryListModel);
        }

        // DELETE: api/GroceryListModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroceryListModel>> DeleteGroceryListModel(int id)
        {
            var groceryListModel = await _context.GroceryList.FindAsync(id);
            if (groceryListModel == null)
            {
                return NotFound();
            }

            _context.GroceryList.Remove(groceryListModel);
            await _context.SaveChangesAsync();

            return groceryListModel;
        }

        private bool GroceryListModelExists(int id)
        {
            return _context.GroceryList.Any(e => e.ItemId == id);
        }

        [HttpPut("MarkComplete/{id}")]
        public async Task<ActionResult<GroceryListModel>> LoanBookAsync([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var itemUpdate = _context.GroceryList.Find(id);
            if (itemUpdate == null)
            {
                return BadRequest();
            }
            //itemUpdate.DateCreated = DateTime.Now;
            itemUpdate.Completed = true;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroceryListModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(itemUpdate);
        }
    }
}
