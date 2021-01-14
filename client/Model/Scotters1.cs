using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Sensors;

namespace Client.Model
{
    class Scotters1
    {
        public static List<SensorInterface> CreateScouters()
        {
            
            // init sensors
            List<SensorInterface> sensors = new List<SensorInterface>();
            sensors.Add(new VirtualSpeedSensor());
            sensors.Add(new BatteryVirtualSensor());
            sensors.Add(new PositionVirtualSensor());

            return sensors;
        }
    }
}
