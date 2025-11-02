using ObserverPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    public class ForecastDisplay : Observer, DisplayElement
    {
        private float temperature;
        private float humidity;
        private Subject weatherData;

        public ForecastDisplay(Subject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }
        public void display()
        {
            Console.WriteLine("Forecast: " + temperature + "F degrees and " + humidity + "% humidity");
        }

        public void update(float temp, float humidity, float pressure)
        {
            this.temperature = temp;
            this.humidity = humidity;
            display();
        }
    }
}
