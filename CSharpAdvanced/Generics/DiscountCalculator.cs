using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanced.Generics
{
    public class DiscountCalculator<TProduct> where TProduct : Product
    {
        public float CalculateDiscount(TProduct product)
        {
            return product.Price;
        }
    }
}
