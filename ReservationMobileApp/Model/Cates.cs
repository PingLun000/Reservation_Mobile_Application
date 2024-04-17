using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationMobileApp.Model
{
    public class Categories
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Cate
    {
        public Categories categories { get; set; }
    }

    public class Cates
    {
        public IList<Cate> categories { get; set; }
    }
    //Category
}
