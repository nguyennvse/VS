using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VS_Business.Model
{
    class RoleModel
    {
        public string name { get; set; }
        public int value { get; set; }
        public RoleModel(string name, int value)
        {
            this.name = name;
            this.value = value;
        }
    }
}
