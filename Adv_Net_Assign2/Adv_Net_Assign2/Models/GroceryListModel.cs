using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Adv_Net_Assign2.Models
{
    public class GroceryListModel
    {
        [Key]
        public int ItemId { get; set; }

        [DisplayName("Item Name")]
        public string ItemName { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Date created")]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        [DisplayName("Purchased")]
        public bool Completed { get; set; }

        

    }
}
