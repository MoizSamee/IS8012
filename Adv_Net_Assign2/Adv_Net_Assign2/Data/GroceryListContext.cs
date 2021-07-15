using Adv_Net_Assign2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adv_Net_Assign2.Data
{
    public class GroceryListContext : DbContext
    {
        
        
        public GroceryListContext(DbContextOptions<GroceryListContext> options)
            : base(options)
        {
        }

        public DbSet<Adv_Net_Assign2.Models.GroceryListModel> GroceryList { get; set; }


      /*  protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }*/


        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroceryListModel>().HasData(
                new GroceryListModel
                {
                    ItemId = 1,
                    ItemName = "Milk",
                    Description = "Whole Milk",
                    Quantity = 2,
                    Completed = true
                });

            *//*modelBuilder.Entity<GroceryListModel>().HasData(
                new GroceryListModel
                {
                    ItemId = 2,
                    ItemName = "Bread",
                    Description = "Wheat Bread",
                    Quantity = 2,
                    Completed = false
                });

            modelBuilder.Entity<GroceryListModel>().HasData(
                new GroceryListModel
                {
                    ItemId = 3,
                    ItemName = "Juice",
                    Description = "Orange Juice",
                    Quantity = 5,
                    Completed = false
                });

            modelBuilder.Entity<GroceryListModel>().HasData(
                new GroceryListModel
                {
                    ItemId = 4,
                    ItemName = "Eggs",
                    Description = "Whole eggs",
                    Quantity = 12,
                    Completed = true
                });

            modelBuilder.Entity<GroceryListModel>().HasData(
                new GroceryListModel
                {
                    ItemId = 5,
                    ItemName = "tomatoes",
                    Description = "organic tomatoes",
                    Quantity = 12,
                    Completed = false
                });*//*

            base.OnModelCreating(modelBuilder);
        }*/

    }
}
