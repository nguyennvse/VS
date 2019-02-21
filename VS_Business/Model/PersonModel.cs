using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VS_Business.Model
{
    class PersonModel
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public int TaxNumber { get; set; }
        public int Phone { get; set; }
        public int FaxNumber { get; set; }
        public string Email { get; set; }
        public int id { get; set; }

        public PersonModel(string Name, string Company, int TaxNumber, int Phone, int FaxNumber, string Email, int id)
        {
            this.Name = Name;
            this.Company = Company;
            this.TaxNumber = TaxNumber;
            this.Phone = Phone;
            this.FaxNumber = FaxNumber;
            this.Email = Email;
            this.id = id;
        }

        public PersonModel()
        {

        }
    }
}
