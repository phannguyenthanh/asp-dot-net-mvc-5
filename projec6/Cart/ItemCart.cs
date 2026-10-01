using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using project5.Models;
//using System.Xml.Serialization;
namespace projec6.Cart
{
    [Serializable]
    public class ItemCart
    {
        
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}