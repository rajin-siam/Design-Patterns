using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    public interface Observer
    {
        public void update(float temp, float humidity, float pressure);
    }
}
