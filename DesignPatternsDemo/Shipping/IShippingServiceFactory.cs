using DesignPatternsDemo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Shipping
{
    public interface IShippingServiceFactory
    {
        IShippingService Create (ShippingType type);
    }
}
