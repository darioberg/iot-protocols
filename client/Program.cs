﻿using System;
using System.Collections.Generic;
using Client.Sensors;
using System.Net;
using System.IO;
using System.Collections;


namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {

            // init sensors
            List<SensorInterface> sensors = new List<SensorInterface>();
            sensors.Add(new VirtualSpeedSensor());
            sensors.Add(new BatteryVirtualSensor());
            sensors.Add(new PositionVirtualSensor());

            while (true)
            {
                foreach (SensorInterface sensor in sensors)
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://b1df610c81ab.ngrok.io/scooters/1");
                    httpWebRequest.ContentType = "text/json";
                    httpWebRequest.Method = "POST";

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(sensor.toJson());
                    }

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                    Console.Out.WriteLine(httpResponse.StatusCode);

                    httpResponse.Close();

                    System.Threading.Thread.Sleep(1000);

                }

            }

        }

    }

}
