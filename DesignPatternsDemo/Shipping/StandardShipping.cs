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
        public decimal CalculateShippingCost(Order order)
        {
            // standart kargo hesaplama örneği
            decimal baseRate = 5.00m; // Sabit başlangıç ücreti
            decimal weightRate = 0.50m; // Ağırlık başına ücret
            return baseRate + (weightRate * order.Weight);
        }   
    }
}
