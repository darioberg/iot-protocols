using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Sensors
{
    public class PositionVirtualSensor : SensorInterface, PositionSensorInterface
    {
        // in questa class vado a generare le cordinate dello scooter
        public float GetLatitudine()
        {
            var ciao = new Random();
            return ciao.Next(1, 60);
        }
        public float GetGrade()
        {
            var x = new Random();
            return x.Next(1,60);
        }
        public float GetLongitudine()
        {
            var random = new Random();
            return random.Next(1, 60);
        }

        public string toJson()
        {
            Console.WriteLine("\"Location\": " + GetLatitudine() + "." + GetGrade()+ ", " + GetLongitudine() + "." + GetGrade());
            return "{\"Location\": " + GetLatitudine() + "." + GetGrade() + ", " + GetLongitudine() + "." + GetGrade() + "}";
        }
    }
}
