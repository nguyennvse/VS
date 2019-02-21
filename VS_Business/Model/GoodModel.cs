using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VS_Business.Model
{
    class GoodModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string unit { get; set; }
        public int price { get; set; }

        public GoodModel(int id, string name, string unit, int price)
        {
            this.id = id;
            this.name = name;
            this.unit = unit;
            this.price = price;
        }

        public GoodModel()
        {

        }
    }
}
