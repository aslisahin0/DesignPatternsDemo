using DesignPatternsDemo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Shipping
{
    public sealed class ExpressShipping : IShippingService
    {
        public string Name => "Express Shipping";
        public decimal CalculateShippingCost(Order order) => 15.00m + (1.00m * order.Weight);
    }
}
