using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VS_Business.Model
{
    class AccountModel
    {
        public string username;
        public string password;
        public string role;
        public int id;
        public AccountModel(string username,string password,string role,int id)
        {
            this.username = username;
            this.password = password;
            this.role = role;
            this.id = id;
        }
    }
}
