using AngularJS.Models;
using System;
using System.Collections.Generic;

namespace AngularJS.ViewModel
{
    public class PurchaseViewModel
    {
        public Guid PurchaseId { get; set; }
        public Nullable<int> SuplierId { get; set; }
        public Nullable<bool> PurchaseStatus { get; set; }
        public Nullable<System.DateTime> PurchaseDate { get; set; }
        public List<PurchaseItem> PurchaseItems { get; set; }
    }
}