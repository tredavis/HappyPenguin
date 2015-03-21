using HappyPenguin.Adapter;
using HappyPenguin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace HappyPenguin.Controllers
{
    public class apiItemController : ApiController
    {
        private IOrderAdapter _adapter;

        public apiItemController()
        {
            _adapter = new ItemDataAdapater();
        }
        public apiItemController(IOrderAdapter adapter)
        {
            _adapter = adapter;
        }
        public IHttpActionResult Post(ItemViewModels model)
        {
            string userId = User.Identity.GetUserId(); //brandon say something
            model.ItemsId = _adapter.AddItem(model, userId);
            return Ok(model);
        }
        public IHttpActionResult Get()
        {
            List<ItemViewModels> models = _adapter.GetItem();
            return Ok(models);
        }
        public IHttpActionResult Delete(ItemViewModels item)
        {
            item.ItemsId = _adapter.DeleteItem(item);
            return Ok(item);
        }
    }
}