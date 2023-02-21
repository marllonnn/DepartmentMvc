using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.ViewModels
{
    public class SellerFormViewModels
    {
        public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; }

    }
}
