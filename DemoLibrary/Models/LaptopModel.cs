using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Models
{
    public class LaptopModel
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public double DisplayInInches { get; set; }

        public string FullLaptop
        {
            get
            {
                return $"{BrandName} {ColorName}";
            }
        }
    }
}
