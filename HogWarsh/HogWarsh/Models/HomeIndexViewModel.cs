using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HogWarsh.Models
{
    public class HomeIndexViewModel
    {
        public class HouseViewModel : House
        {
            public string Color { get; set; }
            public List<Student> Students { get; set; }
        }
        public List<HouseViewModel> Houses { get; set; }
    }
}