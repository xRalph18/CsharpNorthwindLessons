using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperContrib___4.Model
{
    class Foods
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double AverageUSDPrice { get; set; }
        public int FoodType { get; set; }
    }
}
