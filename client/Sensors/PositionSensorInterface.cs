using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Sensors
{
    public interface PositionSensorInterface
    {
        float GetLatitudine();
        float GetLongitudine();
    }
}
