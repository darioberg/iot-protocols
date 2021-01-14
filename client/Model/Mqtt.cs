using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.ManagedClient;


namespace Client
{
    class Mqtt
    {
        static MqttFactory factory = new MqttFactory(); // creo oggetto con al interno che fara la connesione
        static IMqttClient mqttClient = factory.CreateMqttClient();

        public static async Task MqttConnection()
        {

            var options = new MqttClientOptionsBuilder() // costruzione delle impostazione di connesione
                .WithClientId("client1") //  nome dispositivo
                .WithTcpServer("151.41.138.162", 1883) // ip e porta 
                .WithCleanSession() 
                .Build();

           await mqttClient.ConnectAsync(options); // connessione a mqtt "broker"
        }

        public static async Task SendMessage(string topic, string payload)
        {
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic) // nome topic
                .WithPayload(payload) // lo status del oggetto tutti i dati
                .Build(); // 

            await mqttClient.PublishAsync(message, CancellationToken.None);


        }

    }

}
