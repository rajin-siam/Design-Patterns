using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public class ChocolateBoiler
    {
        // Step 1: Create a private static variable to hold the ONE instance
        private static ChocolateBoiler _instance;

        private bool _empty;
        private bool _boiled;

        // Step 2: Make constructor PRIVATE so no one else can create instances
        private ChocolateBoiler()
        {
            _empty = true;
            _boiled = false;
            Console.WriteLine("Creating the one and only ChocolateBoiler!");
        }

        // Step 3: Provide a public static method to get the instance
        public static ChocolateBoiler Instance
        {
            get
            {
                // Create instance only if it doesn't exist yet (Lazy Creation)
                if (_instance == null)
                {
                    _instance = new ChocolateBoiler();
                }
                return _instance;
            }
        }

        public void Fill()
        {
            if (_empty)
            {
                _empty = false;
                _boiled = false;
                Console.WriteLine("Filling the boiler with milk and chocolate");
            }
            else
            {
                Console.WriteLine("Boiler is already full!");
            }
        }

        public void Boil()
        {
            if (!_empty && !_boiled)
            {
                Console.WriteLine("Bringing the contents to a boil");
                _boiled = true;
            }
            else
            {
                Console.WriteLine("Can't boil - either empty or already boiled!");
            }
        }

        public void Drain()
        {
            if (!_empty && _boiled)
            {
                Console.WriteLine("Draining the boiled milk and chocolate");
                _empty = true;
            }
            else
            {
                Console.WriteLine("Can't drain - not ready yet!");
            }
        }
    }

    // Usage
    
}
