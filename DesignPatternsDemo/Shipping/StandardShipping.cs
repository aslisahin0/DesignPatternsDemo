using DesignPatternsDemo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Shipping
{
    public sealed class StandardShipping : IShippingService
    {
        public string Name => "Standard Shipping";
        public decimal CalculateShippingCost(Order order) => 5.00m + (0.50m * order.Weight);
    }
}