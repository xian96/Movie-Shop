using MovieShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Core.Models.Response
{
    public class PurchaseResponseModel
    {
        // TODO: what is the type of uniqueidentifier
        public int PurchaseNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PurchaseDateTime { get; set; }

        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
