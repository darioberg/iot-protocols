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
            try
            {
                await Mqtt.MqttConnection();  // connessione al broker
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("porcodio");
            }
            
            while (true)
            {
                foreach (SensorInterface sensor in Scotters1.CreateScouters()) //abbiamo creato scouters1 tramite una classe cosi si hanno i sensori
                                                                               // ma se ne possono implementare altri:
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

                    await Mqtt.SendMessage(topic, sensor.toJson()); // invio del messaggio 

                    Thread.Sleep(1000); // aspetta un secondo

                }
            }   
        }



    }
}
