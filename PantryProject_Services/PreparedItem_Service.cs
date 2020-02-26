using PantryProject.Data.Entities;
using PantryProject.Models.PreparedItem;
using PantryProject_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantryProject_Services
{
    public class PreparedItem_Service
    {
        public bool Create_PreparedItem(PreparedItem_Create model)
        {
            PreparedItem entity = new PreparedItem()
            {
                Name = model.Name,
                TypeOf_PreparedItem = model.PreparedItemType,
                StateOf_PreparedItem = model.PreparedItemState
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.PreparedItems.Add(entity);
                return ctx.SaveChanges() == 1;
            }             
        }

        public IEnumerable<PreparedItem_ListItem> Get_AllPreparedItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.PreparedItems
                               .Select(
                                   i => new PreparedItem_ListItem
                                   {
                                       Id = i.Id,
                                       Name = i.Name,
                                       TypeOf_PreparedItem = i.TypeOf_PreparedItem,
                                       StateOf_PreparedItem = i.StateOf_PreparedItem
                                   }
                                   );
                return query.ToList();
            }
        }

        public PreparedItem_Detail Get_PreparedItem_ByName(string itemName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PreparedItems.Single(i => i.Name == itemName);

                var item = new PreparedItem_Detail()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    TypeOf_PreparedItem = entity.TypeOf_PreparedItem,
                    StateOf_PreparedItem = entity.StateOf_PreparedItem
                };
                return item;

            }
        }

        public PreparedItem_Detail Get_PreparedItem_ById(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.PreparedItems.Single(i => i.Id == Id);

                var item = new PreparedItem_Detail()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    TypeOf_PreparedItem = entity.TypeOf_PreparedItem,
                    StateOf_PreparedItem = entity.StateOf_PreparedItem
                };
                return item;

            }
        }
        public bool Delete_PreparedItem(int id)
        {
            var entity = Get_ActualPreparedItem_ById(id);

            using (var ctx = new ApplicationDbContext())
            {
                ctx.PreparedItems.Remove(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        private PreparedItem Get_ActualPreparedItem_ById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PreparedItems
                        .Single(i => i.Id == id);
                return entity;
            }
            

        }

    }
}
