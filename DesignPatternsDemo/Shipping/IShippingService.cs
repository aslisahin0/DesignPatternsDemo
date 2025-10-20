using DesignPatternsDemo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Shipping
{
    public interface IShippingService
    {
        string Name { get; }
        decimal CalculateShippingCost(Order order);
    }
}
