using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HogWarsh.Models
{
    public class HomeIndexViewModel
    {
        public HomeIndexViewModel()
        {
            Houses = new List<HouseViewModel>();
        }

        public List<HouseViewModel> Houses { get; set; }

        public class HouseViewModel : House
        {
            public HouseViewModel()
            {
                Students = new List<Student>();
            }
            public List<Student> Students { get; set; }
        }
    }
}