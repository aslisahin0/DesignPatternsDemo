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
        public decimal CalculateShippingCost(Order order)
        {
            // uluslararası kargo hesaplama örneği
            decimal baseRate = 25.00m; // Sabit başlangıç ücreti
            decimal weightRate = 2.00m; // Ağırlık başına ücret
            decimal customsFee = 10.00m; // Gümrük ücreti
            return baseRate + (weightRate * order.Weight) + customsFee;
        }
    }
}
