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
        public int roleid { get; set; }
        public RoleModel(string name, int roleid)
        {
            this.name = name;
            this.roleid = roleid;
        }
    }
}
