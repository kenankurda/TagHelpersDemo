﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelpersDemo.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        [DisplayFormat(DataFormatString = "{0:c2}", ApplyFormatInEditMode = true)]
        public decimal Cost { get; set; }
        public decimal? BillAmount { get; set; }
        public decimal? Discount { get; set; }
        public decimal? NetBillAmount { get; set; }
        public bool IsPartOfDeal { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; } // relationship One to One  1 Product=1 Category
        public string PaymentType { get; set; }




    }
}
