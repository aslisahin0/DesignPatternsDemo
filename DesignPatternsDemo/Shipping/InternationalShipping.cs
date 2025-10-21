using DesignPatternsDemo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Shipping
{
    public sealed class InternationalShipping : IShippingService
    {
        public string Name => "International Shipping";
        public decimal CalculateShippingCost(Order order) => 25.00m + (2.00m * order.Weight) + 10.00m;
    }
}
