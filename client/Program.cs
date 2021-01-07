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
using CsQuery.Engine.PseudoClassSelectors;
using MQTTnet.Client;

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
                    //HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://b1df610c81ab.ngrok.io/scooters/1");
                    //httpWebRequest.ContentType = "text/json";
                    //httpWebRequest.Method = "POST";

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

        public static async Task ConnectAsync()
        {
            string clientId = Guid.NewGuid().ToString();
            string mqqtURI = "test.mosquitto.org";
            int mqttPort = 1883;
            bool mqttSecure = false;

            var messageBuilder = new MqttClientOptionsBuilder()
                .WithClientId(clientId)
                .WithTcpServer(mqqtURI, mqttPort)
                .WithCleanSession();

            var options = mqttSecure
                ? messageBuilder
                .WithTls()
                .Build()
                : messageBuilder
                .Build();

            var managedOptions = new ManagedMqttClientOptionsBuilder()
                .WithAutoReconnectDelay(TimeSpan.FromSeconds(5))
                .WithClientOptions(options)
                .Build();

            var client = new MqttFactory().CreateManagedMqttClient();

            await client.StartAsync(managedOptions);
        }

        public static async void PublishAsync(IMqttClient mqttClient)
        {
            var message = new MqttApplicationMessageBuilder()
                .WithTopic("iot2021/es2/dariobergamasco")
                .WithPayload();
        }
            

    }

}
