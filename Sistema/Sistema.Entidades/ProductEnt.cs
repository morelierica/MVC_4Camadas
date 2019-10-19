using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema.Entidades
{
    public class ProductEnt
    {
        private int pro_id;
        private string pro_name;
        private string pro_description;
        private decimal pro_price;

        public int Pro_id { get => pro_id; set => pro_id = value; }
        public string Pro_name { get => pro_name; set => pro_name = value; }
        public string Pro_description { get => pro_description; set => pro_description = value; }
        public decimal Pro_price { get => pro_price; set => pro_price = value; }
    }
}
