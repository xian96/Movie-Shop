using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Core.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        // TODO: what is the type of uniqueidentifier
        public int PurchaseNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PurchaseDateTime { get; set; }
        public int MovieId { get; set; }

        //navigation
        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
