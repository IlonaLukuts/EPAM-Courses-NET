using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SellingsWeb.Controllers
{
    using Models;

    using BussinessLayer;

    using BussinessLayer.BussinessObjects;

    public class SellingController : Controller
    {
        private IWebSellProvider webSellProvider;
        // GET: Selling
        public ActionResult All()
        {
            var sellings = webSellProvider.GetSellings();
            ICollection<SellingModel> sellingModels = new List<SellingModel>();
            foreach (var s in sellings)
            {
                sellingModels.Add(ConvertToModel(s));
            }
            return View(sellingModels);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        private SellingModel ConvertToModel(Selling selling)
        {
            var sellingModel = new SellingModel()
            {
                Id = selling.Id,
                ClientSurname = selling.ClientSurname,
                DateTime = selling.DateTime,
                Product = selling.Product,
                Sum = selling.Sum
            };
            return sellingModel;
        }
    }
}