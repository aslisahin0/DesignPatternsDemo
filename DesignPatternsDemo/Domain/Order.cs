using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Domain
{
    public sealed class Order
    {
        public required decimal Total { get; init; } //ürünlerin toplam fiyatı
        public required decimal Weight { get; init; } //ürünlerin ağırlığı - kargo hesabı için
    }
}
