using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Sensors
{
    public class PositionVirtualSensor : SensorInterface, PositionSensorInterface
    {
        // in questa class vado a generare le cordinate dello scooter
        public string GetLatitudine()
        {
            
            var random = new Random();
            return random.Next(1, 60) + "."+ random.Next(1, 60);
        }
        
        public string toJson()
        {
            Console.WriteLine("\"location\":" + GetLatitudine());
            return "{\"location\":" + GetLatitudine() + "}";
        }
    }
}
