using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellingsWeb.Models
{
    public class SellingModel
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string ClientSurname { get; set; }

        public string Product { get; set; }

        public decimal Sum { get; set; }
    }
}