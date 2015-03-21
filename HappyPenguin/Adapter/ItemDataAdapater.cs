using HappyPenguin.Data;
using HappyPenguin.Data.Models;
using HappyPenguin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyPenguin.Adapter
{
    public class ItemDataAdapater : IOrderAdapter
    {
        public List<ItemViewModels> GetItem()
        {
            List<ItemViewModels> models = null;
            using (HappyPenguinDbContext db = new HappyPenguinDbContext())
            {
                models = db.Items.Select(i => new ItemViewModels
                {
                    // Category = i.Category,
                    ItemName = i.ItemName,
                    ItemsId = i.ItemsId,
                    Price = i.Price,
                    Image = i.Image
                }).ToList();
            }
            return models;
        }
                
        public int AddItem(ItemViewModels model, string userId)
        {
            int itemItemId;
            using (HappyPenguinDbContext db = new HappyPenguinDbContext())
            {
                Item item = new Item
                {
                    ItemName = model.ItemName,
                    ItemsId = model.ItemsId,
                    Price = model.Price,
                    Image = model.Image
                };

                db.Items.Add(item);
                db.SaveChanges();

                itemItemId = item.ItemsId;
            }
            return itemItemId;
        }
        public int DeleteItem(ItemViewModels item)
        {
            
            using (HappyPenguinDbContext db = new HappyPenguinDbContext())
            {
                var remove = db.Items.Where(x => x.ItemsId == item.ItemsId).SingleOrDefault();
                db.Items.Remove(remove);
                db.SaveChanges();
            }
            return item.ItemsId;
        }
    }
}