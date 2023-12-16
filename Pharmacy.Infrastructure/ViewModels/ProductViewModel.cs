using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Infrastructure.ViewModels
{
    public class ProductViewModel
    {
        public long id {  get; set; }
        public string name { get; set; }
        public long? cost { get; set; }
    }
}
