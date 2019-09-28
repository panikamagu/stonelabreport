using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCP_MOULDS.Models
{
    public class DeliveryCost
    {
        public int DeliveryCostID { get; set; }
        public string DeliveryCostPlant { get; set; }
        public string DeliveryCostSapST { get; set; }
        public string DeliveryCostST { get; set; }
        public string DeliveryCostProvince { get; set; }
        public string DeliveryCostDistrict { get; set; }
        public string DeliveryCostTambon { get; set; }
        public string DeliveryCostDistance { get; set; }
        public string DeliveryCostY4 { get; set; }
        public string DeliveryCostY3 { get; set; }
        public string DeliveryCostY2 { get; set; }
        public string DeliveryCostVendor { get; set; }
        public string DeliveryCostSapEn { get; set; }
        public string DeliveryCostDateCreate { get; set; }
        public string DeliveryCostDateEdit { get; set; }
        public string DeliveryCostStatus { get; set; }
    }
}