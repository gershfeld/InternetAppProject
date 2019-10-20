using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace secondHandPro.Models
{
    public class Notice
    {
        public int ID { get; set; }
        public String Contact { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public double Price { get; set; }
        public States State { get; set; }
        public Categorys Category { get; set; }
        public String Image { get; set; }
        public int counter { get; set; }
        public Locations Location { get; set; }
        public enum Categorys { Furniture,Sports,Cars,Electronics,Jewelry }
        public enum Locations { East,West,South,North,Center }
        public enum States { New, Refurbishd, Used, Salvage }
        public User U { get; set; }
      

    }
}