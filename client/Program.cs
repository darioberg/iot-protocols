using System;
using System.Collections.Generic;
using Client.Sensors;
using System.Net;
using System.IO;
using System.Collections;
using System.Threading.Tasks;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet;
using MQTTnet.Client;
using CsQuery.Engine.PseudoClassSelectors;
using System.Threading;
using Client.Model;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {

            // topic
            const string topic = "scooters/123";

            await Mqtt.MqttConnection();

            

            while (true)
            {
                foreach (SensorInterface sensor in Scotters1.CreateScouters())
                {
                    //HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://b1df610c81ab.ngrok.io/scooters/1");
                    //httpWebRequest.ContentType = "text/json";
                    //httpWebRequest.Method = "POST";

                    //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    //{
                    //    streamWriter.Write(sensor.toJson());
                    //}

                    //var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();   

                    //Console.Out.WriteLine(httpResponse.StatusCode);

                    //httpResponse.Close();

                    //System.Threading.Thread.Sleep(1000);

                    // MTTQ PART

                    await Mqtt.SendMessage(topic, sensor.toJson());

                    Thread.Sleep(1000);

                }
            }   
        }



    }
}
