using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _70325_Dolbik_Vorobei.DAL;

namespace _70325_Dolbik_Vorobei.Models
{
    public class CartItem
    {
        public Dish Dish { get; set; }
        public int Quantity { get; set; }
    }
}