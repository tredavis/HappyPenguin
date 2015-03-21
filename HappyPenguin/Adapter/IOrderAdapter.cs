using HappyPenguin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyPenguin.Adapter
{
    public interface IOrderAdapter
    {
        List<ItemViewModels> GetItem();
        int AddItem(ItemViewModels model, string userId);
        int DeleteItem(ItemViewModels item);
    }
}
