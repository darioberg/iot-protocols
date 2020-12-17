using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
namespace Client.Sensors
{
    public class BatteryVirtualSensor : SensorInterface, BatterySensorInterface
    {

        int charge = 100;
       

        public int GetCharge()
        {
            if (charge <= 0) // se charge minore o uguale a  0 charge == 100;
            {
                charge = 100;
                
            }
            charge--;
            return charge;
        }

        public string toJson()
        {
            Console.WriteLine("\"charge\": " + GetCharge());
            return "{\"charge\": " + GetCharge() + "}";
        }
    }
}