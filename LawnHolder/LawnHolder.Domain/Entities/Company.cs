using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnHolder.Domain.Entities
{
    public class Company
    {
        [Key]
        public string CompanyName { get; set; }
        public int CompanyAddress { get; set; }
        public string Zipcode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int Phone { get; set; }
        public string UserID { get; set; }


    }
}
