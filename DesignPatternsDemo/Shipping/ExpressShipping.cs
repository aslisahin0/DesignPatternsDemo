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
        public decimal CalculateShippingCost(Order order)
        {
            //ekspres kargo hesaplama örneği
            decimal baseRate = 15.00m; // Sabit başlangıç ücreti
            decimal weightRate = 1.00m; // Ağırlık başına ücret
            return baseRate + (weightRate * order.Weight);
        }
    }
}
