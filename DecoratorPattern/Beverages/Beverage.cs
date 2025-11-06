using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern.Beverages
{
    public abstract class Beverage
    {
        public string Description { get; protected set; } = "Unknown Beverage";
        public virtual string GetDescription()
        {
            return Description;
        }
        public abstract double Cost();
    }
}
