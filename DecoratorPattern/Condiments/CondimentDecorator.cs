using DecoratorPattern.Beverages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Condiments
{
    public abstract class CondimentDecorator : Beverage
    {
        public abstract override string GetDescription();
    }

}
